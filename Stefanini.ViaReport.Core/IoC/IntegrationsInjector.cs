using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Stefanini.ViaReport.Core.Integrations.Jira.V1.Auth;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Issues;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.IssueTypes;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.StatusCategories;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Statuses;
using System;

namespace Stefanini.ViaReport.Core.IoC
{
    public static class IntegrationsInjector
    {
        public static void AddIntegrations(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.TryAddScoped<ISessionGet, SessionGet>();
            services.TryAddScoped<IProjectGetAll, ProjectGetAll>();
            services.TryAddScoped<ISearchPost, SearchPost>();
            services.TryAddScoped<IIssueGet, IssueGet>();
            services.TryAddScoped<IIssueTypeGetAll, IssueTypeGetAll>();
            services.TryAddScoped<IStatusGetAll, StatusGetAll>();
            services.TryAddScoped<IStatusCategoryGetAll, StatusCategoryGetAll>();
        }
    }
}