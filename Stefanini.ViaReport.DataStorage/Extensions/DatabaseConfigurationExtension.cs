using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Stefanini.ViaReport.DataStorage.Extensions
{
    public static class DatabaseConfigurationExtension
    {
        public static void AddDatabaseServices(this IServiceCollection services, string connection)
        {
            services.AddDbContext<DbAppContext>(opt => opt.UseSqlite(connection), ServiceLifetime.Singleton);
            services.TryAddScoped<IDbAppContext, DbAppContext>();
        }
    }
}