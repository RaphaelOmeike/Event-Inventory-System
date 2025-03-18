using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Event : AuditableBaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTimeOffset Begin { get; set; }
        public DateTimeOffset End { get; set; }
        public DateTimeOffset RegistrationBegin { get; set; }
        public DateTimeOffset RegistrationEnd { get; set; }
        public int MaxAttendeeNo { get; set; }
        public int PictureId { get; set; }
        public FileOnFileSystemModel Picture { get; set; } = null!;
        public EventType EventType { get; set; }
        public Guid? DefaultStatusId { get; set; }
        public EventStatus? DefaultEventStatus { get; set; } = null!;
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

        private Event(string name, string desc, DateTimeOffset begin, DateTimeOffset end, DateTimeOffset regBegin, DateTimeOffset regEnd, 
            int maxNo, Guid pictureId, EventType eventType, Guid defaultStatusId, bool isEventOver, TimeSpan minimumWaitingITme, 
            string regCode, string eventCode, string accessCode)
        {
            
        }
    }
}
