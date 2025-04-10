using Domain.Common;
using Domain.Errors;
using Domain.Shared;

namespace Domain.Entities
{
    public class EventStatus : AuditableBaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; } = null!;
        public ICollection<EventAttendee> EventAttendees { get; } = [];

        private EventStatus() 
        {
            Name = string.Empty;
            Description = string.Empty;
        }
        private EventStatus(string name, string? desc, Guid eventId)
        {
            Name = name;
            Description = desc;
            EventId = eventId;
        }
        public static EventStatus Create(string name, string? desc, Guid eventId)
        {
            //if (string.IsNullOrEmpty(name))
            //    return Result.Failure<EventStatus>(DomainErrors.EventStatus.NameAlreadyInUse(name));
            
            return new EventStatus(name, desc, eventId);
        }
    }//specifications also
}
