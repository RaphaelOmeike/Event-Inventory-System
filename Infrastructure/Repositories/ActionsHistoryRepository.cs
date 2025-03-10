using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Repositories
{
    public class ActionsHistoryRepository : GenericRepository<ActionsHistory>, IActionsHistoryRepository
    {
        public ActionsHistoryRepository(ApplicationDbContext context) : base(context)
        {
        }
        
    }
}
