using Domain.Entities;
using Infrastructure.Specifications;

namespace Application.Specifications
{
    public class EventByIdWithEventAttendeeSpecification : BaseSpecification<Event>
    {
        public EventByIdWithEventAttendeeSpecification(Guid eventId) : base(e => e.Id == eventId)
        {
            AddInclude(e => e.EventAttendees);
        }
    }
}
