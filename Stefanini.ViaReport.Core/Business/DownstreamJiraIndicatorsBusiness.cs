using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Dtos.Jira;
using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Core.Mappers;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Data.Dtos.Jira;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public class DownstreamJiraIndicatorsBusiness : IDownstreamJiraIndicatorsBusiness
    {
        private readonly ISettingsService settingsService;
        private readonly IBugIssuesCancelledInDateRangeService bugIssuesCanceledInDateRangeService;
        private readonly IBugIssuesCreatedInDateRangeService bugIssuesCreatedInDateRangeService;
        private readonly IBugIssuesCreatedAndResolvedInDateRangeService bugIssuesCreatedResolvedInDateRangeService;
        private readonly IBugIssuesExistedInDateRangeService bugIssuesExistedInDateRangeService;
        private readonly IBugIssuesOpenedInDateRangeService bugIssuesOpenedInDateRangeService;
        private readonly IBugIssuesResolvedInDateRangeService bugIssuesResolvedInDateRangeService;
        private readonly IBugIncidentIssuesCreateInDateRangeService bugIncidentIssuesCreateInDateRangeService;
        private readonly IIssuesCreatedInDateRangeService issuesCreatedInDateRangeService;
        private readonly ITechnicalDebitIssuesCancelledInDateRangeService technicalDebitIssuesCancelledInDateRangeService;
        private readonly ITechnicalDebitIssuesCreatedAndResolvedInDateRangeService technicalDebitIssuesCreatedAndResolvedInDateRangeService;
        private readonly ITechnicalDebitIssuesCreatedInDateRangeService technicalDebitIssuesCreatedInDateRangeService;
        private readonly ITechnicalDebitIssuesExistedInDateRangeService technicalDebitIssuesExistedInDateRangeService;
        private readonly ITechnicalDebitIssuesOpenedInDateRangeService technicalDebitIssuesOpenedInDateRangeService;
        private readonly ITechnicalDebitIssuesResolvedInDateRangeService technicalDebitIssuesResolvedInDateRangeService;
        private readonly IIssueDtoToIssueInfoDtoMapper issueDtoToIssueInfoDtoMapper;

        public DownstreamJiraIndicatorsBusiness(ISettingsService settingsService,
                                                IBugIssuesCancelledInDateRangeService bugIssuesCanceledInDateRangeService,
                                                IBugIssuesCreatedInDateRangeService bugIssuesCreatedInDateRangeService,
                                                IBugIssuesCreatedAndResolvedInDateRangeService bugIssuesCreatedResolvedInDateRangeService,
                                                IBugIssuesExistedInDateRangeService bugIssuesExistedInDateRangeService,
                                                IBugIssuesOpenedInDateRangeService bugIssuesOpenedInDateRangeService,
                                                IBugIssuesResolvedInDateRangeService bugIssuesResolvedInDateRangeService,
                                                IBugIncidentIssuesCreateInDateRangeService bugIncidentIssuesCreateInDateRangeService,
                                                IIssuesCreatedInDateRangeService issuesCreatedInDateRangeService,
                                                ITechnicalDebitIssuesCancelledInDateRangeService technicalDebitIssuesCancelledInDateRangeService,
                                                ITechnicalDebitIssuesCreatedAndResolvedInDateRangeService technicalDebitIssuesCreatedAndResolvedInDateRangeService,
                                                ITechnicalDebitIssuesCreatedInDateRangeService technicalDebitIssuesCreatedInDateRangeService,
                                                ITechnicalDebitIssuesExistedInDateRangeService technicalDebitIssuesExistedInDateRangeService,
                                                ITechnicalDebitIssuesOpenedInDateRangeService technicalDebitIssuesOpenedInDateRangeService,
                                                ITechnicalDebitIssuesResolvedInDateRangeService technicalDebitIssuesResolvedInDateRangeService,
                                                IIssueDtoToIssueInfoDtoMapper issueDtoToIssueInfoDtoMapper)
        {
            this.settingsService = settingsService;
            this.bugIssuesCanceledInDateRangeService = bugIssuesCanceledInDateRangeService;
            this.bugIssuesCreatedInDateRangeService = bugIssuesCreatedInDateRangeService;
            this.bugIssuesCreatedResolvedInDateRangeService = bugIssuesCreatedResolvedInDateRangeService;
            this.bugIssuesExistedInDateRangeService = bugIssuesExistedInDateRangeService;
            this.bugIssuesOpenedInDateRangeService = bugIssuesOpenedInDateRangeService;
            this.bugIssuesResolvedInDateRangeService = bugIssuesResolvedInDateRangeService;
            this.bugIncidentIssuesCreateInDateRangeService = bugIncidentIssuesCreateInDateRangeService;
            this.issuesCreatedInDateRangeService = issuesCreatedInDateRangeService;
            this.technicalDebitIssuesCancelledInDateRangeService = technicalDebitIssuesCancelledInDateRangeService;
            this.technicalDebitIssuesCreatedAndResolvedInDateRangeService = technicalDebitIssuesCreatedAndResolvedInDateRangeService;
            this.technicalDebitIssuesCreatedInDateRangeService = technicalDebitIssuesCreatedInDateRangeService;
            this.technicalDebitIssuesExistedInDateRangeService = technicalDebitIssuesExistedInDateRangeService;
            this.technicalDebitIssuesOpenedInDateRangeService = technicalDebitIssuesOpenedInDateRangeService;
            this.technicalDebitIssuesResolvedInDateRangeService = technicalDebitIssuesResolvedInDateRangeService;
            this.issueDtoToIssueInfoDtoMapper = issueDtoToIssueInfoDtoMapper;
        }

        public async Task<DownstreamJiraIndicatorsDto> GetData(string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var settings = await settingsService.LoadDataAsync(cancellationToken);

            return new()
            {
                CycleBalance = await GetCycleBalance(settings.Username, settings.Password, project, initDate, endDate, cancellationToken),
                BugsCancelled = await GetBugsIssuesCancelled(settings.Username, settings.Password, project, initDate, endDate, cancellationToken),
                BugsCreated = await GetBugsIssuesCreated(settings.Username, settings.Password, project, initDate, endDate, cancellationToken),
                BugsCreatedAndResolved = await GetBugsIssuesCreatedAndResolved(settings.Username, settings.Password, project, initDate, endDate, cancellationToken),
                BugsExisted = await GetBugsIssuesExisted(settings.Username, settings.Password, project, initDate, endDate, cancellationToken),
                BugsOpened = await GetBugsIssuesOpened(settings.Username, settings.Password, project, initDate, endDate, cancellationToken),
                BugsResolved = await GetBugsIssuesResolved(settings.Username, settings.Password, project, initDate, endDate, cancellationToken),
                TechnicalDebitCancelled = await GetTechnicalDebitIssuesCancelled(settings.Username, settings.Password, project, initDate, endDate, cancellationToken),
                TechnicalDebitCreated = await GetTechnicalDebitIssuesCreated(settings.Username, settings.Password, project, initDate, endDate, cancellationToken),
                TechnicalDebitCreatedAndResolved = await GetTechnicalDebitIssuesCreatedAndResolved(settings.Username, settings.Password, project, initDate, endDate, cancellationToken),
                TechnicalDebitExisted = await GetTechnicalDebitIssuesExisted(settings.Username, settings.Password, project, initDate, endDate, cancellationToken),
                TechnicalDebitOpened = await GetTechnicalDebitIssuesOpened(settings.Username, settings.Password, project, initDate, endDate, cancellationToken),
                TechnicalDebitResolved = await GetTechnicalDebitIssuesResolved(settings.Username, settings.Password, project, initDate, endDate, cancellationToken)
            };
        }

        private async Task<decimal> GetCycleBalance(string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var data = await issuesCreatedInDateRangeService.GetData(username, password, project, initDate, endDate, cancellationToken);
            var issues = data.Issues.Where(itm => !IsEpicIssue(itm)
                                               && !IsSubTaskIssue(itm)
                                               && !IsImprovementIssue(itm));

            var totalNewWork = issues.Count(itm => !IsBugOrTechnicalDebtIssue(itm));
            var percent = issues.Any()
                        ? ((double)totalNewWork / issues.Count()) * 100
                        : 0;
            return (decimal)Math.Round(percent, 2);
        }

        private static bool IsBugOrTechnicalDebtIssue(IssueDto issue)
            => issue.Fields.Issuetype.Id.Equals($"{(int)IssueTypes.Bug}")
            || issue.Fields.Issuetype.Id.Equals($"{(int)IssueTypes.TechnicalDebt}");

        private static bool IsEpicIssue(IssueDto issue)
            => issue.Fields.Issuetype.Id.Equals($"{(int)IssueTypes.Epic}");

        private static bool IsSubTaskIssue(IssueDto issue)
            => issue.Fields.Issuetype.Id.Equals($"{(int)IssueTypes.SubTask}");

        private static bool IsImprovementIssue(IssueDto issue)
            => issue.Fields.Issuetype.Id.Equals($"{(int)IssueTypes.Improvement}");

        private async Task<IssueInfoListDto> GetBugsIssuesCancelled(string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(bugIssuesCanceledInDateRangeService, username, password, project, initDate, endDate, cancellationToken);

        private async Task<IssueInfoListDto> GetBugsIssuesCreated(string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(bugIssuesCreatedInDateRangeService, username, password, project, initDate, endDate, cancellationToken);

        private async Task<IssueInfoListDto> GetBugsIssuesCreatedAndResolved(string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(bugIssuesCreatedResolvedInDateRangeService, username, password, project, initDate, endDate, cancellationToken);

        private async Task<IssueInfoListDto> GetBugsIssuesExisted(string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(bugIssuesExistedInDateRangeService, username, password, project, initDate, endDate, cancellationToken);

        private async Task<IssueInfoListDto> GetBugsIssuesResolved(string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(bugIssuesResolvedInDateRangeService, username, password, project, initDate, endDate, cancellationToken);

        private async Task<IssueInfoListDto> GetBugsIssuesOpened(string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(bugIssuesOpenedInDateRangeService, username, password, project, initDate, endDate, cancellationToken);

        private async Task<IssueInfoListDto> GetTechnicalDebitIssuesCancelled(string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(technicalDebitIssuesCancelledInDateRangeService, username, password, project, initDate, endDate, cancellationToken);

        private async Task<IssueInfoListDto> GetTechnicalDebitIssuesCreated(string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(technicalDebitIssuesCreatedInDateRangeService, username, password, project, initDate, endDate, cancellationToken);

        private async Task<IssueInfoListDto> GetTechnicalDebitIssuesCreatedAndResolved(string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(technicalDebitIssuesCreatedAndResolvedInDateRangeService, username, password, project, initDate, endDate, cancellationToken);

        private async Task<IssueInfoListDto> GetTechnicalDebitIssuesExisted(string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(technicalDebitIssuesExistedInDateRangeService, username, password, project, initDate, endDate, cancellationToken);

        private async Task<IssueInfoListDto> GetTechnicalDebitIssuesOpened(string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(technicalDebitIssuesOpenedInDateRangeService, username, password, project, initDate, endDate, cancellationToken);

        private async Task<IssueInfoListDto> GetTechnicalDebitIssuesResolved(string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(technicalDebitIssuesResolvedInDateRangeService, username, password, project, initDate, endDate, cancellationToken);

        private async Task<IssueInfoListDto> GetDataFromRange(IBaseIssuesInDateRangesService service, string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var data = await service.GetData(username, password, project, initDate, endDate, cancellationToken);
            return new()
            {
                Total = data.Total,
                Data = issueDtoToIssueInfoDtoMapper.ToMapList(data.Issues)
            };
        }
    }
}