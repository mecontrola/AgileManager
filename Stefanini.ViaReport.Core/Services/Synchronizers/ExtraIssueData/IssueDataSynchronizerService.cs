using Stefanini.ViaReport.Core.Mappers.DtoToEntity;
using Stefanini.ViaReport.Data.Dtos.Jira;
using Stefanini.ViaReport.Data.Entities;
using Stefanini.ViaReport.Data.Parameters;
using Stefanini.ViaReport.DataStorage.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services.Synchronizers.ExtraIssueData
{
    public class IssueDataSynchronizerService : IIssueDataSynchronizerService
    {
        private readonly IIssueRepository issueRepository;

        private readonly IJiraIssueDtoToEntityMapper jiraIssueDtoToEntityMapper;

        public IssueDataSynchronizerService(IIssueRepository issueRepository,
                                            IJiraIssueDtoToEntityMapper jiraIssueDtoToEntityMapper)
        {
            this.issueRepository = issueRepository;
            this.jiraIssueDtoToEntityMapper = jiraIssueDtoToEntityMapper;
        }

        public async Task Save(IssueSynchronizerParam parameters, CancellationToken cancellationToken)
        {
            var entity = await RetrieveIssue(parameters.IssueDto, parameters.ProjectId, parameters.IssueTypes, cancellationToken);
            entity.StatusId = GetStatusIdFromIssueDto(parameters);
            entity.Updated = parameters.IssueDto.Fields.Updated;

            await SaveIssueChanges(entity, cancellationToken);
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