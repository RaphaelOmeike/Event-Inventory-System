using Domain.Entities;
using Infrastructure.Specifications;

namespace Application.Specifications
{
    public class AttendeesWithPassportPhotoSpecification : BaseSpecification<Attendee>
    {
        public AttendeesWithPassportPhotoSpecification()
        {
            AddInclude(attendee => attendee.PassportPhoto);
        }
    }
}
