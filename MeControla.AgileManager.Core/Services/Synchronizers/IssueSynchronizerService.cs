using MeControla.AgileManager.Core.Services.Synchronizers.ExtraIssueData;
using MeControla.AgileManager.Data.Dtos.Synchronizers;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Parameters;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.AgileManager.Integrations.Jira.Builders;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos.Inputs;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services.Synchronizers
{
    public class IssueSynchronizerService : IIssueSynchronizerService
    {
        private readonly ILogger<IssueSynchronizerService> logger;

        private readonly IIssueRepository issueRepository;
        private readonly IIssueTypeRepository issueTypeRepository;
        private readonly IProjectRepository projectRepository;
        private readonly IStatusRepository statusRepository;

        private readonly IIssueGet issueGet;
        private readonly ISearchPost searchPost;

        private readonly IIssueCustomfieldDataSynchronizerService issueCustomfieldDataSynchronizerService;
        private readonly IIssueDataSynchronizerService issueDataSynchronizerService;
        private readonly IIssueImpedimentSynchronizerService issueImpedimentSynchronizerService;
        private readonly IIssueStatusHistorySynchronizerService issueStatusHistorySynchronizerService;
        private readonly IIssueEpicDataSynchronizerService issueEpicDataSynchronizerService;
        private readonly IIssueExtraDataSynchronizerService issueExtraDataSynchronizerService;

        public IssueSynchronizerService(ILogger<IssueSynchronizerService> logger,
                                        IIssueRepository issueRepository,
                                        IIssueTypeRepository issueTypeRepository,
                                        IProjectRepository projectRepository,
                                        IStatusRepository statusRepository,
                                        IIssueGet issueGet,
                                        ISearchPost searchPost,
                                        IIssueCustomfieldDataSynchronizerService issueCustomfieldDataSynchronizerService,
                                        IIssueDataSynchronizerService issueDataSynchronizerService,
                                        IIssueImpedimentSynchronizerService issueImpedimentSynchronizerService,
                                        IIssueStatusHistorySynchronizerService issueStatusHistorySynchronizerService,
                                        IIssueEpicDataSynchronizerService issueEpicDataSynchronizerService,
                                        IIssueExtraDataSynchronizerService issueExtraDataSynchronizerService)
        {
            this.logger = logger;

            this.issueRepository = issueRepository;
            this.issueTypeRepository = issueTypeRepository;
            this.projectRepository = projectRepository;
            this.statusRepository = statusRepository;
            this.issueGet = issueGet;
            this.searchPost = searchPost;
            this.issueCustomfieldDataSynchronizerService = issueCustomfieldDataSynchronizerService;
            this.issueDataSynchronizerService = issueDataSynchronizerService;
            this.issueImpedimentSynchronizerService = issueImpedimentSynchronizerService;
            this.issueStatusHistorySynchronizerService = issueStatusHistorySynchronizerService;
            this.issueEpicDataSynchronizerService = issueEpicDataSynchronizerService;
            this.issueExtraDataSynchronizerService = issueExtraDataSynchronizerService;
        }

        public async Task SynchronizeData(ConfigurationSynchronizerDto configurationSynchronizerDto, CancellationToken cancellationToken)
        {
            logger.LogInformation("[Synchronize] Started Issue synchronize.");

            var issueConfigurationSynchronizerDto = (IssueConfigurationSynchronizerDto)configurationSynchronizerDto;
            var projects = await RetrieveProjectsData(issueConfigurationSynchronizerDto, cancellationToken);

            if (!projects.Any())
                return;

            foreach (var project in projects)
            {
                var lastUpdated = await RetrieveDateTimeLastUpdate(issueConfigurationSynchronizerDto.SyncAllData, project.Id, cancellationToken);

                await SynchronizeAllIssuesInProject(project, lastUpdated, cancellationToken);
            }

            logger.LogInformation("[Synchronize] Stoped Issue synchronize.");
        }

        private async Task<DateTime?> RetrieveDateTimeLastUpdate(bool syncAllData, long projectId, CancellationToken cancellationToken)
            => syncAllData
             ? null
             : await RetrieveDateTimeLastUpdatesIssue(projectId, cancellationToken);

        private async Task<IList<Project>> RetrieveProjectsData(IssueConfigurationSynchronizerDto issueConfigurationSynchronizerDto, CancellationToken cancellationToken)
            => await projectRepository.FindAllInIdListAsync(issueConfigurationSynchronizerDto.Projects, cancellationToken);

        private async Task<DateTime?> RetrieveDateTimeLastUpdatesIssue(long projectId, CancellationToken cancellationToken)
            => await issueRepository.GetLastUpdatedAsync(projectId, cancellationToken);

        private async Task SynchronizeAllIssuesInProject(Project project, DateTime? lastUpdated, CancellationToken cancellationToken)
        {
            var issues = await RetrieveAllIssueInProject(project.Name, lastUpdated, cancellationToken);
            var statuses = await RetrieveAllKeyByIdStatus(cancellationToken);
            var issueTypes = await RetrieveAllKeyByIdIssueTypes(cancellationToken);

            foreach (var issue in issues)
            {
                logger.LogInformation($"[Synchronize] Synchronizing Issue {issue.Key}.");

                var issueJira = await RetrieveIssueData(issue.Key, cancellationToken);

                var parameters = new IssueSynchronizerParam()
                {
                    IssueDto = issueJira,
                    ProjectId = project.Id,
                    Statuses = statuses,
                    IssueTypes = issueTypes
                };

                await SaveIssue(parameters, cancellationToken);

                logger.LogInformation($"[Synchronize] Synchronized Issue {issue.Key}.");
            }
        }

        private async Task<IDictionary<string, long>> RetrieveAllKeyByIdStatus(CancellationToken cancellationToken)
        {
            var list = await statusRepository.FindAllAsync(cancellationToken);
            return list.ToDictionary(x => $"{x.Key}", x => x.Id);
        }

        private async Task<IDictionary<string, long>> RetrieveAllKeyByIdIssueTypes(CancellationToken cancellationToken)
        {
            var list = await issueTypeRepository.FindAllAsync(cancellationToken);
            return list.ToDictionary(x => $"{x.Key}", x => x.Id);
        }

        private async Task<IEnumerable<IssueDto>> RetrieveAllIssueInProject(string projectName, DateTime? lastUpdated, CancellationToken cancellationToken)
        {
            var startAt = 0L;
            var issues = new List<IssueDto>();

            bool goToNextPage;
            do
            {
                var searchResult = await searchPost.Execute(MountSearchData(projectName, lastUpdated, startAt), cancellationToken);

                issues.AddRange(searchResult.Issues);

                startAt += searchResult.MaxResults;
                goToNextPage = (searchResult.StartAt + searchResult.MaxResults) < searchResult.Total;
            } while (goToNextPage);

            return issues;
        }

        private static SearchInputDto MountSearchData(string projectName, DateTime? lastUpdated, long startAt)
            => SearchInputDtoBuilder.GetInstance()
                                    .AddStartAt(startAt)
                                    .AddJql(MountJql(projectName, lastUpdated))
                                    .ToBuild();

        private static JqlBuilder MountJql(string projectName, DateTime? lastUpdated)
        {
            var jql = JqlBuilder.GetInstance()
                                .AddProjectCriteria(projectName)
                                .AddKeyOrderBy();

            if (lastUpdated.HasValue)
                jql.AddUpdatedIsGreaterEqualThan(lastUpdated.Value);

            return jql;
        }

        private async Task<IssueDto> RetrieveIssueData(string issueKey, CancellationToken cancellationToken)
            => await issueGet.Execute(issueKey, cancellationToken);

        private async Task SaveIssue(IssueSynchronizerParam parameters, CancellationToken cancellationToken)
        {
            await issueDataSynchronizerService.Save(parameters, cancellationToken);
            await issueImpedimentSynchronizerService.Save(parameters, cancellationToken);
            await issueStatusHistorySynchronizerService.Save(parameters, cancellationToken);
            await issueEpicDataSynchronizerService.Save(parameters, cancellationToken);
            await issueCustomfieldDataSynchronizerService.Save(parameters, cancellationToken);
            await issueExtraDataSynchronizerService.Save(parameters, cancellationToken);
        }
    }
}