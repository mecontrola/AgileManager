using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Stefanini.ViaReport.DataStorage.Repositories;
using System;

namespace Stefanini.ViaReport.DataStorage.IoC
{
    public static class DatabaseInjector
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.TryAddTransient<IProjectRepository, ProjectRepository>();
            services.TryAddTransient<IProjectCategoryRepository, ProjectCategoryRepository>();
        }
    }
}