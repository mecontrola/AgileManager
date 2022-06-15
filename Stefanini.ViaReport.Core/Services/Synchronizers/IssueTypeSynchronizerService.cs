using Stefanini.ViaReport.Core.Integrations.Jira.V2.IssueTypes;
using Stefanini.ViaReport.Core.Mappers.DtoToEntity;
using Stefanini.ViaReport.Data.Dtos.Jira;
using Stefanini.ViaReport.Data.Dtos.Synchronizers;
using Stefanini.ViaReport.DataStorage.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services.Synchronizers
{
    public class IssueTypeSynchronizerService : IIssueTypeSynchronizerService
    {
        private readonly IIssueTypeRepository issueTypeRepository;

        private readonly IIssueTypeGetAll issueTypeGetAll;

        private readonly IJiraIssueTypeDtoToEntityMapper jiraIssueTypeDtoToEntityMapper;

        public IssueTypeSynchronizerService(IIssueTypeRepository issueTypeRepository,
                                            IIssueTypeGetAll issueTypeGetAll,
                                            IJiraIssueTypeDtoToEntityMapper jiraIssueTypeDtoToEntityMapper)
        {
            this.issueTypeRepository = issueTypeRepository;
            this.issueTypeGetAll = issueTypeGetAll;
            this.jiraIssueTypeDtoToEntityMapper = jiraIssueTypeDtoToEntityMapper;
        }

        public async Task SynchronizeData(ConfigurationSynchronizerDto configurationSynchronizerDto, CancellationToken cancellationToken)
        {
            var issuetypes = await LoadListFromJira(configurationSynchronizerDto, cancellationToken);

            foreach (var issuetype in issuetypes)
                await SaveIssueType(issuetype, cancellationToken);
        }

        private async Task<IList<IssueTypeDto>> LoadListFromJira(ConfigurationSynchronizerDto configurationSynchronizerDto, CancellationToken cancellationToken)
            => await issueTypeGetAll.Execute(configurationSynchronizerDto.Username, configurationSynchronizerDto.Password, cancellationToken);

        private async Task SaveIssueType(IssueTypeDto issueTypeDto, CancellationToken cancellationToken)
        {
            if (await issueTypeRepository.ExistsByKeyAsync(long.Parse(issueTypeDto.Id), cancellationToken))
                return;

            var entity = jiraIssueTypeDtoToEntityMapper.ToMap(issueTypeDto);
            entity.Uuid = Guid.NewGuid();

            await issueTypeRepository.CreateAsync(entity, cancellationToken);
        }
    }
}