using Domain.Common;

namespace Domain.Entities
{
    public class EventAttendee : BaseEntity
    {
        public Guid EventId { get; set; }
        public Event Event { get; set; } = null!;
        public Guid AttendeeId { get; set; }
        public Attendee Attendee { get; set; } = null!;
        public DateTime? Arrival { get; set; }
        public bool HasArrived { get; set; }
        public bool IsVerified { get; set; }
        public Guid CurrentStatusId { get; set; }
        public EventStatus EventStatus { get; set; } = null!;
        public ICollection<ActionsHistory> ActionsTaken { get; } = [];
    }
}
