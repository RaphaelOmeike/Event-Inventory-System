using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Implementations.Repositories
{
    public class EventStatusRepository : GenericRepository<EventStatus>, IEventStatusRepository
    {
        public EventStatusRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
