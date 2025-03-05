using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Attendee : AuditableBaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Gender Gender { get; set; }
        public int PassportId { get; set; }
        public FileOnDatabaseModel PassportPhoto { get; set; } = null!;
        public bool IsValid { get; set; }
        public ICollection<EventAttendee> EventAttendees { get; } = [];

    }
}
