using Stefanini.ViaReport.Core.Mappers;
using Stefanini.ViaReport.Data.Dtos;
using Stefanini.ViaReport.Data.Dtos.Settings;
using Stefanini.ViaReport.Data.Enums;
using Stefanini.ViaReport.DataStorage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public class DownstreamJiraIndicatorsService : IDownstreamJiraIndicatorsService
    {
        private readonly ISettingsService settingsService;
        private readonly IProjectRepository projectRepository;
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
        private readonly IJiraIssueDtoToIssueInfoDtoMapper jiraIssueDtoToIssueInfoDtoMapper;

        public DownstreamJiraIndicatorsService(ISettingsService settingsService,
                                               IProjectRepository projectRepository,
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
                                               IJiraIssueDtoToIssueInfoDtoMapper jiraIssueDtoToIssueInfoDtoMapper)
        {
            this.settingsService = settingsService;
            this.projectRepository = projectRepository;
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
            this.jiraIssueDtoToIssueInfoDtoMapper = jiraIssueDtoToIssueInfoDtoMapper;
        }

        public async Task<DownstreamIndicatorDto> GetData(long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var settings = await settingsService.LoadDataAsync(cancellationToken);
            var project = await projectRepository.FindAsync(projectId, cancellationToken);

            if (project == null)
                return new();

            return new()
            {
                CycleBalance = await GetCycleBalance(settings.Username, settings.Password, project.Name, initDate, endDate, cancellationToken),
                Bugs = await GetBugIndicators(settings, project.Name, initDate, endDate, cancellationToken),
                TechnicalDebit = await GetTechnicalDebitIndicators(settings, project.Name, initDate, endDate, cancellationToken)
            };
        }

        private async Task<IDictionary<DownstreamIndicatorTypes, IList<ViaReport.Data.Dtos.IssueDto>>> GetBugIndicators(AppSettingsDto settings, string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => new Dictionary<DownstreamIndicatorTypes, IList<ViaReport.Data.Dtos.IssueDto>>
            {
                { DownstreamIndicatorTypes.Created, await GetBugsIssuesCreated(settings.Username, settings.Password, projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Opened, await GetBugsIssuesOpened(settings.Username, settings.Password, projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Existed, await GetBugsIssuesExisted(settings.Username, settings.Password, projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Resolved, await GetBugsIssuesResolved(settings.Username, settings.Password, projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.CreatedAndResolved, await GetBugsIssuesCreatedAndResolved(settings.Username, settings.Password, projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Cancelled, await GetBugsIssuesCancelled(settings.Username, settings.Password, projectName, initDate, endDate, cancellationToken) },
            };
        private async Task<IDictionary<DownstreamIndicatorTypes, IList<ViaReport.Data.Dtos.IssueDto>>> GetTechnicalDebitIndicators(AppSettingsDto settings, string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => new Dictionary<DownstreamIndicatorTypes, IList<ViaReport.Data.Dtos.IssueDto>>
            {
                { DownstreamIndicatorTypes.Created, await GetTechnicalDebitIssuesCreated(settings.Username, settings.Password, projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Opened, await GetTechnicalDebitIssuesOpened(settings.Username, settings.Password, projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Existed, await GetTechnicalDebitIssuesExisted(settings.Username, settings.Password, projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Resolved, await GetTechnicalDebitIssuesResolved(settings.Username, settings.Password, projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.CreatedAndResolved, await GetTechnicalDebitIssuesCreatedAndResolved(settings.Username, settings.Password, projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Cancelled, await GetTechnicalDebitIssuesCancelled(settings.Username, settings.Password, projectName, initDate, endDate, cancellationToken) },
            };

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
        private static bool IsBugOrTechnicalDebtIssue(ViaReport.Data.Dtos.Jira.IssueDto issue)
            => issue.Fields.Issuetype.Id.Equals($"{(int)IssueTypes.Bug}")
            || issue.Fields.Issuetype.Id.Equals($"{(int)IssueTypes.TechnicalDebt}");

        private static bool IsEpicIssue(ViaReport.Data.Dtos.Jira.IssueDto issue)
            => issue.Fields.Issuetype.Id.Equals($"{(int)IssueTypes.Epic}");

        private static bool IsSubTaskIssue(ViaReport.Data.Dtos.Jira.IssueDto issue)
            => issue.Fields.Issuetype.Id.Equals($"{(int)IssueTypes.SubTask}");

        private static bool IsImprovementIssue(ViaReport.Data.Dtos.Jira.IssueDto issue)
            => issue.Fields.Issuetype.Id.Equals($"{(int)IssueTypes.Improvement}");

        private async Task<IList<ViaReport.Data.Dtos.IssueDto>> GetBugsIssuesCancelled(string username, string password, string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(bugIssuesCanceledInDateRangeService, username, password, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<ViaReport.Data.Dtos.IssueDto>> GetBugsIssuesCreated(string username, string password, string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(bugIssuesCreatedInDateRangeService, username, password, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<ViaReport.Data.Dtos.IssueDto>> GetBugsIssuesCreatedAndResolved(string username, string password, string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(bugIssuesCreatedResolvedInDateRangeService, username, password, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<ViaReport.Data.Dtos.IssueDto>> GetBugsIssuesExisted(string username, string password, string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(bugIssuesExistedInDateRangeService, username, password, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<ViaReport.Data.Dtos.IssueDto>> GetBugsIssuesResolved(string username, string password, string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(bugIssuesResolvedInDateRangeService, username, password, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<ViaReport.Data.Dtos.IssueDto>> GetBugsIssuesOpened(string username, string password, string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(bugIssuesOpenedInDateRangeService, username, password, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<ViaReport.Data.Dtos.IssueDto>> GetTechnicalDebitIssuesCancelled(string username, string password, string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(technicalDebitIssuesCancelledInDateRangeService, username, password, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<ViaReport.Data.Dtos.IssueDto>> GetTechnicalDebitIssuesCreated(string username, string password, string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(technicalDebitIssuesCreatedInDateRangeService, username, password, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<ViaReport.Data.Dtos.IssueDto>> GetTechnicalDebitIssuesCreatedAndResolved(string username, string password, string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(technicalDebitIssuesCreatedAndResolvedInDateRangeService, username, password, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<ViaReport.Data.Dtos.IssueDto>> GetTechnicalDebitIssuesExisted(string username, string password, string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(technicalDebitIssuesExistedInDateRangeService, username, password, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<ViaReport.Data.Dtos.IssueDto>> GetTechnicalDebitIssuesOpened(string username, string password, string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(technicalDebitIssuesOpenedInDateRangeService, username, password, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<ViaReport.Data.Dtos.IssueDto>> GetTechnicalDebitIssuesResolved(string username, string password, string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(technicalDebitIssuesResolvedInDateRangeService, username, password, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<ViaReport.Data.Dtos.IssueDto>> GetDataFromRange(IBaseIssuesInDateRangesService service, string username, string password, string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var data = await service.GetData(username, password, projectName, initDate, endDate, cancellationToken);

            return jiraIssueDtoToIssueInfoDtoMapper.ToMapList(data.Issues);
        }
    }
}