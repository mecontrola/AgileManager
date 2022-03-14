using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Stefanini.ViaReport.Core.Services;
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
            services.TryAddScoped<ICFDEasyBIExportService, CFDEasyBIExportService>();
            services.TryAddScoped<ICFDExportReportIntegrationService, CFDExportReportIntegrationService>();
            //services.TryAddScoped<ICFDReportSanitizeDataService, CFDReportSanitizeDataService>();
            services.TryAddScoped<IDeliveryLastCycleService, DeliveryLastCycleService>();
            services.TryAddScoped<IIssuesCreatedInDateRangeService, IssuesCreatedInDateRangeService>();
            services.TryAddScoped<IIssuesEpicByLabelService, IssuesEpicByLabelService>();
            services.TryAddScoped<IIssuesNotFixVersionService, IssuesNotFixVersionService>();
            services.TryAddScoped<IIssuesResolvedInDateRangeService, IssuesResolvedInDateRangeService>();
            services.TryAddScoped<IJiraAuthService, JiraAuthService>();
            services.TryAddScoped<IJiraProjectsService, JiraProjectsService>();
            services.TryAddScoped<IStatusDoneService, StatusDoneService>();
            services.TryAddScoped<IStatusInProgressService, StatusInProgressService>();
            services.TryAddScoped<ITechnicalDebitIssuesCancelledInDateRangeService, TechnicalDebitIssuesCancelledInDateRangeService>();
            services.TryAddScoped<ITechnicalDebitIssuesCreatedAndResolvedInDateRangeService, TechnicalDebitIssuesCreatedAndResolvedInDateRangeService>();
            services.TryAddScoped<ITechnicalDebitIssuesCreatedInDateRangeService, TechnicalDebitIssuesCreatedInDateRangeService>();
            services.TryAddScoped<ITechnicalDebitIssuesExistedInDateRangeService, TechnicalDebitIssuesExistedInDateRangeService>();
            services.TryAddScoped<ITechnicalDebitIssuesOpenedInDateRangeService, TechnicalDebitIssuesOpenedInDateRangeService>();
            services.TryAddScoped<ITechnicalDebitIssuesResolvedInDateRangeService, TechnicalDebitIssuesResolvedInDateRangeService>();
        }
    }
}