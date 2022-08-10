using MeControla.AgileManager.Core.Builders;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Parameters;
using MeControla.AgileManager.DataStorage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services.Synchronizers.ExtraIssueData
{
    public class IssueImpedimentSynchronizerService : IIssueImpedimentSynchronizerService
    {
        private readonly IIssueRepository issueRepository;
        private readonly IIssueImpedimentRepository issueImpedimentRepository;

        private readonly ICheckChangelogTypeHelper checkChangelogTypeHelper;

        public IssueImpedimentSynchronizerService(IIssueRepository issueRepository,
                                                  IIssueImpedimentRepository issueImpedimentRepository,
                                                  ICheckChangelogTypeHelper checkChangelogTypeHelper)
        {
            this.issueRepository = issueRepository;
            this.issueImpedimentRepository = issueImpedimentRepository;
            this.checkChangelogTypeHelper = checkChangelogTypeHelper;
        }

        public async Task Save(IssueSynchronizerParam parameters, CancellationToken cancellationToken)
        {
            var impedimentsInIssue = SatinizeImpediment(parameters.IssueDto.Changelog);

            if (!impedimentsInIssue.Any())
                return;

            var issue = await issueRepository.FindByKeyAsync(parameters.IssueDto.Key, cancellationToken);

            await SaveIssueImpediment(issue.Id, impedimentsInIssue, cancellationToken);
        }

        private IDictionary<DateTime, DateTime?> SatinizeImpediment(ChangelogDto changelog)
        {
            var data = new Dictionary<DateTime, DateTime?>();
            var impediments = changelog.Histories
                                       .Where(itm => IsHistoryImpediment(itm))
                                       .Select(itm => new
                                       {
                                           DateTime = itm.Created,
                                           Started = IsStartImpediment(itm)
                                       })
                                       .OrderBy(itm => itm.DateTime)
                                       .ToArray();
            DateTime? timeSwap = null;
            for (int i = 0, l = impediments.Length; i < l; i++)
            {
                if (impediments[i].Started)
                {
                    timeSwap = impediments[i].DateTime;
                    data.Add(timeSwap.Value, null);
                }
                else if (timeSwap.HasValue)
                    data[timeSwap.Value] = impediments[i].DateTime;
            }

            return data;
        }

        private static bool IsStartImpediment(HistoryDto history)
        {
            foreach (var itm in history.Items)
            {
                if (!string.IsNullOrWhiteSpace(itm.To))
                    return true;

                continue;
            }

            return false;
        }

        private bool IsHistoryImpediment(HistoryDto history)
            => history.Items
                      .Any(itm => checkChangelogTypeHelper.IsFieldFlagged(itm));

        private async Task SaveIssueImpediment(long issueId, IDictionary<DateTime, DateTime?> impediments, CancellationToken cancellationToken)
        {
            foreach (var impediment in impediments)
                await SaveIssueImpedimentSwap(issueId, impediment.Key, impediment.Value, cancellationToken);
        }

        private async Task SaveIssueImpedimentSwap(long issueId, DateTime impedimentStart, DateTime? impedimentEnd, CancellationToken cancellationToken)
        {
            var entity = await issueImpedimentRepository.RetrieveByIssueAndStartAsync(issueId, impedimentStart, cancellationToken);

            if (entity != null && entity.End.HasValue)
                return;

            if (entity == null)
                await CreateIssueImpediment(issueId, impedimentStart, impedimentEnd, cancellationToken);
            else
                await UpdateIssueImpediment(entity, impedimentEnd, cancellationToken);
        }

        private async Task CreateIssueImpediment(long issueId, DateTime impedimentStart, DateTime? impedimentEnd, CancellationToken cancellationToken)
        {
            var entity = IssueImpedimentBuilder.GetInstance()
                                               .SetStart(impedimentStart)
                                               .SetEnd(impedimentEnd)
                                               .SetIssueId(issueId)
                                               .ToBuild();

            await issueImpedimentRepository.CreateAsync(entity, cancellationToken);
        }

        private async Task UpdateIssueImpediment(IssueImpediment entity, DateTime? impedimentEnd, CancellationToken cancellationToken)
        {
            entity.End = impedimentEnd;

            await issueImpedimentRepository.UpdateAsync(entity, cancellationToken);
        }
    }
}