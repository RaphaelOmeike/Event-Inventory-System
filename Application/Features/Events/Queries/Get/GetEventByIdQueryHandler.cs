using Application.Features.Events.DTOs;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Errors;
using Domain.Shared;
using MapsterMapper;
using MediatR;

namespace Application.Features.Events.Queries.Get
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, Result<EventDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEventByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<EventDto>> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var eventExists = await _unitOfWork.EventRepository.ExistsAsync(a => a.Id == request.Id);

            if (!eventExists)
            {
                return Result.Failure<EventDto>(DomainErrors.Event.NotFound(request.Id));
            }
            var realEvent = _unitOfWork.EventRepository.FindWithSpecificationPattern(new EventByIdSplitSpecification(request.Id)).FirstOrDefault();
            return _mapper.Map<EventDto>(realEvent!);
        }
    }
}
