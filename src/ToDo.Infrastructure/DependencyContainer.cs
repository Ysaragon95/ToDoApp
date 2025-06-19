using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Domain.Common.Configuration;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Services;
using ToDo.Infrastructure.Common;
using ToDo.Infrastructure.Persistence.Context;
using ToDo.Infrastructure.Repositories;
using ToDo.Infrastructure.Services;

namespace ToDo.Infrastructure
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ToDoBDConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 3,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null
                        );
                    });
            });

            #region Services
            services.Configure<JwtOption>(configuration.GetSection(JwtOption.SectionName));
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IJwtService, JwtService>();
            #endregion

            #region Repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();
            #endregion

            return services;
        }
    }
}
