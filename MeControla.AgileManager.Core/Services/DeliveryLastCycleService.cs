using MeControla.AgileManager.Core.Extensions;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.Mappers.EntityToDto;
using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
using MeControla.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using DtoJira = MeControla.AgileManager.Integrations.Jira.Data.Dtos;

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
            var issuesBacklog = await issueRepository.FindAllInBacklogAsync(projectId, cancellationToken);
            var issuesDelivery = await issueRepository.FindResolvedInDateRangeAsync(projectId, initDate, endDate, cancellationToken);
            var dataDelivery = await Task.WhenAll(issuesDelivery.Select(issue => CreateIssuDeliveryeInfo(issue, cancellationToken)));
            var issuesInProgress = await issueRepository.FindAllInProgressAsync(projectId, cancellationToken);
            var dataInProgress = await Task.WhenAll(issuesInProgress.Select(issue => CreateIssuInProgressInfo(issue, cancellationToken)));
            var impediments = await CreateImpedimentList(projectId, initDate, endDate, cancellationToken);
            var epics = await CreateEpicList(projectId, quarterId, cancellationToken);
            var cycleTime = await CreateGeneralCycleTimeList(projectId, initDate, endDate, cancellationToken);

            string getStack(string summary)
            {
                var pattern = @"^(\w|\d|\s|-)*\[(?<stack>Android|iOS|Back(-|\s)?end|Fullstack)\](.*)$";
                var matches = Regex.Matches(summary, pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);

                foreach (var match in matches)
                {
                    return matches.First().Groups["stack"].Value;
                }

                return string.Empty;
            }

            string formatReportBacklog(Issue x) => $"{x.IssueType.Name};{x.Key};{getStack(x.Summary)};{x.ExtraData.StoryPoints};{x.Summary};{x.ExtraData.DiscoveryLeadTime};;;{x.Status.Name};";
            string formatReportInProgress(Issue x) => $"{x.IssueType.Name};{x.Key};{getStack(x.Summary)};{x.ExtraData.StoryPoints};{x.Summary};{x.ExtraData.SystemLeadTime};;;{x.Status.Name};";
            string formatReportDone(Issue x) => $"{x.IssueType.Name};{x.Key};{getStack(x.Summary)};{x.ExtraData.StoryPoints};{x.Summary};{x.ExtraData.SystemLeadTime};;;{x.Status.Name};";

            var reportBacklog = string.Join("\n", issuesBacklog.Select(x => formatReportBacklog(x)));

            var reportInProgress = string.Join("\n", issuesInProgress.Select(x => formatReportInProgress(x)));

            var reportDone = string.Join("\n", issuesDelivery.Select(x => formatReportDone(x)));

            string formatDate(TimeSpan value)
            {
                var dt = new DateTime(1900, 01, 01);
                dt = dt + value;
                dt = dt.AddDays(-1);

                return $"{dt:dd/MM/yyyy HH:mm:ss}";
            }

            var excel = string.Join("\n", impediments.OrderBy(x => x.Key).Select(x => $"{x.Key};{formatDate(x.Time)}"));

            return CreateDeliveryLastCycleDto(initDate, endDate, dataDelivery, dataInProgress, impediments, epics, cycleTime);
        }

        private async Task<IList<Tuple<long, string, double>>> CreateIndividualCycleTimeList(long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var values = new List<Tuple<long, string, double>>();

            var history = await issueStatusHistoryRepository.FindIssuesByProjectAndRangeDateTimeAsync(projectId, initDate, endDate, cancellationToken);

            var issues = history.Select(entity => entity.IssueId).Distinct();

            foreach (var issueId in issues)
            {
                var histories = history.Where(entity => entity.IssueId == issueId);
                var issue = histories.FirstOrDefault().Issue;

                foreach (var item in histories)
                {
                    var lastHistory = histories.FirstOrDefault(entity => entity.ToStatusId == item.FromStatusId);

                    if (item.DateTime.Date < initDate.Date || item.DateTime.Date > endDate.Date)
                        continue;

                    var time = (item.DateTime - (lastHistory?.DateTime ?? issue.Created)).TotalDays;

                    values.Add(new Tuple<long, string, double>(issueId, item.FromStatus.Name, time));
                }
            }

            return values;
        }

        private async Task<IList<DeliveryLastCycleCycleTimeDto>> CreateGeneralCycleTimeList(long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var values = await CreateIndividualCycleTimeList(projectId, initDate, endDate, cancellationToken);

            return values.GroupBy(x => x.Item2)
                         .Select(x =>
                         {
                             var list = x.Select(itm => itm.Item3);
                             return new DeliveryLastCycleCycleTimeDto
                             {
                                 Status = x.Key,
                                 Time = (decimal)Math.Round(list.Sum() / list.Count(), 2)
                             };
                         })
                         .ToList();
        }

        public async Task<DeliveryLastCycleDto> GetData(string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var statusInProgress = await statusInProgressService.GetList(cancellationToken);
            var statusDone = await statusDoneService.GetList(cancellationToken);
            var search = await issuesResolvedInDateRangeService.GetData(project, initDate, endDate, cancellationToken);
            var statusInProgressList = statusInProgress.Select(x => x.Key).ToList();
            var statusDoneList = statusDone.Select(x => x.Key).ToList();
            var issuesDelivery = new List<DeliveryLastCycleIssueDeliveryDto>();
            var issuesInProgress = new List<DeliveryLastCycleIssueInProgressDto>();
            var impediments = new List<DeliveryLastCycleImpedimentDto>();
            var epics = new List<DeliveryLastCycleEpicDto>();
            var cycleTime = new List<DeliveryLastCycleCycleTimeDto>();

            foreach (var issue in search.Issues)
            {
                var issueBacklog = await GetBacklogData(issue.Key, cancellationToken);

                issuesDelivery.Add(CreateIssueInfo(issueBacklog, statusInProgressList, statusDoneList));
            }

            return CreateDeliveryLastCycleDto(initDate, endDate, issuesDelivery, issuesInProgress, impediments, epics, cycleTime);
        }

        private static DeliveryLastCycleDto CreateDeliveryLastCycleDto(DateTime initDate,
                                                                       DateTime endDate,
                                                                       IList<DeliveryLastCycleIssueDeliveryDto> issuesDelivery,
                                                                       IList<DeliveryLastCycleIssueInProgressDto> issuesInProgress,
                                                                       IList<DeliveryLastCycleImpedimentDto> impediments,
                                                                       IList<DeliveryLastCycleEpicDto> epics,
                                                                       IList<DeliveryLastCycleCycleTimeDto> cycleTime)
            => new()
            {
                StartDate = initDate,
                EndDate = endDate,
                Throughtput = issuesDelivery.Count,
                ThroughtputStoryPoints = issuesDelivery.Sum(x => x.StoryPoints),
                CustomerLeadTimeAverage = CalculateAverage(issuesDelivery, x => x.CustomerLeadTime),
                DiscoveryLeadTimeAverage = CalculateAverage(issuesDelivery, x => x.DiscoveryLeadTime),
                SystemLeadTimeAverage = CalculateAverage(issuesDelivery, x => x.SystemLeadTime),
                Feature = issuesDelivery.Count(x => x.IsFeature),
                Debits = issuesDelivery.Count(x => !x.IsFeature),
                FeaturePercent = CalculateTotalPercent(issuesDelivery, x => x.IsFeature),
                DebitsPercent = CalculateTotalPercent(issuesDelivery, x => !x.IsFeature),
                Standard = issuesDelivery.Count(x => x.ClassOfService == "Standard"),
                Expedite = issuesDelivery.Count(x => x.ClassOfService == "Expedite"),
                FixedDate = issuesDelivery.Count(x => x.ClassOfService == "Fixed Date"),
                Intangible = issuesDelivery.Count(x => x.ClassOfService == "Intangible"),
                StandardPercent = CalculateTotalPercent(issuesDelivery, x => x.ClassOfService == "Standard"),
                ExpeditePercent = CalculateTotalPercent(issuesDelivery, x => x.ClassOfService == "Expedite"),
                FixedDatePercent = CalculateTotalPercent(issuesDelivery, x => x.ClassOfService == "Fixed Date"),
                IntangiblePercent = CalculateTotalPercent(issuesDelivery, x => x.ClassOfService == "Intangible"),
                IssuesDelivery = issuesDelivery,
                IssuesInProgress = issuesInProgress,
                Impediments = impediments,
                Epics = epics,
                CycleTime = cycleTime,
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

        private DeliveryLastCycleIssueDeliveryDto CreateIssueInfo(DtoJira.IssueDto issue, IList<string> statusInProgress, IList<string> statusDone)
            => new()
            {
                Key = issue.Key,
                Description = issue.Fields.Summary,
                SystemLeadTime = CalculateLeadTime(issue.Changelog, statusInProgress, statusDone)
            };

        private async Task<DeliveryLastCycleIssueDeliveryDto> CreateIssuDeliveryeInfo(Issue issue, CancellationToken cancellationToken)
        {
            var inProgressSystemLeadTime = await GetSystemLeadTimeAsync(issue.Id, cancellationToken);

            decimal getStatusSystemLeadTime(long statusId) => inProgressSystemLeadTime.FirstOrDefault(x => x.Item1 == statusId)?.Item3 ?? 0;

            return new()
            {
                Key = issue.Key,
                IssueType = issue.IssueType.Name,
                Description = issue.Summary,
                ClassOfService = issue.ExtraData.ClassOfService?.Name ?? string.Empty,
                DiscoveryLeadTime = issue.ExtraData.DiscoveryLeadTime,
                SystemLeadTime = issue.ExtraData.SystemLeadTime,
                CustomerLeadTime = issue.ExtraData.CustomerLeadTime,
                StoryPoints = issue.ExtraData.StoryPoints,
                IsFeature = IsFeatureIssue(issue),
                IsIncident = issue.Incident,
                Link = issue.Link,
                InDevelop = getStatusSystemLeadTime(73),
                ToTest = getStatusSystemLeadTime(74),
                InTest = getStatusSystemLeadTime(75),
                ToHomolog = getStatusSystemLeadTime(76),
                InHomolog = getStatusSystemLeadTime(77),
            };
        }

        private async Task<DeliveryLastCycleIssueInProgressDto> CreateIssuInProgressInfo(Issue issue, CancellationToken cancellationToken)
        {
            var estimate = await CalculateEstimate(issue.Id, cancellationToken);

            return new()
            {
                Key = issue.Key,
                IssueType = issue.IssueType.Name,
                Description = issue.Summary,
                Status = issue.Status.Name,
                Age = issue.ExtraData.SystemLeadTime,
                ClassOfService = issue.ExtraData.ClassOfService?.Name ?? string.Empty,
                Estimate = estimate,
                EstimateStr = estimate.ToShortDateString(),
                StoryPoints = issue.ExtraData.StoryPoints,
                Impediment = issue.ExtraData.Impediment,
                IsIncident = issue.Incident,
                Labels = issue.Labels,
                Link = issue.Link,
            };
        }

        private async Task<IList<Tuple<long, string, decimal>>> GetSystemLeadTimeAsync(long issueId, CancellationToken cancellationToken)
        {
            var values = new List<Tuple<long, string, decimal>>();

            var histories = await issueStatusHistoryRepository.FindAllStatusCategoryInProgressAsync(issueId, cancellationToken);

            foreach (var history in histories)
            {
                var lastHistory = histories.FirstOrDefault(entity => entity.ToStatusId == history.FromStatusId);

                if (lastHistory == null)
                    continue;

                var time = (history.DateTime - lastHistory.DateTime).TotalDays;

                values.Add(new Tuple<long, string, decimal>(history.FromStatus.Id, history.FromStatus.Name, (decimal)Math.Round(time, 2)));
            }

            return values;
        }

        private decimal CalculateLeadTime(DtoJira.ChangelogDto changelog, IList<string> statusInProgress, IList<string> statusDone)
        {
            var dateInProgress = recoverDateTimeFirstStatusMatchBacklogHelper.GetDateTime(changelog, statusInProgress);
            var dateDone = recoverDateTimeFirstStatusMatchBacklogHelper.GetDateTime(changelog, statusDone);
            return businessDayHelper.Diff(dateInProgress.Value, dateDone.Value);
        }

        private async Task<DateTime> CalculateEstimate(long issueId, CancellationToken cancellationToken)
        {
            var dateInProgress = await issueStatusHistoryRepository.FindDateTimeFirstHistoryByStatusCategoryAsync(issueId, StatusCategories.InProgress, cancellationToken);

            if (dateInProgress == null)
                return DateTime.MinValue;

            var leadTime = 4;

            var estimate = dateInProgress.Value.AddBusinessDays(leadTime);

            return estimate;
        }

        private static bool IsFeatureIssue(Issue issue)
            => issue.IssueType != null
            && GetFeaturesIssueTypes().Any(issueType => issue.IssueType.Key == (long)issueType);

        private static long[] /*IssueTypes[]*/ GetFeaturesIssueTypes()
            => new long[]
            {
                10004, //IssueTypes.Story,
                10001, //IssueTypes.Task,
                10002, //IssueTypes.SubTask
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
                Status = issue.Status.Name,
                Time = impediment,
                Link = issue.Link,
            };
    }
}