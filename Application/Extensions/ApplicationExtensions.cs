using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using Application.Mapping;

namespace Infrastructure.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            })
            .AddMappings();
        }
    }
}
