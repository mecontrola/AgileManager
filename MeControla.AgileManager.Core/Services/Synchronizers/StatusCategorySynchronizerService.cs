using MeControla.AgileManager.Core.Integrations.Jira.V2.StatusCategories;
using MeControla.AgileManager.Core.Mappers.DtoToEntity;
using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Dtos.Synchronizers;
using MeControla.AgileManager.DataStorage.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services.Synchronizers
{
    public class StatusCategorySynchronizerService : IStatusCategorySynchronizerService
    {
        private readonly IStatusCategoryRepository statusCategoryRepository;

        private readonly IStatusCategoryGetAll statusCategoryGetAll;

        private readonly IJiraStatusCategoryDtoToEntityMapper jiraStatusCategoryDtoToEntityMapper;

        public StatusCategorySynchronizerService(IStatusCategoryRepository statusCategoryRepository,
                                                 IStatusCategoryGetAll statusCategoryGetAll,
                                                 IJiraStatusCategoryDtoToEntityMapper jiraStatusCategoryDtoToEntityMapper)
        {
            this.statusCategoryRepository = statusCategoryRepository;
            this.statusCategoryGetAll = statusCategoryGetAll;
            this.jiraStatusCategoryDtoToEntityMapper = jiraStatusCategoryDtoToEntityMapper;
        }

        public async Task SynchronizeData(ConfigurationSynchronizerDto configurationSynchronizerDto, CancellationToken cancellationToken)
        {
            var statusCategories = await LoadListFromJira(cancellationToken);

            foreach (var statusCategory in statusCategories)
                await SaveStatusCategory(statusCategory, cancellationToken);
        }

        private async Task<IList<StatusCategoryDto>> LoadListFromJira(CancellationToken cancellationToken)
            => await statusCategoryGetAll.Execute(cancellationToken);

        private async Task SaveStatusCategory(StatusCategoryDto statusCategory, CancellationToken cancellationToken)
        {
            if (await statusCategoryRepository.ExistsByKeyAsync(statusCategory.Id, cancellationToken))
                return;

            var entity = jiraStatusCategoryDtoToEntityMapper.ToMap(statusCategory);
            entity.Uuid = Guid.NewGuid();

            await statusCategoryRepository.CreateAsync(entity, cancellationToken);
        }
    }
}