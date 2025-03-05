using Domain.Common;

namespace Domain.Entities
{
    public class ActionsHistory : BaseEntity
    {
        public Guid EventAttendeeId { get; set; }
        public EventAttendee EventAttendee { get; set; } = null!;
        public DateTime Occured { get; set; }
        public bool PermissionGranted { get; set; }
    }
}
