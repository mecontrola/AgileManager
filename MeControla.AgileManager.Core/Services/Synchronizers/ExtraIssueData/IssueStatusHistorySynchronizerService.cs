using MeControla.AgileManager.Core.Builders;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Data.Parameters;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services.Synchronizers.ExtraIssueData
{
    public class IssueStatusHistorySynchronizerService : IIssueStatusHistorySynchronizerService
    {
        private readonly ILogger<IssueStatusHistorySynchronizerService> logger;

        private readonly IIssueRepository issueRepository;
        private readonly IIssueStatusHistoryRepository issueStatusHistoryRepository;

        private readonly ICheckChangelogTypeHelper checkChangelogTypeHelper;

        public IssueStatusHistorySynchronizerService(ILogger<IssueStatusHistorySynchronizerService> logger,
                                                     IIssueRepository issueRepository,
                                                     IIssueStatusHistoryRepository issueStatusHistoryRepository,
                                                     ICheckChangelogTypeHelper checkChangelogTypeHelper)
        {
            this.logger = logger;
            this.issueRepository = issueRepository;
            this.issueStatusHistoryRepository = issueStatusHistoryRepository;
            this.checkChangelogTypeHelper = checkChangelogTypeHelper;
        }

        public async Task Save(IssueSynchronizerParam parameters, CancellationToken cancellationToken)
        {
            logger.LogInformation($"[Synchronize] Synchronizing Issue Status History Data {parameters.IssueDto.Key}.");

            var statusesInIssue = SatinizeHistory(parameters.IssueDto.Changelog, parameters.Statuses);

            var issue = await issueRepository.FindByKeyAsync(parameters.IssueDto.Key, cancellationToken);

            await SaveIssueStatusHistory(issue.Id, statusesInIssue, cancellationToken);

            logger.LogInformation($"[Synchronize] Synchronized Issue Status History Data {parameters.IssueDto.Key}.");
        }

        private IList<Tuple<long, long, DateTime>> SatinizeHistory(ChangelogDto changelog, IDictionary<string, long> statuses)
        {
            var aux = changelog.Histories
                        .Select(itm => new
                        {
                            DateTime = itm.Created,
                            FromStatusId = SatinizeHistorySwap(itm, statuses, dto => dto.From),
                            ToStatusId = SatinizeHistorySwap(itm, statuses, dto => dto.To),
                        })
                        .Where(x => x.FromStatusId.HasValue);


            return aux.Select(x => new Tuple<long, long, DateTime>(x.FromStatusId.Value, x.ToStatusId.Value, x.DateTime))
                        .ToList();
        }

        private long? SatinizeHistorySwap(HistoryDto history, IDictionary<string, long> statuses, Func<HistoryItemDto, string> checkValue)
        {
            foreach (var itm in history.Items)
            {
                if (checkChangelogTypeHelper.IsFieldStatus(itm) && statuses.TryGetValue(checkValue(itm), out long statusId))
                    return statusId;

                continue;
            }

            return null;
        }

        private async Task SaveIssueStatusHistory(long issueId, IList<Tuple<long, long, DateTime>> statuses, CancellationToken cancellationToken)
        {
            foreach ((long fromStatusId, long toStatusId, DateTime dateTime) in statuses)
                await SaveIssueStatusHistorySwap(issueId, fromStatusId, toStatusId, dateTime, cancellationToken);
        }

        private async Task SaveIssueStatusHistorySwap(long issueId, long fromStatusId, long toStatusId, DateTime dateTime, CancellationToken cancellationToken)
        {
            if (await issueStatusHistoryRepository.ExistsByIssueAndStatusAsync(issueId, toStatusId, cancellationToken))
                return;

            var entity = IssueStatusHistoryBuilder.GetInstance()
                                                  .SetDateTime(dateTime)
                                                  .SetIssueId(issueId)
                                                  .SetFromStatusId(fromStatusId)
                                                  .SetToStatusId(toStatusId)
                                                  .ToBuild();

            await issueStatusHistoryRepository.CreateAsync(entity, cancellationToken);

            if (toStatusId != 58)
                return;

            var issue = await issueRepository.FindAsync(issueId, cancellationToken);
            issue.Resolved = dateTime;

            await issueRepository.UpdateAsync(issue, cancellationToken);
        }
    }
}