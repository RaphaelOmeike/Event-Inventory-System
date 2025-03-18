using Domain.Entities;
using Infrastructure.Specifications;

namespace Application.Specifications
{
    public class EventAttendeeByIdWithActionsHistorySpecification : BaseSpecification<EventAttendee>
    {
        public EventAttendeeByIdWithActionsHistorySpecification(Guid eventAttendeeId) : base(eventAttendee => eventAttendee.Id == eventAttendeeId)
        {
            AddInclude(eventAttendee =>  eventAttendee.ActionsTaken);
        }
    }
}
