using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Issues;
using MeControla.AgileManager.Core.Mappers.EntityToDto;
using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.Kernel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DtoJira = MeControla.AgileManager.Data.Dtos.Jira;

namespace MeControla.AgileManager.Core.Services
{
    public class DeliveryLastCycleService : IDeliveryLastCycleService
    {
        private readonly IIssueRepository issueRepository;
        private readonly IIssueEpicRepository issueEpicRepository;
        private readonly IIssueImpedimentRepository issueImpedimentRepository;
        private readonly IIssueStatusHistoryRepository issueStatusHistoryRepository;

        private readonly IIssuesResolvedInDateRangeService issuesResolvedInDateRangeService;
        private readonly IStatusDoneService statusDoneService;
        private readonly IStatusInProgressService statusInProgressService;

        private readonly IDeliveryLastCycleEpicEntityToDtoMapper deliveryLastCycleEpicEntityToDtoMapper;

        private readonly IBusinessDayHelper businessDayHelper;
        private readonly IRecoverDateTimeFirstStatusMatchBacklogHelper recoverDateTimeFirstStatusMatchBacklogHelper;
        private readonly IIssueGet issueGet;

        public DeliveryLastCycleService(IIssueRepository issueRepository,
                                        IIssueEpicRepository issueEpicRepository,
                                        IIssueImpedimentRepository issueImpedimentRepository,
                                        IIssueStatusHistoryRepository issueStatusHistoryRepository,
                                        IIssuesResolvedInDateRangeService issuesResolvedInDateRangeService,
                                        IStatusDoneService statusDoneService,
                                        IStatusInProgressService statusInProgressService,
                                        IDeliveryLastCycleEpicEntityToDtoMapper deliveryLastCycleEpicEntityToDtoMapper,
                                        IBusinessDayHelper businessDayHelper,
                                        IRecoverDateTimeFirstStatusMatchBacklogHelper recoverDateTimeFirstStatusMatchBacklogHelper,
                                        IIssueGet issueGet)
        {
            this.issueRepository = issueRepository;
            this.issueEpicRepository = issueEpicRepository;
            this.issueImpedimentRepository = issueImpedimentRepository;
            this.issueStatusHistoryRepository = issueStatusHistoryRepository;
            this.issuesResolvedInDateRangeService = issuesResolvedInDateRangeService;
            this.statusDoneService = statusDoneService;
            this.statusInProgressService = statusInProgressService;
            this.deliveryLastCycleEpicEntityToDtoMapper = deliveryLastCycleEpicEntityToDtoMapper;
            this.businessDayHelper = businessDayHelper;
            this.recoverDateTimeFirstStatusMatchBacklogHelper = recoverDateTimeFirstStatusMatchBacklogHelper;
            this.issueGet = issueGet;
        }

        public async Task<DeliveryLastCycleDto> GetData(long projectId, long quarterId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var issues = await issueRepository.FindResolvedInDateRangeAsync(projectId, initDate, endDate, cancellationToken);
            var data = await Task.WhenAll(issues.Select(issue => CreateIssueInfo(issue, cancellationToken)));
            var impediments = await CreateImpedimentList(projectId, initDate, endDate, cancellationToken);
            var epics = await CreateEpicList(projectId, quarterId, cancellationToken);

            return CreateDeliveryLastCycleDto(initDate, endDate, data, impediments, epics);
        }

        public async Task<DeliveryLastCycleDto> GetData(string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var statusInProgress = await statusInProgressService.GetList(cancellationToken);
            var statusDone = await statusDoneService.GetList(cancellationToken);
            var search = await issuesResolvedInDateRangeService.GetData(project, initDate, endDate, cancellationToken);
            var statusInProgressList = statusInProgress.Select(x => x.Key).ToList();
            var statusDoneList = statusDone.Select(x => x.Key).ToList();
            var issues = new List<DeliveryLastCycleIssueDto>();
            var impediments = new List<DeliveryLastCycleImpedimentDto>();
            var epics = new List<DeliveryLastCycleEpicDto>();

            foreach (var issue in search.Issues)
            {
                var issueBacklog = await GetBacklogData(issue.Key, cancellationToken);

                issues.Add(CreateIssueInfo(issueBacklog, statusInProgressList, statusDoneList));
            }

            return CreateDeliveryLastCycleDto(initDate, endDate, issues, impediments, epics);
        }

        private static DeliveryLastCycleDto CreateDeliveryLastCycleDto(DateTime initDate,
                                                                       DateTime endDate,
                                                                       IList<DeliveryLastCycleIssueDto> issues,
                                                                       IList<DeliveryLastCycleImpedimentDto> impediments,
                                                                       IList<DeliveryLastCycleEpicDto> epics)
            => new()
            {
                StartDate = initDate,
                EndDate = endDate,
                Throughtput = issues.Count,
                CustomerLeadTimeAverage = CalculateAverage(issues, x => x.CustomerLeadTime),
                DiscoveryLeadTimeAverage = CalculateAverage(issues, x => x.DiscoveryLeadTime),
                SystemLeadTimeAverage = CalculateAverage(issues, x => x.SystemLeadTime),
                Feature = issues.Count(x => x.IsFeature),
                Debits = issues.Count(x => !x.IsFeature),
                FeaturePercent = CalculateTotalPercent(issues, x => x.IsFeature),
                DebitsPercent = CalculateTotalPercent(issues, x => !x.IsFeature),
                Issues = issues,
                Impediments = impediments,
                Epics = epics,
                QuarterAveragePercentage = CalculateAverage(epics, x => x.Progress)
            };

