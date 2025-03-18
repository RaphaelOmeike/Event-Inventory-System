using Domain.Entities;
using Infrastructure.Specifications;

namespace Application.Specifications
{
    public class EventByIdWithEventReportSpecification : BaseSpecification<Event>
    {
        public EventByIdWithEventReportSpecification(Guid eventId) : base(e => e.Id == eventId)
        {
            AddInclude(e => e.EventReports);
        }
    }
}
