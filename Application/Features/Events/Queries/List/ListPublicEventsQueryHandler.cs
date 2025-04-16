using Application.Features.Events.DTOs;
using Application.Filters;
using Application.Helpers;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Wrappers;
using Domain.Enums;
using Domain.Shared;
using Mapster;
using MapsterMapper;
using MediatR;

namespace Application.Features.Events.Queries.List
{
    public class ListPublicEventsQueryHandler : IRequestHandler<ListPublicEventsQuery, Result<PagedResponse<IEnumerable<EventDto>>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public ListPublicEventsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IUriService uriService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _uriService = uriService;
        }

        public async Task<Result<PagedResponse<IEnumerable<EventDto>>>> Handle(ListPublicEventsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<PaginationFilter>(request);

            var publicEvents = await _unitOfWork.EventRepository.GetPagedReponseAsync(e => e.EventType == EventType.Public, validFilter.PageNumber, validFilter.PageSize);
            if (publicEvents is null)
            {
                return Result.Failure<PagedResponse<IEnumerable<EventDto>>>(Error.NullValue);
            }
            var pagedData = publicEvents.Select(_mapper.Map<EventDto>).ToList();
            var totalRecords = publicEvents.Count();
            var pagedResponse = PaginationHelper.CreatePagedResponse<EventDto>(pagedData, validFilter, totalRecords, _uriService, request.route);
            return pagedResponse;
        }

    }
}
