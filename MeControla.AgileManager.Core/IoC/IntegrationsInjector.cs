using MeControla.AgileManager.Core.Integrations.Jira.V1.Auth;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Fields;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Issues;
using MeControla.AgileManager.Core.Integrations.Jira.V2.IssueTypes;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Projects;
using MeControla.AgileManager.Core.Integrations.Jira.V2.StatusCategories;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Statuses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace MeControla.AgileManager.Core.IoC
{
    public static class IntegrationsInjector
    {
        public static void AddIntegrations(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.TryAddScoped<IFieldGetAll, FieldGetAll>();
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