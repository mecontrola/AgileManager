using MeControla.AgileManager.Integrations.Jira.IoC;
using MeControla.AgileManager.Integrations.Jira.Rest.V1.Auth;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Fields;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.IssueTypes;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Projects;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.StatusCategories;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Statuses;
using MeControla.AgileManager.TestingTools.FluentAssertions.Extensions;
using Microsoft.Extensions.Configuration;
using NSubstitute;

namespace MeControla.AgileManager.Integrations.Jira.Tests.IoC
{
    public class JiraIntegrationsInjectorTests : BaseInjectorTests
    {
        private const int TOTAL_RECORDS = 8;

        private static IConfiguration GetConfiguration()
            => Substitute.For<IConfiguration>();

        [Fact(DisplayName = "[JiraIntegrationsInjector.AddJiraIntegration] Deve gerar exceção quando o serviceCollection for nulo.")]
        public void DeveGerarExcecaoQuandoServiceCollectionNulo()
            => RunServiceCollectionNull(serviceCollection => serviceCollection.AddJiraIntegration(GetConfiguration()));

        [Fact(DisplayName = "[JiraIntegrationsInjector.AddJiraIntegration] Verifica se a injeções estão corretas.")]
        public void DeveVerificarInjecao()
        {
            serviceCollection.AddJiraIntegration(GetConfiguration());

            serviceCollection.ShouldAsScoped<ISessionGet, SessionGet>();
            serviceCollection.ShouldAsScoped<IFieldGetAll, FieldGetAll>();
            serviceCollection.ShouldAsScoped<IIssueGet, IssueGet>();
            serviceCollection.ShouldAsScoped<ISearchPost, SearchPost>();
            serviceCollection.ShouldAsScoped<IIssueTypeGetAll, IssueTypeGetAll>();
            serviceCollection.ShouldAsScoped<IProjectGetAll, ProjectGetAll>();
            serviceCollection.ShouldAsScoped<IStatusCategoryGetAll, StatusCategoryGetAll>();
            serviceCollection.ShouldAsScoped<IStatusGetAll, StatusGetAll>();
        }
    }
}