using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.Data.Parameters;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.Core.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services.Synchronizers.ExtraIssueData
{
    public class IssueExtraDataSynchronizerService : IIssueExtraDataSynchronizerService
    {
        private readonly ILogger<IssueExtraDataSynchronizerService> logger;

        private readonly IClassOfServiceRepository classfServiceRepository;
        private readonly IIssueRepository issueRepository;
        private readonly IIssueCustomfieldDataRepository issueCustomfieldDataRepository;
        private readonly IIssueExtraDataRepository issueExtraDataRepository;
        private readonly IIssueStatusHistoryRepository issueStatusHistoryRepository;

        private readonly IBusinessDayHelper businessDayHelper;

        public IssueExtraDataSynchronizerService(ILogger<IssueExtraDataSynchronizerService> logger,
                                                 IClassOfServiceRepository classfServiceRepository,
                                                 IIssueRepository issueRepository,
                                                 IIssueCustomfieldDataRepository issueCustomfieldDataRepository,
                                                 IIssueExtraDataRepository issueExtraDataRepository,
                                                 IIssueStatusHistoryRepository issueStatusHistoryRepository,
                                                 IBusinessDayHelper businessDayHelper)
        {
            this.logger = logger;
            this.classfServiceRepository = classfServiceRepository;
            this.issueRepository = issueRepository;
            this.issueCustomfieldDataRepository = issueCustomfieldDataRepository;
            this.issueExtraDataRepository = issueExtraDataRepository;
            this.issueStatusHistoryRepository = issueStatusHistoryRepository;
            this.businessDayHelper = businessDayHelper;
        }

        public async Task Save(IssueSynchronizerParam parameters, CancellationToken cancellationToken)
        {
            logger.LogInformation($"[Synchronize] Synchronizing Issue Extra Data {parameters.IssueDto.Key}.");

            var issue = await issueRepository.FindByKeyAsync(parameters.IssueDto.Key, cancellationToken);
            var customFieldDatas = await issueCustomfieldDataRepository.FindAllByIssueIdAsync(issue.Id, cancellationToken);
            var classOfServices = await classfServiceRepository.ToDictionaryAsync(cancellationToken);

            var entity = await LoadIssueExtraData(issue, cancellationToken);

            await FillIssueExtraData(entity, customFieldDatas, classOfServices, cancellationToken);

            await SaveIssueExtraData(entity, cancellationToken);

            logger.LogInformation($"[Synchronize] Synchronized Issue Extra Data {parameters.IssueDto.Key}.");
        }

        private async Task FillIssueExtraData(IssueExtraData entity, IList<IssueCustomfieldData> customFieldDatas, IDictionary<string, long> classOfServices, CancellationToken cancellationToken)
        {
            foreach (var customFieldData in customFieldDatas)
            {
                switch (customFieldData.CustomField.Preference.Type)
                {
                    case CustomFields.StoryPoints:
                        var storyPoints = customFieldData.Value.ToDecimal();
                        if (storyPoints.HasValue)
                            entity.StoryPoints = storyPoints.Value;
                        break;
                    case CustomFields.Impediment:
                        entity.Impediment = !string.IsNullOrWhiteSpace(customFieldData.Value);
                        entity.Impediment = !string.IsNullOrWhiteSpace(customFieldData.Value);
                        break;
                    case CustomFields.ClassOfService:
                        if (classOfServices.TryGetValue(customFieldData.Value, out var classOfServiceId))
                            entity.ClassOfServiceId = classOfServiceId;
                        break;
                }
            }

            entity.DiscoveryLeadTime = await CalculateDiscoveryLeadTime(entity.Id, cancellationToken);
            entity.SystemLeadTime = await CalculateSystemLeadTime(entity.Id, cancellationToken);
            entity.CustomerLeadTime = entity.DiscoveryLeadTime + entity.SystemLeadTime;
        }

        private async Task<IssueExtraData> LoadIssueExtraData(Issue issue, CancellationToken cancellationToken)
        {
            var entity = await issueExtraDataRepository.FindAsync(issue.Id, cancellationToken);

            if (entity != null)
                return entity;

            entity = CreateEntity(issue.Id, issue.Uuid);

            await issueExtraDataRepository.CreateAsync(entity, cancellationToken);

            return entity;
        }

        private static IssueExtraData CreateEntity(long id, Guid uuid)
            => new()
            {
                Id = id,
                Uuid = uuid,
            };

        private async Task SaveIssueExtraData(IssueExtraData entity, CancellationToken cancellationToken)
            => await issueExtraDataRepository.UpdateAsync(entity, cancellationToken);

        private async Task<decimal> CalculateSystemLeadTime(long issueId, CancellationToken cancellationToken)
        {
            var dateInProgress = await issueStatusHistoryRepository.FindDateTimeFirstHistoryByStatusCategoryAsync(issueId, StatusCategories.InProgress, cancellationToken);
            var dateDone = await issueStatusHistoryRepository.FindDateTimeFirstHistoryByStatusCategoryAsync(issueId, StatusCategories.Done, cancellationToken);

            if (dateInProgress == null)
                return 0;

            dateDone ??= DateTime.Now;

            return businessDayHelper.Diff(dateInProgress.Value, dateDone.Value);
        }

        private async Task<decimal> CalculateDiscoveryLeadTime(long issueId, CancellationToken cancellationToken)
        {
            var dateToDo = await issueStatusHistoryRepository.FindDateTimeFirstHistoryByStatusCategoryAsync(issueId, StatusCategories.ToDo, cancellationToken);
            var dateInProgress = await issueStatusHistoryRepository.FindDateTimeFirstHistoryByStatusCategoryAsync(issueId, StatusCategories.InProgress, cancellationToken);

            if (dateToDo == null || dateInProgress == null)
                return 0;

            return businessDayHelper.Diff(dateToDo.Value, dateInProgress.Value);
        }
    }
}