        private static decimal CalculateAverage<TSource>(IList<TSource> list, Func<TSource, decimal> selector)
            => list.Any()
             ? Math.Round(list.Sum(selector) / list.Count, 2)
             : 0;

        private static decimal CalculateTotalPercent<TSource>(IList<TSource> list, Func<TSource, bool> predicate)
            => list.Any()
             ? Math.Round((decimal)list.Count(predicate) / list.Count, 4)
             : 0;

        private async Task<DtoJira.IssueDto> GetBacklogData(string issueKey, CancellationToken cancellationToken)
            => await issueGet.Execute(issueKey, cancellationToken);

        private DeliveryLastCycleIssueDto CreateIssueInfo(DtoJira.IssueDto issue, IList<string> statusInProgress, IList<string> statusDone)
            => new()
            {
                Key = issue.Key,
                Description = issue.Fields.Summary,
                SystemLeadTime = CalculateLeadTime(issue.Changelog, statusInProgress, statusDone)
            };

        private async Task<DeliveryLastCycleIssueDto> CreateIssueInfo(Issue issue, CancellationToken cancellationToken)
        {
            var discoveryLeadTime = await CalculateDiscoveryLeadTime(issue.Id, cancellationToken);
            var systemLeadTime = await CalculateSystemLeadTime(issue.Id, cancellationToken);

            return new()
            {
                Key = issue.Key,
                IssueType = issue.IssueType.Name,
                Description = issue.Summary,
                DiscoveryLeadTime = discoveryLeadTime,
                SystemLeadTime = systemLeadTime,
                CustomerLeadTime = discoveryLeadTime + systemLeadTime,
                IsFeature = IsFeatureIssue(issue),
                Link = issue.Link,
            };
        }

        private decimal CalculateLeadTime(DtoJira.ChangelogDto changelog, IList<string> statusInProgress, IList<string> statusDone)
        {
            var dateInProgress = recoverDateTimeFirstStatusMatchBacklogHelper.GetDateTime(changelog, statusInProgress);
            var dateDone = recoverDateTimeFirstStatusMatchBacklogHelper.GetDateTime(changelog, statusDone);
            return businessDayHelper.Diff(dateInProgress.Value, dateDone.Value);
        }

        private async Task<decimal> CalculateSystemLeadTime(long issueId, CancellationToken cancellationToken)
        {
            var dateInProgress = await issueStatusHistoryRepository.FindDateTimeFirstHistoryByStatusCategoryAsync(issueId, StatusCategories.InProgress, cancellationToken);
            var dateDone = await issueStatusHistoryRepository.FindDateTimeFirstHistoryByStatusCategoryAsync(issueId, StatusCategories.Done, cancellationToken);

            if (dateInProgress == null || dateDone == null)
                return 0;

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

        private static bool IsFeatureIssue(Issue issue)
            => issue.IssueType != null
            && GetFeaturesIssueTypes().Any(issueType => issue.IssueType.Key == (long)issueType);

        private static IssueTypes[] GetFeaturesIssueTypes()
            => new IssueTypes[]
            {
                IssueTypes.Story,
                IssueTypes.Task,
                IssueTypes.SubTask
            };

        private async Task<IList<DeliveryLastCycleEpicDto>> CreateEpicList(long projectId, long quarterId, CancellationToken cancellationToken)
        {
            var list = await issueEpicRepository.RetrieveByQuarterAsync(projectId, quarterId, cancellationToken);

            return deliveryLastCycleEpicEntityToDtoMapper.ToMapList(list)
                ?? Array.Empty<DeliveryLastCycleEpicDto>();
        }

        private async Task<IList<DeliveryLastCycleImpedimentDto>> CreateImpedimentList(long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var increaseEndDate = endDate.AddDays(1);
            var list = await issueImpedimentRepository.RetrieveByDateRangeAsync(projectId, initDate, endDate, cancellationToken);

            return list.GroupBy(entity => entity.Issue.Key)
                       .Select(group => CreateImpedimentInfoSwap(group.First().Issue, SumDiffTimes(group, increaseEndDate)))
                       .ToList();
        }

        private static TimeSpan SumDiffTimes(IGrouping<string, IssueImpediment> group, DateTime increaseEndDate)
            => group.Sum(entity => (entity.End ?? increaseEndDate) - entity.Start);

        private static DeliveryLastCycleImpedimentDto CreateImpedimentInfoSwap(Issue issue, TimeSpan impediment)
            => new()
            {
                Key = issue.Key,
                Description = issue.Summary,
                IssueType = issue.IssueType.Name,
                Time = impediment,
                Link = issue.Link,
            };
    }
}