using Domain.Entities;
using Infrastructure.Specifications;

namespace Application.Specifications
{
    public class EventByIdSplitSpecification : BaseSpecification<Event>
    {
        public EventByIdSplitSpecification(Guid eventId) : base(e => e.Id == eventId) 
        {
            AddInclude(e => e.Picture);
            AddInclude(e => e.DefaultEventStatus!);
            AddInclude(e => e.EventStatuses);
            AddInclude(e => e.EventRegistrars);
        }
    }
}
