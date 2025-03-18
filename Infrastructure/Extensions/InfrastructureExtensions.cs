using Application.Interfaces.Repositories;
using Infrastructure.Implementations.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            return services.AddScoped<IActionsHistoryRepository, ActionsHistoryRepository>()
                .AddScoped<IAttendeeRepository, AttendeeRepository>()
                .AddScoped<IEventReportRepository, EventReportRepository>()
                .AddScoped<IEventRepository, EventRepository>()
                .AddScoped<IEventStatusRepository, EventStatusRepository>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
