using FluentAssertions;
using Stefanini.Core.TestingTools.FluentAssertions.Extensions;
using Stefanini.ViaReport.Core.IoC;
using Stefanini.ViaReport.Core.Services;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.IoC
{
    public class ServicesInjectorTests : BaseInjectorTests
    {
        private const int TOTAL_RECORDS = 23;

        [Fact(DisplayName = "[ServicesInjector.AddServices] Deve gerar exceção quando o serviceCollection for nulo.")]
        public void DeveGerarExcecaoQuandoServiceCollectionNulo()
            => RunServiceCollectionNull(serviceCollection => serviceCollection.AddServices());

        [Fact(DisplayName = "[ServicesInjector.AddServices] Verifica se a injeções estão corretas.")]
        public void DeveVerificarInjecao()
        {
            serviceCollection.AddServices();

            serviceCollection.Should().HaveCount(TOTAL_RECORDS);
            serviceCollection.ShouldAsScoped<IBugIncidentIssuesCreateInDateRangeService, BugIncidentIssuesCreateInDateRangeService>();
            serviceCollection.ShouldAsScoped<IBugIssuesCancelledInDateRangeService, BugIssuesCancelledInDateRangeService>();
            serviceCollection.ShouldAsScoped<IBugIssuesCreatedAndResolvedInDateRangeService, BugIssuesCreatedAndResolvedInDateRangeService>();
            serviceCollection.ShouldAsScoped<IBugIssuesCreatedInDateRangeService, BugIssuesCreatedInDateRangeService>();
            serviceCollection.ShouldAsScoped<IBugIssuesExistedInDateRangeService, BugIssuesExistedInDateRangeService>();
            serviceCollection.ShouldAsScoped<IBugIssuesOpenedInDateRangeService, BugIssuesOpenedInDateRangeService>();
            serviceCollection.ShouldAsScoped<IBugIssuesResolvedInDateRangeService, BugIssuesResolvedInDateRangeService>();
            serviceCollection.ShouldAsScoped<ICFDExportReportIntegrationService, CFDExportReportIntegrationService>();
            serviceCollection.ShouldAsScoped<IDeliveryLastCycleService, DeliveryLastCycleService>();
            serviceCollection.ShouldAsScoped<IIssuesCreatedInDateRangeService, IssuesCreatedInDateRangeService>();
            serviceCollection.ShouldAsScoped<IIssuesEpicByLabelService, IssuesEpicByLabelService>();
            serviceCollection.ShouldAsScoped<IIssuesNotFixVersionService, IssuesNotFixVersionService>();
            serviceCollection.ShouldAsScoped<IIssuesResolvedInDateRangeService, IssuesResolvedInDateRangeService>();
            serviceCollection.ShouldAsScoped<IJiraAuthService, JiraAuthService>();
            serviceCollection.ShouldAsScoped<IJiraProjectsService, JiraProjectsService>();
            serviceCollection.ShouldAsScoped<IStatusDoneService, StatusDoneService>();
            serviceCollection.ShouldAsScoped<IStatusInProgressService, StatusInProgressService>();
            serviceCollection.ShouldAsScoped<ITechnicalDebitIssuesCancelledInDateRangeService, TechnicalDebitIssuesCancelledInDateRangeService>();
            serviceCollection.ShouldAsScoped<ITechnicalDebitIssuesCreatedAndResolvedInDateRangeService, TechnicalDebitIssuesCreatedAndResolvedInDateRangeService>();
            serviceCollection.ShouldAsScoped<ITechnicalDebitIssuesCreatedInDateRangeService, TechnicalDebitIssuesCreatedInDateRangeService>();
            serviceCollection.ShouldAsScoped<ITechnicalDebitIssuesExistedInDateRangeService, TechnicalDebitIssuesExistedInDateRangeService>();
            serviceCollection.ShouldAsScoped<ITechnicalDebitIssuesOpenedInDateRangeService, TechnicalDebitIssuesOpenedInDateRangeService>();
            serviceCollection.ShouldAsScoped<ITechnicalDebitIssuesResolvedInDateRangeService, TechnicalDebitIssuesResolvedInDateRangeService>();
        }
    }
}