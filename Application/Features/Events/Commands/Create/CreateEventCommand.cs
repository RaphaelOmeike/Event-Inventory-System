using MediatR;
using Domain.Enums;
using Domain.Shared;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Events.Commands.Create
{
    public record CreateEventCommand(
        string UserId,
        string Name,
        string? Description,
        DateTimeOffset Begin,
        DateTimeOffset End,
        DateTimeOffset RegBegin,
        DateTimeOffset RegEnd,
        string DefaultStatusName,
        string? DefaultStatusDescription,
        int? MaxAttendeeNo,
        //[FromForm]
        IFormFile Picture,
        EventType EventType,
        TimeSpan MinimumWaitingTime,
        string AccessCode
        ) : IRequest<Result<Guid>>;
}
