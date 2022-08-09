using FluentAssertions;
using MeControla.AgileManager.TestingTools.FluentAssertions.Extensions;
using MeControla.AgileManager.Core.IoC;
using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Services.Synchronizers;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.IoC
{
    public class ServicesInjectorTests : BaseInjectorTests
    {
        private const int TOTAL_RECORDS = 37;

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
            serviceCollection.ShouldAsScoped<IDownstreamIndicatorsService, DownstreamIndicatorsService>();
            serviceCollection.ShouldAsScoped<IDownstreamJiraIndicatorsService, DownstreamJiraIndicatorsService>();
            serviceCollection.ShouldAsScoped<IIssuesCreatedInDateRangeService, IssuesCreatedInDateRangeService>();
            serviceCollection.ShouldAsScoped<IIssuesEpicByLabelService, IssuesEpicByLabelService>();
            serviceCollection.ShouldAsScoped<IIssuesNotFixVersionService, IssuesNotFixVersionService>();
            serviceCollection.ShouldAsScoped<IIssuesResolvedInDateRangeService, IssuesResolvedInDateRangeService>();
            serviceCollection.ShouldAsScoped<IJiraAuthService, JiraAuthService>();
            serviceCollection.ShouldAsScoped<IProjectService, ProjectService>();
            serviceCollection.ShouldAsScoped<IQuarterService, QuarterService>();
            serviceCollection.ShouldAsScoped<ISettingsService, SettingsService>();
            serviceCollection.ShouldAsScoped<ISynchronizerService, SynchronizerService>();
            serviceCollection.ShouldAsScoped<IStatusDoneService, StatusDoneService>();
            serviceCollection.ShouldAsScoped<IStatusInProgressService, StatusInProgressService>();
            serviceCollection.ShouldAsScoped<ITechnicalDebitIssuesCancelledInDateRangeService, TechnicalDebitIssuesCancelledInDateRangeService>();
            serviceCollection.ShouldAsScoped<ITechnicalDebitIssuesCreatedAndResolvedInDateRangeService, TechnicalDebitIssuesCreatedAndResolvedInDateRangeService>();
            serviceCollection.ShouldAsScoped<ITechnicalDebitIssuesCreatedInDateRangeService, TechnicalDebitIssuesCreatedInDateRangeService>();
            serviceCollection.ShouldAsScoped<ITechnicalDebitIssuesExistedInDateRangeService, TechnicalDebitIssuesExistedInDateRangeService>();
            serviceCollection.ShouldAsScoped<ITechnicalDebitIssuesOpenedInDateRangeService, TechnicalDebitIssuesOpenedInDateRangeService>();
            serviceCollection.ShouldAsScoped<ITechnicalDebitIssuesResolvedInDateRangeService, TechnicalDebitIssuesResolvedInDateRangeService>();
            serviceCollection.ShouldAsScoped<IIssueSynchronizerService, IssueSynchronizerService>();

            serviceCollection.ShouldAsScoped<IIssueSynchronizerService, IssueSynchronizerService>();
            serviceCollection.ShouldAsScoped<IIssueTypeSynchronizerService, IssueTypeSynchronizerService>();
            serviceCollection.ShouldAsScoped<IProjectSynchronizerService, ProjectSynchronizerService>();
            serviceCollection.ShouldAsScoped<IStatusCategorySynchronizerService, StatusCategorySynchronizerService>();
            serviceCollection.ShouldAsScoped<IStatusSynchronizerService, StatusSynchronizerService>();

            serviceCollection.ShouldAsScoped<ISynchronizerService, SynchronizerService>();
        }
    }
}