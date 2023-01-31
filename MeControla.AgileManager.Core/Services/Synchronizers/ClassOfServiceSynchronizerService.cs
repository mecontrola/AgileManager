using MeControla.AgileManager.Core.Mappers.DtoToEntity;
using MeControla.AgileManager.Data.Dtos.Synchronizers;
using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Contexts;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Options;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services.Synchronizers
{
    public class ClassOfServiceSynchronizerService : IClassOfServiceSynchronizerService
    {
        private readonly ILogger<ClassOfServiceSynchronizerService> logger;

        private readonly IClassOfServiceRepository classOfServiceRepository;
        private readonly ICustomFieldRepository customfieldRepository;

        private readonly IContextGetAll contextGetAll;
        private readonly IOptionGetAll optionGetAll;

        private readonly IJiraClasseOfServiceDtoToEntityMapper jiraClasseOfServiceDtoToEntityMapper;

        public ClassOfServiceSynchronizerService(ILogger<ClassOfServiceSynchronizerService> logger,
                                                 IClassOfServiceRepository classOfServiceRepository,
                                                 ICustomFieldRepository customfieldRepository,
                                                 IContextGetAll contextGetAll,
                                                 IOptionGetAll optionGetAll,
                                                 IJiraClasseOfServiceDtoToEntityMapper jiraClasseOfServiceDtoToEntityMapper)
        {
            this.logger = logger;

            this.classOfServiceRepository = classOfServiceRepository;
            this.customfieldRepository = customfieldRepository;
            this.contextGetAll = contextGetAll;
            this.optionGetAll = optionGetAll;
            this.jiraClasseOfServiceDtoToEntityMapper = jiraClasseOfServiceDtoToEntityMapper;
        }

        public async Task SynchronizeData(ConfigurationSynchronizerDto configurationSynchronizerDto, CancellationToken cancellationToken)
        {
            logger.LogInformation("[Synchronize] Started Classes of Service synchronize.");

            var options = await LoadListFromJira(cancellationToken);

            foreach (var option in options)
                await SaveClassOfService(option, cancellationToken);

            logger.LogInformation("[Synchronize] Stopped Classes of Service synchronize.");
        }

        private async Task<IList<OptionDto>> LoadListFromJira(CancellationToken cancellationToken)
        {
            var customField = await customfieldRepository.GetDataByCustomField(CustomFields.ClassOfService, cancellationToken);

            if (customField == null)
                return Array.Empty<OptionDto>();

            var contextJira = await contextGetAll.Execute(customField.Key, cancellationToken);

            if (contextJira?.Values.Count != 1)
                throw new Exception("Quantidade invalida.");

            var context = contextJira.Values.First();

            var optionsList = await optionGetAll.Execute(customField.Key, context.Id, cancellationToken);

            return optionsList.Values;
        }

        private async Task SaveClassOfService(OptionDto option, CancellationToken cancellationToken)
        {
            if (await classOfServiceRepository.ExistsByKeyAsync(option.Id, cancellationToken))
                return;

            var entity = jiraClasseOfServiceDtoToEntityMapper.ToMap(option);
            entity.Uuid = Guid.NewGuid();

            await classOfServiceRepository.CreateAsync(entity, cancellationToken);
        }
    }
}