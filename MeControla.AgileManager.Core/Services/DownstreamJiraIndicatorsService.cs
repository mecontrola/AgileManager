using MeControla.AgileManager.Core.Mappers;
using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.DataStorage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
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
                CycleBalance = await GetCycleBalance(project.Name, initDate, endDate, cancellationToken),
                Bugs = await GetBugIndicators(project.Name, initDate, endDate, cancellationToken),
                TechnicalDebit = await GetTechnicalDebitIndicators(project.Name, initDate, endDate, cancellationToken)
            };
        }

        private async Task<IDictionary<DownstreamIndicatorTypes, IList<IssueDto>>> GetBugIndicators(string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => new Dictionary<DownstreamIndicatorTypes, IList<IssueDto>>
            {
                { DownstreamIndicatorTypes.Created, await GetBugsIssuesCreated(projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Opened, await GetBugsIssuesOpened(projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Existed, await GetBugsIssuesExisted(projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Resolved, await GetBugsIssuesResolved(projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.CreatedAndResolved, await GetBugsIssuesCreatedAndResolved(projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Cancelled, await GetBugsIssuesCancelled(projectName, initDate, endDate, cancellationToken) },
            };
        private async Task<IDictionary<DownstreamIndicatorTypes, IList<IssueDto>>> GetTechnicalDebitIndicators(string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => new Dictionary<DownstreamIndicatorTypes, IList<IssueDto>>
            {
                { DownstreamIndicatorTypes.Created, await GetTechnicalDebitIssuesCreated(projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Opened, await GetTechnicalDebitIssuesOpened( projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Existed, await GetTechnicalDebitIssuesExisted( projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Resolved, await GetTechnicalDebitIssuesResolved( projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.CreatedAndResolved, await GetTechnicalDebitIssuesCreatedAndResolved( projectName, initDate, endDate, cancellationToken) },
                { DownstreamIndicatorTypes.Cancelled, await GetTechnicalDebitIssuesCancelled( projectName, initDate, endDate, cancellationToken) },
            };

        private async Task<decimal> GetCycleBalance(string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var data = await issuesCreatedInDateRangeService.GetData(project, initDate, endDate, cancellationToken);
            var issues = data.Issues.Where(itm => !IsEpicIssue(itm)
                                               && !IsSubTaskIssue(itm)
                                               && !IsImprovementIssue(itm));

            var totalNewWork = issues.Count(itm => !IsBugOrTechnicalDebtIssue(itm));
            var percent = issues.Any()
                        ? ((double)totalNewWork / issues.Count()) * 100
                        : 0;
            return (decimal)Math.Round(percent, 2);
        }
        private static bool IsBugOrTechnicalDebtIssue(AgileManager.Data.Dtos.Jira.IssueDto issue)
            => issue.Fields.Issuetype.Id.Equals($"{(int)IssueTypes.Bug}")
            || issue.Fields.Issuetype.Id.Equals($"{(int)IssueTypes.TechnicalDebt}");

        private static bool IsEpicIssue(AgileManager.Data.Dtos.Jira.IssueDto issue)
            => issue.Fields.Issuetype.Id.Equals($"{(int)IssueTypes.Epic}");

        private static bool IsSubTaskIssue(AgileManager.Data.Dtos.Jira.IssueDto issue)
            => issue.Fields.Issuetype.Id.Equals($"{(int)IssueTypes.SubTask}");

        private static bool IsImprovementIssue(AgileManager.Data.Dtos.Jira.IssueDto issue)
            => issue.Fields.Issuetype.Id.Equals($"{(int)IssueTypes.Improvement}");

        private async Task<IList<IssueDto>> GetBugsIssuesCancelled(string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(bugIssuesCanceledInDateRangeService, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<IssueDto>> GetBugsIssuesCreated(string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(bugIssuesCreatedInDateRangeService, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<IssueDto>> GetBugsIssuesCreatedAndResolved(string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(bugIssuesCreatedResolvedInDateRangeService, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<IssueDto>> GetBugsIssuesExisted(string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(bugIssuesExistedInDateRangeService, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<IssueDto>> GetBugsIssuesResolved(string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(bugIssuesResolvedInDateRangeService, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<IssueDto>> GetBugsIssuesOpened(string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(bugIssuesOpenedInDateRangeService, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<IssueDto>> GetTechnicalDebitIssuesCancelled(string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(technicalDebitIssuesCancelledInDateRangeService, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<IssueDto>> GetTechnicalDebitIssuesCreated(string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(technicalDebitIssuesCreatedInDateRangeService, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<IssueDto>> GetTechnicalDebitIssuesCreatedAndResolved(string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(technicalDebitIssuesCreatedAndResolvedInDateRangeService, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<IssueDto>> GetTechnicalDebitIssuesExisted(string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(technicalDebitIssuesExistedInDateRangeService, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<IssueDto>> GetTechnicalDebitIssuesOpened(string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(technicalDebitIssuesOpenedInDateRangeService, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<IssueDto>> GetTechnicalDebitIssuesResolved(string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await GetDataFromRange(technicalDebitIssuesResolvedInDateRangeService, projectName, initDate, endDate, cancellationToken);

        private async Task<IList<IssueDto>> GetDataFromRange(IBaseIssuesInDateRangesService service, string projectName, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var data = await service.GetData(projectName, initDate, endDate, cancellationToken);

            return jiraIssueDtoToIssueInfoDtoMapper.ToMapList(data.Issues);
        }
    }
}