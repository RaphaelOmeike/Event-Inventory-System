using Application.Interfaces.Repositories;
using Application.Options;
using Domain.Entities;
using Domain.Errors;
using Domain.Shared;
using MediatR;
using Microsoft.Extensions.Options;

namespace Application.Features.Events.Commands.Create
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly FileStorageOptions _options;

        public CreateEventCommandHandler(IUnitOfWork unitOfWork, IOptions<FileStorageOptions> options)
        {
            _unitOfWork = unitOfWork;
            _options = options.Value;
        }

        public async Task<Result<Guid>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            bool nameExists = await _unitOfWork.EventRepository.ExistsAsync(e => e.Name.ToLower() == request.Name.ToLower());
            if (nameExists)
            {
                return Result.Failure<Guid>(DomainErrors.Event.NameAlreadyInUse(request.Name));
            }

            var file = await FileOnFileSystemModel.Create(request.Picture, _options.BasePath, request.Name);

            _unitOfWork.FileRepository.UploadToFileSystem(file);
            await _unitOfWork.Complete();
            var newEvent = Event.Create(
                request.UserId,
                request.Name,
                request.Description,
                request.Begin,
                request.End,
                request.RegBegin,
                request.RegEnd,
                request.MaxAttendeeNo,
                file.Id,
                request.EventType,
                request.MinimumWaitingTime,
                request.AccessCode);

            await _unitOfWork.EventRepository.CreateAsync(newEvent);
            await _unitOfWork.Complete();
            //validate eventid existing also

            var eventStatus = EventStatus.Create(request.DefaultStatusName, request.DefaultStatusDescription, newEvent.Id);
            //it would not have had any of such names befor

            await _unitOfWork.EventStatusRepository.CreateAsync(eventStatus);
            await _unitOfWork.Complete();

            newEvent.SetDefaultStatusId(eventStatus.Id);
            await _unitOfWork.Complete();

            return newEvent.Id;
        }

    }
}
