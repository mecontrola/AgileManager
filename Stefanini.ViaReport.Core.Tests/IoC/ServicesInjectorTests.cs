using FluentAssertions;
using Stefanini.ViaReport.Core.IoC;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.TestUtils.FluentAssertions.Extensions;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.IoC
{
    public class ServicesInjectorTests : BaseInjectorTests
    {
        private const int TOTAL_RECORDS = 21;

        [Fact(DisplayName = "[ServicesInjector.AddServices] Deve gerar exceção quando o serviceCollection for nulo.")]
        public void DeveGerarExcecaoQuandoServiceCollectionNulo()
            => RunServiceCollectionNull(serviceCollection => serviceCollection.AddServices());

        [Fact(DisplayName = "[ServicesInjector.AddServices] Verifica se a injeções estão corretas.")]
        public void DeveVerificarInjecao()
        {
            serviceCollection.AddServices();

            serviceCollection.Should().HaveCount(TOTAL_RECORDS);
            serviceCollection.Should().HaveService<IBugIncidentIssuesCreateInDateRangeService>().WithImplementation<BugIncidentIssuesCreateInDateRangeService>().AsScoped();
            serviceCollection.Should().HaveService<IBugIssuesCancelledInDateRangeService>().WithImplementation<BugIssuesCancelledInDateRangeService>().AsScoped();
            serviceCollection.Should().HaveService<IBugIssuesCreatedAndResolvedInDateRangeService>().WithImplementation<BugIssuesCreatedAndResolvedInDateRangeService>().AsScoped();
            serviceCollection.Should().HaveService<IBugIssuesCreatedInDateRangeService>().WithImplementation<BugIssuesCreatedInDateRangeService>().AsScoped();
            serviceCollection.Should().HaveService<IBugIssuesExistedInDateRangeService>().WithImplementation<BugIssuesExistedInDateRangeService>().AsScoped();
            serviceCollection.Should().HaveService<IBugIssuesOpenedInDateRangeService>().WithImplementation<BugIssuesOpenedInDateRangeService>().AsScoped();
            serviceCollection.Should().HaveService<IBugIssuesResolvedInDateRangeService>().WithImplementation<BugIssuesResolvedInDateRangeService>().AsScoped();
            serviceCollection.Should().HaveService<ICFDEasyBIExportService>().WithImplementation<CFDEasyBIExportService>().AsScoped();
            serviceCollection.Should().HaveService<ICFDExportReportIntegrationService>().WithImplementation<CFDExportReportIntegrationService>().AsScoped();
            //serviceCollection.Should().HaveService<ICFDReportSanitizeDataService>().WithImplementation<CFDReportSanitizeDataService>().AsScoped();
            serviceCollection.Should().HaveService<IIssuesCreatedInDateRangeService>().WithImplementation<IssuesCreatedInDateRangeService>().AsScoped();
            serviceCollection.Should().HaveService<IIssuesEpicByLabelService>().WithImplementation<IssuesEpicByLabelService>().AsScoped();
            serviceCollection.Should().HaveService<IIssuesNotFixVersionService>().WithImplementation<IssuesNotFixVersionService>().AsScoped();
            serviceCollection.Should().HaveService<IIssuesResolvedInDateRangeService>().WithImplementation<IssuesResolvedInDateRangeService>().AsScoped();
            serviceCollection.Should().HaveService<IJiraAuthService>().WithImplementation<JiraAuthService>().AsScoped();
            serviceCollection.Should().HaveService<IJiraProjectsService>().WithImplementation<JiraProjectsService>().AsScoped();
            serviceCollection.Should().HaveService<ITechnicalDebitIssuesCancelledInDateRangeService>().WithImplementation<TechnicalDebitIssuesCancelledInDateRangeService>().AsScoped();
            serviceCollection.Should().HaveService<ITechnicalDebitIssuesCreatedAndResolvedInDateRangeService>().WithImplementation<TechnicalDebitIssuesCreatedAndResolvedInDateRangeService>().AsScoped();
            serviceCollection.Should().HaveService<ITechnicalDebitIssuesCreatedInDateRangeService>().WithImplementation<TechnicalDebitIssuesCreatedInDateRangeService>().AsScoped();
            serviceCollection.Should().HaveService<ITechnicalDebitIssuesExistedInDateRangeService>().WithImplementation<TechnicalDebitIssuesExistedInDateRangeService>().AsScoped();
            serviceCollection.Should().HaveService<ITechnicalDebitIssuesOpenedInDateRangeService>().WithImplementation<TechnicalDebitIssuesOpenedInDateRangeService>().AsScoped();
            serviceCollection.Should().HaveService<ITechnicalDebitIssuesResolvedInDateRangeService>().WithImplementation<TechnicalDebitIssuesResolvedInDateRangeService>().AsScoped();
        }
    }
}