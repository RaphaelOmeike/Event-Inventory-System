using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Event : AuditableBaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public DateTime RegistrationBegin { get; set; }
        public DateTime RegistrationEnd { get; set; }
        public int MaxAttendeeNo { get; set; }
        public int PictureId { get; set; }
        public FileOnFileSystemModel Picture { get; set; } = null!;
        public EventType EventType { get; set; }
        public Guid DefaultStatusId { get; set; }
        public EventStatus DefaultEventStatus { get; set; } = null!;
        public bool IsEventOver { get; set; }
        public TimeSpan MinimumWaitingTime { get; set; } //can set to 15mins
        public string? RegistrationCode { get; set; }
        public string? EventCode { get; set; }
        public string? AccessCode { get; set; }

        public ICollection<EventStatus> EventStatuses { get; } = [];
        public ICollection<EventAttendee> EventAttendees { get; } = [];
        public ICollection<EventReport> EventReports { get; } = [];
        //relationships remaining
        //also consider isover boolean variable
    }
}
