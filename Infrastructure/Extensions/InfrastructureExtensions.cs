using Application.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            return services.AddScoped<IActionsHistoryRepository, >()
                .AddScoped<IAttendeeRepository, >()
                .AddScoped<IEventReportRepository, >()
                .AddScoped<IEventRepository, >()
                .AddScoped<IEventStatusRepository, >()
                .AddScoped<IRoleRepository, >()
                .AddScoped<IUserRepository, >()
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<IUnitOfWork, UnitOfWork>(); ;
        }
    }
}
