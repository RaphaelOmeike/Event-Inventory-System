using Domain.Enums;

namespace API.Contracts
{
    public record CreateEventRequest(
        string Name,
        string? Description,
        DateTimeOffset Begin,
        DateTimeOffset End,
        DateTimeOffset RegBegin,
        DateTimeOffset RegEnd,
        string DefaultStatusName,
        string? DefaultStatusDescription,
        int? MaxAttendeeNo,
        IFormFile Picture,
        EventType EventType,
        TimeSpan MinimumWaitingTime,
        string AccessCode);
}
