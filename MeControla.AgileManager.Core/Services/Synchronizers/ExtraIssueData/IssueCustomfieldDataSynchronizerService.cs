using MeControla.AgileManager.Core.Builders;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.Data.Parameters;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services.Synchronizers.ExtraIssueData
{
    public class IssueCustomfieldDataSynchronizerService : IIssueCustomfieldDataSynchronizerService
    {
        private readonly ILogger<IssueCustomfieldDataSynchronizerService> logger;

        private readonly IIssueRepository issueRepository;
        private readonly IIssueCustomfieldDataRepository issueCustomfieldDataRepository;
        private readonly IPreferenceCustomFieldRepository preferenceCustomFieldRepository;

        public IssueCustomfieldDataSynchronizerService(ILogger<IssueCustomfieldDataSynchronizerService> logger,
                                                       IIssueRepository issueRepository,
                                                       IIssueCustomfieldDataRepository issueCustomfieldDataRepository,
                                                       IPreferenceCustomFieldRepository preferenceCustomFieldRepository)
        {
            this.logger = logger;
            this.issueRepository = issueRepository;
            this.issueCustomfieldDataRepository = issueCustomfieldDataRepository;
            this.preferenceCustomFieldRepository = preferenceCustomFieldRepository;
        }

        public async Task Save(IssueSynchronizerParam parameters, CancellationToken cancellationToken)
        {
            logger.LogInformation($"[Synchronize] Synchronizing Issue Customfields Data {parameters.IssueDto.Key}.");

            var issue = await issueRepository.FindByKeyAsync(parameters.IssueDto.Key, cancellationToken);
            var preferenceCustomFields = await preferenceCustomFieldRepository.GetAllFieldsAsync(cancellationToken);

            foreach (var preference in preferenceCustomFields)
                await SaveCustomfield(preference.Type, preference.CustomField, issue.Id, parameters.IssueDto.Fields, cancellationToken);

            logger.LogInformation($"[Synchronize] Synchronizing Issue Customfields Data {parameters.IssueDto.Key}.");
        }

        private async Task SaveCustomfield(CustomFields type, CustomField customfield, long issueId, IssueFieldsDto fields, CancellationToken cancellationToken)
        {
            var value = GetValueFromCustomfield(type, customfield.Key, fields);

            await SaveCustomfieldSwap(customfield.Id, issueId, value, cancellationToken);
        }

        private async Task SaveCustomfieldSwap(long customfieldId, long issueId, string value, CancellationToken cancellationToken)
        {
            var entity = await issueCustomfieldDataRepository.RetrieveByCustomfieldAndIssueAsync(customfieldId, issueId, cancellationToken);

            entity ??= IssueCustomfieldDataBuilder.GetInstance()
                                                  .SetCustomfieldId(customfieldId)
                                                  .SetIssueId(issueId)
                                                  .ToBuild();

            entity.Value = value;

            if (entity.Id == 0)
                await issueCustomfieldDataRepository.CreateAsync(entity, cancellationToken);
            else
                await issueCustomfieldDataRepository.UpdateAsync(entity, cancellationToken);
        }

        private string GetValueFromCustomfield(CustomFields customFieldType, string propertyName, IssueFieldsDto fields)
            => CustomFieldFactory.GetCustomFieldReader(customFieldType, fields.CustomFields)
                                 .GetValue(propertyName);
    }

    public sealed class CustomFieldFactory
    {
        public static ICustomFieldReader GetCustomFieldReader(CustomFields customFieldType, IDictionary<string, dynamic> customFieldsValues)
            => customFieldType switch
            {
                CustomFields.StoryPoints => new StoryPointsCustomFieldReader(customFieldsValues),
                CustomFields.Impediment => new ImpedimentCustomFieldReader(customFieldsValues),
                CustomFields.ClassOfService => new ClasseOfServiceCustomFieldReader(customFieldsValues),
                _ => throw new Exception($"Custom field type {nameof(CustomFields)} not found."),
            };
    }

    public interface ICustomFieldReader
    {
        string GetValue(string propertyName);
    }

    public class StoryPointsCustomFieldReader : BaseCustomFieldReader, ICustomFieldReader
    {
        public StoryPointsCustomFieldReader(IDictionary<string, dynamic> customFieldsValues)
            : base(customFieldsValues)
        { }

        public string GetValue(string propertyName)
            => ReadValue<decimal>(propertyName);
    }

    public class ImpedimentCustomFieldReader : BaseCustomFieldReader, ICustomFieldReader
    {
        public ImpedimentCustomFieldReader(IDictionary<string, dynamic> customFieldsValues)
            : base(customFieldsValues)
        { }

        public string GetValue(string propertyName)
            => ReadValue<OptionDto[]>(propertyName, val => val.FirstOrDefault().Id);
    }

    public class ClasseOfServiceCustomFieldReader : BaseCustomFieldReader, ICustomFieldReader
    {
        public ClasseOfServiceCustomFieldReader(IDictionary<string, dynamic> customFieldsValues)
            : base(customFieldsValues)
        { }

        public string GetValue(string propertyName)
            => ReadValue<OptionDto>(propertyName, val => val?.Id);
    }

    public abstract class BaseCustomFieldReader
    {
        private readonly IDictionary<string, dynamic> customFieldsValues;

        protected BaseCustomFieldReader(IDictionary<string, dynamic> customFieldsValues)
        {
            this.customFieldsValues = customFieldsValues;
        }
        protected string ReadValue<T>(string propertyName)
            => ReadValue<T>(propertyName, val => val.ToString());

        protected string ReadValue<T>(string propertyName, Func<T, string> actionResult)
        {
            if (customFieldsValues.TryGetValue(propertyName, out dynamic property) && property is not null)
            {
                var value = JsonSerializer.Deserialize<T>(property, jsonOptions);

                return actionResult(value);
            }

            return string.Empty;
        }

        private readonly JsonSerializerOptions jsonOptions = new()
        {
            WriteIndented = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }
}