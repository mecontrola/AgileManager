using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Stefanini.ViaReport.DataStorage.Extensions
{
    public static class DatabaseConfigurationExtension
    {
        public static void AddDatabaseServices(this IServiceCollection services, string connection)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddDbContext<IDbAppContext, DbAppContext>(opt => opt.UseSqlite(connection), ServiceLifetime.Singleton);
        }
    }
}