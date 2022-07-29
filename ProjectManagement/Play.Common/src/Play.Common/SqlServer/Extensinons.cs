using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Play.Common.Service.Settings;

namespace Play.Common.SqlServer
{
    public static class Extensions
    {

        public static IServiceCollection AddSqlServerDbContext<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
        {
            var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
            services.AddDbContext<T>(options => options.UseSqlServer(configuration.GetConnectionString(serviceSettings.ServiceName + "Db")));
            services.AddScoped<DbContext, T>();
            return services;
        }

        public static IServiceCollection AddSqlServerRepository<T>(this IServiceCollection services) where T : class, IEntity
        {
            services.AddScoped(typeof(IRepository<T>), typeof(SqlRespository<T>));
            return services;
        }
    }
}