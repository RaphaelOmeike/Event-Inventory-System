using Application.Features.Events.DTOs;
using Domain.Shared;
using MediatR;

namespace Application.Features.Events.Queries.Get
{
    public record GetEventByIdQuery(Guid Id) : IRequest<Result<EventDto>>;
}
