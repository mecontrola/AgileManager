using MeControla.AgileManager.Core.Mappers.DtoToEntity;
using MeControla.AgileManager.Data.Dtos.Synchronizers;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Statuses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services.Synchronizers
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
            var statuses = await LoadListFromJira(cancellationToken);

            foreach (var status in statuses)
                await SaveStatus(status, cancellationToken);
        }

        private async Task<IList<StatusDto>> LoadListFromJira(CancellationToken cancellationToken)
            => await statusGetAll.Execute(cancellationToken);

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