using MeControla.AgileManager.Core.Builders;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Parameters;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.Kernel.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services.Synchronizers.ExtraIssueData
{
    public class IssueEpicDataSynchronizerService : IIssueEpicDataSynchronizerService
    {
        private readonly IIssueRepository issueRepository;
        private readonly IIssueEpicRepository issueEpicRepository;
        private readonly IQuarterRepository quarterRepository;

        private readonly IIssueFieldsValidationHelper issueFieldsValidationHelper;

        public IssueEpicDataSynchronizerService(IIssueRepository issueRepository,
                                                IIssueEpicRepository issueEpicRepository,
                                                IQuarterRepository quarterRepository,
                                                IIssueFieldsValidationHelper issueFieldsValidationHelper)
        {
            this.issueRepository = issueRepository;
            this.issueEpicRepository = issueEpicRepository;
            this.quarterRepository = quarterRepository;
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
            entity.QuarterId = await GetQuarterId(issueDto.Fields.Labels, cancellationToken);

            await SaveIssueEpicChanges(entity, cancellationToken);
        }

        private static IssueEpic CreateEntityIssueEpic(long issueId)
            => IssueEpicBuilder.GetInstance()
                               .SetIssueId(issueId)
                               .ToBuild();

        private string SatinizeQuarter(IList<string> labels)
        {
            if (labels == null)
                return string.Empty;

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

        private async Task<long?> GetQuarterId(IList<string> labels, CancellationToken cancellationToken)
        {
            var labelQuarter = SatinizeQuarter(labels);

            if (string.IsNullOrWhiteSpace(labelQuarter))
                return null;

            var quarter = await quarterRepository.RetrieveByNameAsync(labelQuarter, cancellationToken);

            if (quarter == null)
                quarter = await CreateQuarterAsync(labelQuarter, cancellationToken);

            return quarter.Id;
        }

        private async Task<Quarter> CreateQuarterAsync(string name, CancellationToken cancellationToken)
        {
            var entity = QuarterBuilder.GetInstance()
                                       .SetName(name)
                                       .ToBuild();

            return await quarterRepository.CreateAsync(entity, cancellationToken);
        }
    }
}