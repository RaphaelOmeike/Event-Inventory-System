using Domain.Entities;
using Infrastructure.Specifications;

namespace Application.Specifications
{
    public class EventAttendeesWithEventStatusSpecification : BaseSpecification<EventAttendee>
    {
        public EventAttendeesWithEventStatusSpecification()
        {
            AddInclude(eventAttendee => eventAttendee.EventStatus);
        }
    }
}
