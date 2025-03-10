namespace Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IActionsHistoryRepository ActionsHistoryRepository { get; }
        IAttendeeRepository AttendeeRepository { get; }
        IEventReportRepository EventReportRepository { get; }
        IEventRepository EventRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }

        Task Complete();
    }
}
