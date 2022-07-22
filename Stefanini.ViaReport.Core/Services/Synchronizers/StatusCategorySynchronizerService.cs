using Stefanini.ViaReport.Core.Integrations.Jira.V2.StatusCategories;
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
            var statusCategories = await LoadListFromJira(configurationSynchronizerDto, cancellationToken);

            foreach (var statusCategory in statusCategories)
                await SaveStatusCategory(statusCategory, cancellationToken);
        }

        private async Task<IList<StatusCategoryDto>> LoadListFromJira(ConfigurationSynchronizerDto configurationSynchronizerDto, CancellationToken cancellationToken)
            => await statusCategoryGetAll.Execute(configurationSynchronizerDto.Username, configurationSynchronizerDto.Password, cancellationToken);

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