using Stefanini.Core.Extensions;
using Stefanini.ViaReport.Core.Builders;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Data.Dtos.Jira;
using Stefanini.ViaReport.Data.Entities;
using Stefanini.ViaReport.Data.Parameters;
using Stefanini.ViaReport.DataStorage.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services.Synchronizers.ExtraIssueData
{
    public class IssueEpicDataSynchronizerService : IIssueEpicDataSynchronizerService
    {
        private readonly IIssueRepository issueRepository;
        private readonly IIssueEpicRepository issueEpicRepository;

        private readonly IIssueFieldsValidationHelper issueFieldsValidationHelper;

        public IssueEpicDataSynchronizerService(IIssueRepository issueRepository,
                                                IIssueEpicRepository issueEpicRepository,
                                                IIssueFieldsValidationHelper issueFieldsValidationHelper)
        {
            this.issueRepository = issueRepository;
            this.issueEpicRepository = issueEpicRepository;
            this.issueFieldsValidationHelper = issueFieldsValidationHelper;
        }

        public async Task Save(IssueSynchronizerParam parameters, CancellationToken cancellationToken)
        {
            if (!issueFieldsValidationHelper.IsEpicIssueType(parameters.IssueDto))
                return;

            var issue = await issueRepository.FindByKeyAsync(parameters.IssueDto.Key, cancellationToken);

            await SaveIssueEpic(issue.Id, parameters.IssueDto, cancellationToken);
        }

        private async Task SaveIssueEpic(long issueId, IssueDto issueDto, CancellationToken cancellationToken)
        {
            var entity = await issueEpicRepository.FindByIssueIdAsync(issueId, cancellationToken);

            if (entity == null)
                entity = CreateEntityIssueEpic(issueId);

            entity.Progress = issueDto.Fields.Customfield_15703.ToDecimal() ?? 0;
            entity.Quarter = SatinizeQuarter(issueDto.Fields.Labels);

            await SaveIssueEpicChanges(entity, cancellationToken);
        }

        private static IssueEpic CreateEntityIssueEpic(long issueId)
            => IssueEpicBuilder.GetInstance()
                               .SetIssueId(issueId)
                               .ToBuild();

        private string SatinizeQuarter(IList<string> labels)
        {
            var tmp = labels.Where(label => issueFieldsValidationHelper.IsLabelQuarter(label));

            if (!tmp.Any())
                return string.Empty;

            return tmp.Select(label => issueFieldsValidationHelper.SatinizeLabelQuarter(label))
                      .Distinct()
                      .Aggregate((a, b) => a + ',' + b);
        }

        private async Task SaveIssueEpicChanges(IssueEpic entity, CancellationToken cancellationToken)
        {
            if (entity.Id == 0)
                await issueEpicRepository.CreateAsync(entity, cancellationToken);
            else
                await issueEpicRepository.UpdateAsync(entity, cancellationToken);
        }
    }
}