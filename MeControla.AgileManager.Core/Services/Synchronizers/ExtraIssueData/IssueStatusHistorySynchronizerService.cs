using MeControla.AgileManager.Core.Builders;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Parameters;
using MeControla.AgileManager.DataStorage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services.Synchronizers.ExtraIssueData
{
    public class IssueStatusHistorySynchronizerService : IIssueStatusHistorySynchronizerService
    {
        private readonly IIssueRepository issueRepository;
        private readonly IIssueStatusHistoryRepository issueStatusHistoryRepository;

        private readonly ICheckChangelogTypeHelper checkChangelogTypeHelper;

        public IssueStatusHistorySynchronizerService(IIssueRepository issueRepository,
                                                     IIssueStatusHistoryRepository issueStatusHistoryRepository,
                                                     ICheckChangelogTypeHelper checkChangelogTypeHelper)
        {
            this.issueRepository = issueRepository;
            this.issueStatusHistoryRepository = issueStatusHistoryRepository;
            this.checkChangelogTypeHelper = checkChangelogTypeHelper;
        }

        public async Task Save(IssueSynchronizerParam parameters, CancellationToken cancellationToken)
        {
            var statusesInIssue = SatinizeHistory(parameters.IssueDto.Changelog, parameters.Statuses);

            var issue = await issueRepository.FindByKeyAsync(parameters.IssueDto.Key, cancellationToken);

            await SaveIssueStatusHistory(issue.Id, statusesInIssue, cancellationToken);
        }

        private IDictionary<long, DateTime> SatinizeHistory(ChangelogDto changelog, IDictionary<string, long> statuses)
            => changelog.Histories
                        .Select(itm => new
                        {
                            DateTime = itm.Created,
                            StatusId = SatinizeHistorySwap(itm, statuses)
                        })
                        .Where(x => x.StatusId.HasValue)
                        .GroupBy(x => x.StatusId)
                        .Select(x => x.FirstOrDefault())
                        .ToDictionary(x => x.StatusId.Value, x => x.DateTime);

        private long? SatinizeHistorySwap(HistoryDto history, IDictionary<string, long> statuses)
        {
            foreach (var itm in history.Items)
            {
                if (checkChangelogTypeHelper.IsFieldStatus(itm) && statuses.TryGetValue(itm.To, out long statusId))
                    return statusId;

                continue;
            }

            return null;
        }

        private async Task SaveIssueStatusHistory(long issueId, IDictionary<long, DateTime> statuses, CancellationToken cancellationToken)
        {
            foreach (var status in statuses)
                await SaveIssueStatusHistorySwap(issueId, status.Key, status.Value, cancellationToken);
        }

        private async Task SaveIssueStatusHistorySwap(long issueId, long statusId, DateTime dateTime, CancellationToken cancellationToken)
        {
            if (await issueStatusHistoryRepository.ExistsByIssueAndStatusAsync(issueId, statusId, cancellationToken))
                return;

            var entity = IssueStatusHistoryBuilder.GetInstance()
                                                  .SetDateTime(dateTime)
                                                  .SetIssueId(issueId)
                                                  .SetStatusId(statusId)
                                                  .ToBuild();

            await issueStatusHistoryRepository.CreateAsync(entity, cancellationToken);
        }
    }
}