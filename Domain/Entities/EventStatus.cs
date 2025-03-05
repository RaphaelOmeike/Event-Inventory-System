using Domain.Common;

namespace Domain.Entities
{
    public class EventStatus : AuditableBaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; } = null!;
        public ICollection<EventAttendee> EventAttendees { get; } = [];
    }//specifications also
}
