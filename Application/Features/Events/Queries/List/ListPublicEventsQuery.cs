using Application.Features.Events.DTOs;
using Application.Wrappers;
using Domain.Shared;
using MediatR;

namespace Application.Features.Events.Queries.List
{
    public record ListPublicEventsQuery(
        int PageNumber,
        int PageSize,
        string route) : IRequest<Result<PagedResponse<IEnumerable<EventDto>>>>;
}
