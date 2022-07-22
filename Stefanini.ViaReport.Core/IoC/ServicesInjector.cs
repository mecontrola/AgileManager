using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Services.Synchronizers;
using Stefanini.ViaReport.Core.Services.Synchronizers.ExtraIssueData;
using System;

namespace Stefanini.ViaReport.Core.IoC
{
    public static class ServicesInjector
    {
        public static void AddServices(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.TryAddScoped<IBugIncidentIssuesCreateInDateRangeService, BugIncidentIssuesCreateInDateRangeService>();
            services.TryAddScoped<IBugIssuesCancelledInDateRangeService, BugIssuesCancelledInDateRangeService>();
            services.TryAddScoped<IBugIssuesCreatedAndResolvedInDateRangeService, BugIssuesCreatedAndResolvedInDateRangeService>();
            services.TryAddScoped<IBugIssuesCreatedInDateRangeService, BugIssuesCreatedInDateRangeService>();
            services.TryAddScoped<IBugIssuesExistedInDateRangeService, BugIssuesExistedInDateRangeService>();
            services.TryAddScoped<IBugIssuesOpenedInDateRangeService, BugIssuesOpenedInDateRangeService>();
            services.TryAddScoped<IBugIssuesResolvedInDateRangeService, BugIssuesResolvedInDateRangeService>();
            services.TryAddScoped<ICFDExportReportIntegrationService, CFDExportReportIntegrationService>();
            services.TryAddScoped<IDeliveryLastCycleService, DeliveryLastCycleService>();
            services.TryAddScoped<IDownstreamIndicatorsService, DownstreamIndicatorsService>();
            services.TryAddScoped<IDownstreamJiraIndicatorsService, DownstreamJiraIndicatorsService>();
            services.TryAddScoped<IIssuesCreatedInDateRangeService, IssuesCreatedInDateRangeService>();
            services.TryAddScoped<IIssuesEpicByLabelService, IssuesEpicByLabelService>();
            services.TryAddScoped<IIssuesNotFixVersionService, IssuesNotFixVersionService>();
            services.TryAddScoped<IIssuesResolvedInDateRangeService, IssuesResolvedInDateRangeService>();
            services.TryAddScoped<IJiraAuthService, JiraAuthService>();
            services.TryAddScoped<IProjectService, ProjectService>();
            services.TryAddScoped<IQuarterService, QuarterService>();
            services.TryAddScoped<ISettingsService, SettingsService>();
            services.TryAddScoped<ISynchronizerService, SynchronizerService>();
            services.TryAddScoped<IStatusDoneService, StatusDoneService>();
            services.TryAddScoped<IStatusInProgressService, StatusInProgressService>();
            services.TryAddScoped<ITechnicalDebitIssuesCancelledInDateRangeService, TechnicalDebitIssuesCancelledInDateRangeService>();
            services.TryAddScoped<ITechnicalDebitIssuesCreatedAndResolvedInDateRangeService, TechnicalDebitIssuesCreatedAndResolvedInDateRangeService>();
            services.TryAddScoped<ITechnicalDebitIssuesCreatedInDateRangeService, TechnicalDebitIssuesCreatedInDateRangeService>();
            services.TryAddScoped<ITechnicalDebitIssuesExistedInDateRangeService, TechnicalDebitIssuesExistedInDateRangeService>();
            services.TryAddScoped<ITechnicalDebitIssuesOpenedInDateRangeService, TechnicalDebitIssuesOpenedInDateRangeService>();
            services.TryAddScoped<ITechnicalDebitIssuesResolvedInDateRangeService, TechnicalDebitIssuesResolvedInDateRangeService>();

            AddSyncronizerServices(services);
        }

        private static void AddSyncronizerServices(IServiceCollection services)
        {
            services.TryAddScoped<IIssueDataSynchronizerService, IssueDataSynchronizerService>();
            services.TryAddScoped<IIssueEpicDataSynchronizerService, IssueEpicDataSynchronizerService>();
            services.TryAddScoped<IIssueImpedimentSynchronizerService, IssueImpedimentSynchronizerService>();
            services.TryAddScoped<IIssueStatusHistorySynchronizerService, IssueStatusHistorySynchronizerService>();

            services.TryAddScoped<IIssueSynchronizerService, IssueSynchronizerService>();
            services.TryAddScoped<IIssueTypeSynchronizerService, IssueTypeSynchronizerService>();
            services.TryAddScoped<IProjectSynchronizerService, ProjectSynchronizerService>();
            services.TryAddScoped<IStatusCategorySynchronizerService, StatusCategorySynchronizerService>();
            services.TryAddScoped<IStatusSynchronizerService, StatusSynchronizerService>();

            services.TryAddScoped<ISynchronizerService, SynchronizerService>();
        }
    }
}