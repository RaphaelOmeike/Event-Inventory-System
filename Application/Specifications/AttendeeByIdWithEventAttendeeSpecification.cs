using Domain.Entities;
using Infrastructure.Specifications;

namespace Application.Specifications
{
    public class AttendeeByIdWithEventAttendeeSpecification : BaseSpecification<Attendee>
    {
        public AttendeeByIdWithEventAttendeeSpecification(Guid attendeeId) : base(attendee => attendee.Id == attendeeId)
        {
            AddInclude(attendee => attendee.EventAttendees);
        }
    }
}
