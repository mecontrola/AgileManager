using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Stefanini.ViaReport.DataStorage.Repositories;
using System;

namespace Stefanini.ViaReport.DataStorage.IoC
{
    public static class DatabaseInjector
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.TryAddTransient<IIssueRepository, IssueRepository>();
            services.TryAddTransient<IIssueTypeRepository, IssueTypeRepository>();
            services.TryAddTransient<IIssueStatusHistoryRepository, IssueStatusHistoryRepository>();
            services.TryAddTransient<IProjectRepository, ProjectRepository>();
            services.TryAddTransient<IProjectCategoryRepository, ProjectCategoryRepository>();
            services.TryAddTransient<IStatusRepository, StatusRepository>();
            services.TryAddTransient<IStatusCategoryRepository, StatusCategoryRepository>();
        }
    }
}