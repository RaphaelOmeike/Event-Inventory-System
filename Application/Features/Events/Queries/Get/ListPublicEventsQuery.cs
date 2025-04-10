using MediatR;

namespace Application.Features.Events.Queries.Get
{
    public record ListPublicEventsQuery(
        int PageNumber,
        int PageSize) : IRequest;
}
