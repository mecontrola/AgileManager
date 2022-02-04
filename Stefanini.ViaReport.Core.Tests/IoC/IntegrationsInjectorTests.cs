using FluentAssertions;
using Stefanini.ViaReport.Core.Integrations.Jira.EasyBI;
using Stefanini.ViaReport.Core.Integrations.Jira.V1.Auth;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Issues;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Statuses;
using Stefanini.ViaReport.Core.IoC;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.TestUtils.FluentAssertions.Extensions;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.IoC
{
    public class IntegrationsInjectorTests : BaseInjectorTests
    {
        private const int TOTAL_RECORDS = 6;

        [Fact(DisplayName = "[IntegrationsInjector.AddMappers] Deve gerar exceção quando o serviceCollection for nulo.")]
        public void DeveGerarExcecaoQuandoServiceCollectionNulo()
            => RunServiceCollectionNull(serviceCollection => serviceCollection.AddIntegrations());

        [Fact(DisplayName = "[IntegrationsInjector.AddMappers] Verifica se a injeções estão corretas.")]
        public void DeveVerificarInjecao()
        {
            serviceCollection.AddIntegrations();

            serviceCollection.Should().HaveCount(TOTAL_RECORDS);
            serviceCollection.Should().HaveService<ICFDExportReportIntegration>().WithImplementation<CFDExportReportIntegration>().AsScoped();
            serviceCollection.Should().HaveService<ISessionGet>().WithImplementation<SessionGet>().AsScoped();
            serviceCollection.Should().HaveService<IProjectGetAll>().WithImplementation<ProjectGetAll>().AsScoped();
            serviceCollection.Should().HaveService<ISearchPost>().WithImplementation<SearchPost>().AsScoped();
            serviceCollection.Should().HaveService<IIssueGet>().WithImplementation<IssueGet>().AsScoped();
            serviceCollection.Should().HaveService<IStatusGetAll>().WithImplementation<StatusGetAll>().AsScoped();
        }
    }
}