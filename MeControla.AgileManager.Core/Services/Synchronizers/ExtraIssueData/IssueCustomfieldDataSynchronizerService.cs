using MeControla.AgileManager.Core.Builders;
using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Parameters;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.Kernel.Extensions;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services.Synchronizers.ExtraIssueData
{
    public class IssueCustomfieldDataSynchronizerService : IIssueCustomfieldDataSynchronizerService
    {
        private readonly ILogger<IssueCustomfieldDataSynchronizerService> logger;

        private readonly ICustomfieldRepository customfieldRepository;
        private readonly IIssueRepository issueRepository;
        private readonly IIssueCustomfieldDataRepository issueCustomfieldDataRepository;

        public IssueCustomfieldDataSynchronizerService(ILogger<IssueCustomfieldDataSynchronizerService> logger,
                                                       ICustomfieldRepository customfieldRepository,
                                                       IIssueRepository issueRepository,
                                                       IIssueCustomfieldDataRepository issueCustomfieldDataRepository)
        {
            this.logger = logger;
            this.customfieldRepository = customfieldRepository;
            this.issueRepository = issueRepository;
            this.issueCustomfieldDataRepository = issueCustomfieldDataRepository;
        }

        public async Task Save(IssueSynchronizerParam parameters, CancellationToken cancellationToken)
        {
            logger.LogInformation($"[Synchronize] Synchronizing Issue Customfields Data {parameters.IssueDto.Key}.");

            var issue = await issueRepository.FindByKeyAsync(parameters.IssueDto.Key, cancellationToken);
            var customfields = await customfieldRepository.RetrieveActiveListAsync(cancellationToken);

            foreach (var customfield in customfields)
                await SaveCustomfield(customfield, issue.Id, parameters.IssueDto.Fields, cancellationToken);

            logger.LogInformation($"[Synchronize] Synchronizing Issue Customfields Data {parameters.IssueDto.Key}.");
        }

        private async Task SaveCustomfield(Customfield customfield, long issueId, IssueFieldsDto fields, CancellationToken cancellationToken)
        {
            var value = GetValueFromCustomfield(fields, customfield.Key);

            await SaveCustomfieldSwap(customfield.Id, issueId, value, cancellationToken);
        }

        private async Task SaveCustomfieldSwap(long customfieldId, long issueId, string value, CancellationToken cancellationToken)
        {
            var entity = await issueCustomfieldDataRepository.RetrieveByCustomfieldAndIssueAsync(customfieldId, issueId, cancellationToken);

            if (entity == null)
                entity = IssueCustomfieldDataBuilder.GetInstance()
                                                    .SetCustomfieldId(customfieldId)
                                                    .SetIssueId(issueId)
                                                    .ToBuild();

            entity.Value = value;

            if (entity.Id == 0)
                await issueCustomfieldDataRepository.CreateAsync(entity, cancellationToken);
            else
                await issueCustomfieldDataRepository.UpdateAsync(entity, cancellationToken);
        }

        private static string GetValueFromCustomfield(IssueFieldsDto fields, string propertyName)
        {
            var property = fields.GetType().GetProperty(propertyName.ToFirstUpper());

            if (property == null)
                return string.Empty;

            return property.GetValue(fields)?.ToString() ?? string.Empty;
        }
    }
}