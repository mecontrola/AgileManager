using MeControla.AgileManager.Integrations.Jira.Data.Configurations;
using MeControla.AgileManager.Integrations.Jira.Rest.V1.Auth;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Contexts;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Fields;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.IssueTypes;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Options;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Projects;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.StatusCategories;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Statuses;
using MeControla.Core.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace MeControla.AgileManager.Integrations.Jira.IoC
{
    public static class JiraIntegrationInjector
    {
        public static void AddJiraIntegration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            services.AddJiraConfiguration(configuration);
            services.AddJiraIntegrationAuth();
            services.AddJiraIntegrationContext();
            services.AddJiraIntegrationFields();
            services.AddJiraIntegrationIssues();
            services.AddJiraIntegrationIssueTypes();
            services.AddJiraIntegrationOption();
            services.AddJiraIntegrationProjects();
            services.AddJiraIntegrationStatusCategories();
            services.AddJiraIntegrationStatuses();
        }

        private static void AddJiraConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<JiraConfiguration>(opt =>
            {
                var config = configuration.Get<JiraConfiguration>();
                opt.Url = config.Url.Base64Decode();
                opt.Username = config.Username.Base64Decode();
                opt.Password = config.Password.Base64Decode();
            });
        }

        private static void AddJiraIntegrationAuth(this IServiceCollection services)
        {
            services.TryAddScoped<ISessionGet, SessionGet>();
        }

        private static void AddJiraIntegrationContext(this IServiceCollection services)
        {
            services.TryAddScoped<IContextGetAll, ContextGetAll>();
        }

        private static void AddJiraIntegrationFields(this IServiceCollection services)
        {
            services.TryAddScoped<IFieldGetAll, FieldGetAll>();
        }

        private static void AddJiraIntegrationIssues(this IServiceCollection services)
        {
            services.TryAddScoped<IIssueGet, IssueGet>();
            services.TryAddScoped<ISearchPost, SearchPost>();
        }

        private static void AddJiraIntegrationIssueTypes(this IServiceCollection services)
        {
            services.TryAddScoped<IIssueTypeGetAll, IssueTypeGetAll>();
        }

        private static void AddJiraIntegrationOption(this IServiceCollection services)
        {
            services.TryAddScoped<IOptionGetAll, OptionGetAll>();
        }

        private static void AddJiraIntegrationProjects(this IServiceCollection services)
        {
            services.TryAddScoped<IProjectGetAll, ProjectGetAll>();
        }

        private static void AddJiraIntegrationStatusCategories(this IServiceCollection services)
        {
            services.TryAddScoped<IStatusCategoryGetAll, StatusCategoryGetAll>();
        }

        private static void AddJiraIntegrationStatuses(this IServiceCollection services)
        {
            services.TryAddScoped<IStatusGetAll, StatusGetAll>();
        }
    }
}