using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Issues;
using Stefanini.ViaReport.Core.Mappers.EntityToDto;
using Stefanini.ViaReport.Data.Dtos;
using Stefanini.ViaReport.Data.Entities;
using Stefanini.ViaReport.Data.Enums;
using Stefanini.ViaReport.DataStorage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DtoJira = Stefanini.ViaReport.Data.Dtos.Jira;

namespace Stefanini.ViaReport.Core.Services
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

        public async Task<DeliveryLastCycleDto> GetData(long projectId, DateTime initDate, DateTime endDate, string quarter, CancellationToken cancellationToken)
        {
            var issues = await issueRepository.FindResolvedInDateRangeAsync(projectId, initDate, endDate, cancellationToken);
            var data = new List<DeliveryLastCycleIssueDto>();
            var impediments = await CreateImpedimentList(projectId, initDate, endDate, cancellationToken);
            var epics = await CreateEpicList(projectId, quarter, cancellationToken);

            foreach (var issue in issues)
            {
                var info = await CreateIssueInfo(issue, cancellationToken);

                data.Add(info);
            }

            return CreateDeliveryLastCycleDto(initDate, endDate, data, impediments, epics);
        }

        public async Task<DeliveryLastCycleDto> GetData(string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var statusInProgress = await statusInProgressService.GetList(username, password, cancellationToken);
            var statusDone = await statusDoneService.GetList(username, password, cancellationToken);
            var search = await issuesResolvedInDateRangeService.GetData(username, password, project, initDate, endDate, cancellationToken);
            var statusInProgressList = statusInProgress.Select(x => x.Key).ToList();
            var statusDoneList = statusDone.Select(x => x.Key).ToList();
            var issues = new List<DeliveryLastCycleIssueDto>();
            var impediments = new List<DeliveryLastCycleImpedimentDto>();
            var epics = new List<DeliveryLastCycleEpicDto>();

            foreach (var issue in search.Issues)
            {
                var issueBacklog = await GetBacklogData(username, password, issue.Key, cancellationToken);

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

        private async Task<DtoJira.IssueDto> GetBacklogData(string username, string password, string issueKey, CancellationToken cancellationToken)
            => await issueGet.Execute(username, password, issueKey, cancellationToken);

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
            return businessDayHelper.Diff(dateInProgress.Value, dateDone.Value);
        }

        private async Task<decimal> CalculateDiscoveryLeadTime(long issueId, CancellationToken cancellationToken)
        {
            var dateToDo = await issueStatusHistoryRepository.FindDateTimeFirstHistoryByStatusCategoryAsync(issueId, StatusCategories.ToDo, cancellationToken);
            var dateInProgress = await issueStatusHistoryRepository.FindDateTimeFirstHistoryByStatusCategoryAsync(issueId, StatusCategories.InProgress, cancellationToken);
            return businessDayHelper.Diff(dateToDo.Value, dateInProgress.Value);
        }

        private static bool IsFeatureIssue(Issue issue)
            => issue.IssueType != null
            && issue.IssueType.Key == (long)IssueTypes.Story;

        private async Task<IList<DeliveryLastCycleEpicDto>> CreateEpicList(long projectId, string quarter, CancellationToken cancellationToken)
        {
            var list = await issueEpicRepository.RetrieveByQuarterAsync(projectId, quarter, cancellationToken);

            return deliveryLastCycleEpicEntityToDtoMapper.ToMapList(list)
                ?? Array.Empty<DeliveryLastCycleEpicDto>();
        }

        private async Task<IList<DeliveryLastCycleImpedimentDto>> CreateImpedimentList(long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var increaseEndDate = endDate.AddDays(1);
            var list = await issueImpedimentRepository.RetrieveByDateRangeAsync(projectId, initDate, endDate, cancellationToken);

            return list.Select(entity => CreateImpedimentInfoSwap(entity.Issue, (entity.End ?? increaseEndDate) - entity.Start))
                       .ToList();
        }

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