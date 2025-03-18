using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Implementations.Repositories
{
    public class EventReportRepository : GenericRepository<EventReport>, IEventReportRepository
    {
        public EventReportRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
