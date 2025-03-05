using Domain.Common;

namespace Domain.Entities
{
    public class EventReport : BaseEntity
    {
        public Guid EventId { get; set; }
        public Event Event { get; set; } = null!;
        //aggregation jo
        public Guid EventStatusId { get; set; } //no relationship for you
        public int TotalNo { get; set; }
    }
}
