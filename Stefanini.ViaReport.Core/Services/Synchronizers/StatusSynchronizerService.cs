using Stefanini.ViaReport.Core.Integrations.Jira.V2.Statuses;
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
    public class StatusSynchronizerService : IStatusSynchronizerService
    {
        private readonly IStatusRepository statusRepository;
        private readonly IStatusCategoryRepository statusCategoryRepository;

        private readonly IStatusGetAll statusGetAll;

        private readonly IJiraStatusDtoToEntityMapper jiraStatusDtoToEntityMapper;

        public StatusSynchronizerService(IStatusRepository statusRepository,
                                         IStatusCategoryRepository statusCategoryRepository,
                                         IStatusGetAll statusGetAll,
                                         IJiraStatusDtoToEntityMapper jiraStatusDtoToEntityMapper)
        {
            this.statusRepository = statusRepository;
            this.statusCategoryRepository = statusCategoryRepository;
            this.statusGetAll = statusGetAll;
            this.jiraStatusDtoToEntityMapper = jiraStatusDtoToEntityMapper;
        }

        public async Task SynchronizeData(ConfigurationSynchronizerDto configurationSynchronizerDto, CancellationToken cancellationToken)
        {
            var statuses = await LoadListFromJira(configurationSynchronizerDto, cancellationToken);

            foreach (var status in statuses)
                await SaveStatus(status, cancellationToken);
        }

        private async Task<IList<StatusDto>> LoadListFromJira(ConfigurationSynchronizerDto configurationSynchronizerDto, CancellationToken cancellationToken)
            => await statusGetAll.Execute(configurationSynchronizerDto.Username, configurationSynchronizerDto.Password, cancellationToken);

        private async Task SaveStatus(StatusDto status, CancellationToken cancellationToken)
        {
            if (await statusRepository.ExistsByKeyAsync(long.Parse(status.Id), cancellationToken))
                return;

            var category = await statusCategoryRepository.FindByKeyAsync(status.StatusCategory.Id, cancellationToken);

            var entity = jiraStatusDtoToEntityMapper.ToMap(status);
            entity.Uuid = Guid.NewGuid();
            entity.StatusCategoryId = category.Id;

            await statusRepository.CreateAsync(entity, cancellationToken);
        }
    }
}