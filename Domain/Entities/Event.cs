using Domain.Common;
using Domain.Enums;
using Domain.Exceptions;

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
        public int? MaxAttendeeNo { get; set; }
        public int NoOfAttendees { get; set; } = default;
        public int PictureId { get; set; }
        public FileOnFileSystemModel Picture { get; set; } = null!;
        public EventType EventType { get; set; }
        public Guid? DefaultStatusId { get; set; }
        public EventStatus? DefaultEventStatus { get; set; } = null!;
        public bool IsEventOver { get; set; } = default;
        public TimeSpan MinimumWaitingTime { get; set; } //can set to 15mins
        public string? RegistrationCode { get; set; }
        public string? EventCode { get; set; }
        public string AccessCode { get; set; } = null!;

        public ICollection<EventStatus> EventStatuses { get; } = [];
        public ICollection<EventAttendee> EventAttendees { get; } = [];
        public ICollection<EventReport> EventReports { get; } = [];

        public ICollection<User> EventRegistrars { get; } = [];

        //relationships remaining
        //also consider isover boolean variable
        private Event()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        private Event(string userId, string name, string? desc, DateTimeOffset begin, DateTimeOffset end, DateTimeOffset regBegin,
            DateTimeOffset regEnd, int? maxNo, int pictureId, EventType eventType, TimeSpan minimumWaitingTime, string accessCode,
            string? regCode = null, string? eventCode = null)
        {
            CreatedBy = userId;
            Name = name;
            Description = desc;
            Begin = begin;
            End = end;
            RegistrationBegin = regBegin;
            RegistrationEnd = regEnd;
            MaxAttendeeNo = maxNo;
            PictureId = pictureId;
            EventType = eventType;
            MinimumWaitingTime = minimumWaitingTime;
            AccessCode = accessCode;
            if (eventType.Equals(EventType.Private))
            {
                ValidatePrivateInputs(regCode, eventCode);
                RegistrationCode = regCode;
                EventCode = eventCode;
            }
        }
        public void SetDefaultStatusId(Guid eventStatusId)
        {
            DefaultStatusId = eventStatusId;
        }
        public static Event Create(string userId, string name, string? desc, DateTimeOffset begin, DateTimeOffset end, DateTimeOffset regBegin,
            DateTimeOffset regEnd, int? maxNo, int pictureId, EventType eventType, TimeSpan minimumWaitingTime, string accessCode)
        {
            return new Event(userId, name, desc, begin, end, regBegin, regEnd, maxNo, pictureId, eventType, minimumWaitingTime, accessCode);
        }

        public static void ValidatePrivateInputs(string? regCode, string? eventCode)
        {
            if (string.IsNullOrEmpty(regCode))
                throw new EventRegistrationCodeIsNullException($"{nameof(regCode)} can't be null.");
            if (string.IsNullOrEmpty(eventCode))
                throw new EventCodeIsNullException($"{nameof(eventCode)} can't be null.");
        }
    }
}
