using Application.Features.Events.DTOs;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Enums;
using Domain.Shared;
using MediatR;

namespace Application.Features.Events.Queries.Get
{
    public class ListPublicEventsQueryHandler : IRequestHandler<ListPublicEventsQuery, Result<PagedResponse<IEnumerable<EventDto>>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListPublicEventsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PagedResponse<IEnumerable<EventDto>>>> Handle(ListPublicEventsQuery request, CancellationToken cancellationToken)
        {
            var publicEvents = await _unitOfWork.EventRepository.GetAllAsync(e => e.EventType == EventType.Public);

            var validFilter = //mapper

        }
    }
}
