using MeControla.AgileManager.Core.Mappers.DtoToEntity;
using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Parameters;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.Kernel.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services.Synchronizers.ExtraIssueData
{
    public class IssueDataSynchronizerService : IIssueDataSynchronizerService
    {
        private readonly ILogger<IssueDataSynchronizerService> logger;

        private readonly IIssueRepository issueRepository;

        private readonly IJiraIssueDtoToEntityMapper jiraIssueDtoToEntityMapper;

        public IssueDataSynchronizerService(ILogger<IssueDataSynchronizerService> logger,
                                            IIssueRepository issueRepository,
                                            IJiraIssueDtoToEntityMapper jiraIssueDtoToEntityMapper)
        {
            this.logger = logger;
            this.issueRepository = issueRepository;
            this.jiraIssueDtoToEntityMapper = jiraIssueDtoToEntityMapper;
        }

        public async Task Save(IssueSynchronizerParam parameters, CancellationToken cancellationToken)
        {
            logger.LogInformation($"[Synchronize] Synchronizing Issue Data {parameters.IssueDto.Key}.");

            var entity = await RetrieveIssue(parameters.IssueDto, parameters.ProjectId, parameters.IssueTypes, cancellationToken);
            entity.StatusId = GetStatusIdFromIssueDto(parameters);
            entity.Updated = parameters.IssueDto.Fields.Updated;
            entity.Resolved = parameters.IssueDto.Fields.Resolutiondate;
            entity.CustomField14503 = parameters.IssueDto.Fields.Customfield_14503.ToDateTime();

            await SaveIssueChanges(entity, cancellationToken);

            logger.LogInformation($"[Synchronize] Synchronized Issue Data {parameters.IssueDto.Key}.");
        }

        private static long GetStatusIdFromIssueDto(IssueSynchronizerParam parameters)
            => parameters.Statuses[parameters.IssueDto.Fields.Status.Id];

        private async Task<Issue> RetrieveIssue(IssueDto issue, long projectId, IDictionary<string, long> issueTypes, CancellationToken cancellationToken)
        {
            var entity = await issueRepository.FindByKeyAsync(issue.Key, cancellationToken);

            if (entity != null)
                return entity;

            entity = jiraIssueDtoToEntityMapper.ToMap(issue);
            entity.Uuid = Guid.NewGuid();
            entity.ProjectId = projectId;
            entity.IssueTypeId = issueTypes[issue.Fields.Issuetype.Id];

            return entity;
        }

        private async Task SaveIssueChanges(Issue entity, CancellationToken cancellationToken)
        {
            if (entity.Id == 0)
                await issueRepository.CreateAsync(entity, cancellationToken);
            else
                await issueRepository.UpdateAsync(entity, cancellationToken);
        }
    }
}