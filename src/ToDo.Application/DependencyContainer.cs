using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ToDo.Application
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register application services here
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
