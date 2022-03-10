using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public class DeliveryLastCycleService : IDeliveryLastCycleService
    {
        private readonly IIssuesResolvedInDateRangeService issuesResolvedInDateRangeService;
        private readonly IStatusDoneService statusDoneService;
        private readonly IStatusInProgressService statusInProgressService;
        private readonly IBusinessDayHelper businessDayHelper;
        private readonly IRecoverDateTimeFirstStatusMatchBacklogHelper recoverDateTimeFirstStatusMatchBacklogHelper;
        private readonly IIssueGet issueGet;

        public DeliveryLastCycleService(IIssuesResolvedInDateRangeService issuesResolvedInDateRangeService,
                                        IStatusDoneService statusDoneService,
                                        IStatusInProgressService statusInProgressService,
                                        IBusinessDayHelper businessDayHelper,
                                        IRecoverDateTimeFirstStatusMatchBacklogHelper recoverDateTimeFirstStatusMatchBacklogHelper,
                                        IIssueGet issueGet)
        {
            this.issuesResolvedInDateRangeService = issuesResolvedInDateRangeService;
            this.statusDoneService = statusDoneService;
            this.statusInProgressService = statusInProgressService;
            this.businessDayHelper = businessDayHelper;
            this.recoverDateTimeFirstStatusMatchBacklogHelper = recoverDateTimeFirstStatusMatchBacklogHelper;
            this.issueGet = issueGet;
        }

        public async Task<DeliveryLastCycleDto> GetData(string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var statusInProgress = await statusInProgressService.GetList(username, password, cancellationToken);
            var statusDone = await statusDoneService.GetList(username, password, cancellationToken);
            var search = await issuesResolvedInDateRangeService.GetData(username, password, project, initDate, endDate, cancellationToken);
            var issues = new List<DeliveryLastCycleIssueDto>();
            var statusInProgressList = statusInProgress.Select(x => x.Key).ToList();
            var statusDoneList = statusDone.Select(x => x.Key).ToList();

            foreach (var issue in search.Issues)
            {
                var issueBacklog = await GetBacklogData(username, password, issue.Key, cancellationToken);

                issues.Add(CreateIssueInfo(issueBacklog, statusInProgressList, statusDoneList));
            }

            return new()
            {
                StartDate = initDate,
                EndDate = endDate,
                Throughtput = issues.Count,
                LeadTimeAverage = issues.Sum(x => x.LeadTime) / issues.Count,
                Issues = issues
            };
        }

        private async Task<IssueDto> GetBacklogData(string username, string password, string issueKey, CancellationToken cancellationToken)
            => await issueGet.Execute(username, password, issueKey, cancellationToken);

        private DeliveryLastCycleIssueDto CreateIssueInfo(IssueDto issue, IList<string> statusInProgress, IList<string> statusDone)
            => new()
            {
                Key = issue.Key,
                Description = issue.Fields.Summary,
                LeadTime = CalculateLeadTime(issue.Changelog, statusInProgress, statusDone)
            };

        private decimal CalculateLeadTime(ChangelogDto changelog, IList<string> statusInProgress, IList<string> statusDone)
        {
            var dateInProgress = recoverDateTimeFirstStatusMatchBacklogHelper.GetDateTime(changelog, statusInProgress);
            var dateDone = recoverDateTimeFirstStatusMatchBacklogHelper.GetDateTime(changelog, statusDone);
            var total = businessDayHelper.Diff(dateInProgress.Value, dateDone.Value);
            return Math.Round(total) - 1;
        }
    }
}