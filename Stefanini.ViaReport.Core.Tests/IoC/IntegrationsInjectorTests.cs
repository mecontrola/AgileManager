using FluentAssertions;
using Stefanini.ViaReport.Core.Integrations.Jira.V1.Auth;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Issues;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Statuses;
using Stefanini.ViaReport.Core.IoC;
using Stefanini.ViaReport.Core.Tests.TestUtils.FluentAssertions.Extensions;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.IoC
{
    public class IntegrationsInjectorTests : BaseInjectorTests
    {
        private const int TOTAL_RECORDS = 5;

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
            serviceCollection.ShouldAsScoped<IStatusGetAll, StatusGetAll>();
        }
    }
}