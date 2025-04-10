using Application.Interfaces.Repositories;
using Infrastructure.Implementations.Repositories;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ActionsHistoryRepository = new ActionsHistoryRepository(_context);
            AttendeeRepository = new AttendeeRepository(_context);
            EventRepository = new EventRepository(_context);
            EventAttendeeRepository = new EventAttendeeRepository(_context);
            EventReportRepository = new EventReportRepository(_context);
            EventStatusRepository = new EventStatusRepository(_context);
            FileRepository = new FileRepository(_context);
            RoleRepository = new RoleRepository(_context);
            UserRepository = new UserRepository(_context);
        }

        public IActionsHistoryRepository ActionsHistoryRepository { get; private set; }
        public IAttendeeRepository AttendeeRepository { get; private set; }
        public IEventRepository EventRepository { get; private set; }
        public IEventAttendeeRepository EventAttendeeRepository { get; private set; }
        public IEventReportRepository EventReportRepository { get; private set; }
        public IEventStatusRepository EventStatusRepository { get; private set; }
        public IFileRepository FileRepository { get; private set; }
        public IRoleRepository RoleRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
