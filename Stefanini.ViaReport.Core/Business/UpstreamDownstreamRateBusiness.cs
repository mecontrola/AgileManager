using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Issues;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Statuses;
using Stefanini.ViaReport.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public class UpstreamDownstreamRateBusiness : IUpstreamDownstreamRateBusiness
    {
        private readonly ICFDEasyBIExportService cfdEasyBIExportService;

        private readonly ICFDExportReportIntegrationService cfdExportReportIntegrationService;

        private readonly ICalculateGrowthToDoInProgressHelper calculateGrowthToDoInProgressHelper;
        private readonly ICalculateUpstreamDownstreamRateHelper calculateUpstreamDownstreamRateHelper;
        private readonly ISatinizeEasyBIDataHelper satinizeEasyBIDataHelper;

        private readonly IIssueGet issueGet;
        private readonly IStatusGetAll statusGetAll;

        public UpstreamDownstreamRateBusiness(ICFDEasyBIExportService cfdEasyBIExportService,
                                              ICFDExportReportIntegrationService cfdExportReportIntegrationService,
                                              ICalculateGrowthToDoInProgressHelper calculateGrowthToDoInProgressHelper,
                                              ICalculateUpstreamDownstreamRateHelper calculateUpstreamDownstreamRateHelper,
                                              ISatinizeEasyBIDataHelper satinizeEasyBIDataHelper,
                                              IIssueGet issueGet,
                                              IStatusGetAll statusGetAll)
        {
            this.cfdEasyBIExportService = cfdEasyBIExportService;
            this.cfdExportReportIntegrationService = cfdExportReportIntegrationService;
            this.calculateGrowthToDoInProgressHelper = calculateGrowthToDoInProgressHelper;
            this.calculateUpstreamDownstreamRateHelper = calculateUpstreamDownstreamRateHelper;
            this.satinizeEasyBIDataHelper = satinizeEasyBIDataHelper;
            this.issueGet = issueGet;
            this.statusGetAll = statusGetAll;
        }

        public async Task<IDictionary<EasyBIReportColumnName, IList<CFDInfoDto>>> GetPreData(string username, string password, string projects, CancellationToken cancellationToken)
        {
            var jiraStatuses = await statusGetAll.Execute(username, password, cancellationToken);

            var statuses = GroupStatuses(jiraStatuses);

            //var result = await cfdEasyBIExportService.GetReportData(username, password, projects, initDate, endDate, cancellationToken);
            var result = await cfdExportReportIntegrationService.GetData(username, password, projects, cancellationToken);
            result = await LoadChangelofIssues(username, password, result, cancellationToken);
            return satinizeEasyBIDataHelper.Execute(result, statuses);
        }

        public async Task<IList<AHMInfoDto>> GetData(string username, string password, string projects, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var values = await GetPreData(username, password, projects, cancellationToken);
            var processedValues = calculateGrowthToDoInProgressHelper.Execute(values);

            return calculateUpstreamDownstreamRateHelper.Execute(processedValues);
        }

        private async Task<SearchDto> LoadChangelofIssues(string username, string password, SearchDto result, CancellationToken cancellationToken)
        {
            var issues = new List<IssueDto>();

            foreach (var item in result.Issues)
            {
                var issue = await issueGet.Execute(username, password, item.Key, cancellationToken);

                issues.Add(issue);
            }

            return new()
            {
                MaxResults = result.MaxResults,
                StartAt = result.StartAt,
                Total = result.Total,
                Issues = issues
            };
        }

        private static IDictionary<StatusCategories, List<string>> GroupStatuses(StatusDto[] statuses)
            => statuses.GroupBy(itm => itm.StatusCategory.Id)
                       .ToDictionary(itm => (StatusCategories)itm.Key,
                                     itm => itm.Select(val => val.Id)
                                               .ToList());
    }
}