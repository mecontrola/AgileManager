using FluentAssertions;
using MeControla.AgileManager.TestingTools.FluentAssertions.Extensions;
using MeControla.AgileManager.Core.Integrations.Jira.V1.Auth;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Issues;
using MeControla.AgileManager.Core.Integrations.Jira.V2.IssueTypes;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Projects;
using MeControla.AgileManager.Core.Integrations.Jira.V2.StatusCategories;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Statuses;
using MeControla.AgileManager.Core.IoC;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.IoC
{
    public class IntegrationsInjectorTests : BaseInjectorTests
    {
        private const int TOTAL_RECORDS = 7;

        [Fact(DisplayName = "[IntegrationsInjector.AddMappers] Deve gerar exceção quando o serviceCollection for nulo.")]
        public void DeveGerarExcecaoQuandoServiceCollectionNulo()
            => RunServiceCollectionNull(serviceCollection => serviceCollection.AddIntegrations());

        [Fact(DisplayName = "[IntegrationsInjector.AddMappers] Verifica se a injeções estão corretas.")]
        public void DeveVerificarInjecao()
        {
            serviceCollection.AddIntegrations();

            serviceCollection.Should().HaveCount(TOTAL_RECORDS);
            serviceCollection.ShouldAsScoped<ISessionGet, SessionGet>();
            serviceCollection.ShouldAsScoped<IProjectGetAll, ProjectGetAll>();
            serviceCollection.ShouldAsScoped<ISearchPost, SearchPost>();
            serviceCollection.ShouldAsScoped<IIssueGet, IssueGet>();
            serviceCollection.ShouldAsScoped<IIssueTypeGetAll, IssueTypeGetAll>();
            serviceCollection.ShouldAsScoped<IStatusGetAll, StatusGetAll>();
            serviceCollection.ShouldAsScoped<IStatusCategoryGetAll, StatusCategoryGetAll>();
        }
    }
}