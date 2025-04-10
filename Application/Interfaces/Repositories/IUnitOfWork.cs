namespace Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IActionsHistoryRepository ActionsHistoryRepository { get; }
        IAttendeeRepository AttendeeRepository { get; }
        IEventRepository EventRepository { get; }
        IEventAttendeeRepository EventAttendeeRepository { get; }
        IEventReportRepository EventReportRepository { get; }
        IEventStatusRepository EventStatusRepository { get; }
        IFileRepository FileRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }

        Task Complete();
    }
}
