using Domain.Enums;

namespace Application.Features.Events.DTOs
{
    public record EventDto(
        string Name,
        string? Description,
        DateTimeOffset Begin,
        TimeSpan Duration,
        DateTimeOffset End,
        DateTimeOffset RegBegin,
        DateTimeOffset RegEnd,
        int? MaxAttendeeNo,
        int NoOfAttendees,
        string FilePath,
        EventType EventType,
        Guid? DefaultStatusId,
        string DefaultStatusName,
        bool IsEventOver,
        TimeSpan MinimumWaitingTime,
        string? RegistrationCode,
        string? EventCode,
        string AccessCode,
        IReadOnlyCollection<string> EventStatuses,
        IReadOnlyCollection<string> EventRegistrars//stores email
        );

    //public ICollection<EventAttendee> EventAttendees { get; } = [];
}      //public ICollection<EventReport> EventReports { get; } = [];
    