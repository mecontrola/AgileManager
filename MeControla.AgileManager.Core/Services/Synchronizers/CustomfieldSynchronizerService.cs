using MeControla.AgileManager.Core.Mappers.DtoToEntity;
using MeControla.AgileManager.Data.Dtos.Synchronizers;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Fields;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services.Synchronizers
{
    public class CustomfieldSynchronizerService : ICustomfieldSynchronizerService
    {
        private const string PATTERN_CUSTOMFIELD_NAME = @"^customfield_[0-9]{5,}$";

        private readonly ILogger<CustomfieldSynchronizerService> logger;

        private readonly ICustomFieldRepository customFieldRepository;

        private readonly IFieldGetAll fieldGetAll;

        private readonly IJiraFieldDtoToEntityMapper jiraFieldDtoToEntityMapper;

        public CustomfieldSynchronizerService(ILogger<CustomfieldSynchronizerService> logger,
                                              ICustomFieldRepository customFieldRepository,
                                              IFieldGetAll fieldGetAll,
                                              IJiraFieldDtoToEntityMapper jiraFieldDtoToEntityMapper)
        {
            this.logger = logger;

            this.customFieldRepository = customFieldRepository;
            this.fieldGetAll = fieldGetAll;
            this.jiraFieldDtoToEntityMapper = jiraFieldDtoToEntityMapper;
        }

        public async Task SynchronizeData(ConfigurationSynchronizerDto configurationSynchronizerDto, CancellationToken cancellationToken)
        {
            logger.LogInformation("[Synchronize] Started Customfield synchronize.");

            var fields = await LoadListFromJira(cancellationToken);

            foreach (var field in fields)
                if (IsCustomfield(field.Key))
                    await SaveField(field, cancellationToken);

            logger.LogInformation("[Synchronize] Stoped Customfield synchronize.");
        }

        private static bool IsCustomfield(string key)
            => Regex.IsMatch(key, PATTERN_CUSTOMFIELD_NAME);

        private async Task<IList<FieldDto>> LoadListFromJira(CancellationToken cancellationToken)
            => await fieldGetAll.Execute(cancellationToken);

        private async Task SaveField(FieldDto statusCategory, CancellationToken cancellationToken)
        {
            if (await customFieldRepository.ExistsByKeyAsync(statusCategory.Key, cancellationToken))
                return;

            var entity = jiraFieldDtoToEntityMapper.ToMap(statusCategory);
            entity.Uuid = Guid.NewGuid();

            await customFieldRepository.CreateAsync(entity, cancellationToken);
        }
    }
}