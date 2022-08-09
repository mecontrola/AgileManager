using MeControla.AgileManager.Core.Builders.Dtos;
using MeControla.AgileManager.Core.Services.Synchronizers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public class SynchronizerService : ISynchronizerService
    {
        private readonly IProjectService projectService;
        private readonly ISettingsService settingsService;
        private readonly IEnumerable<IBaseSynchronizerService> synchronizerServices;

        public SynchronizerService(IProjectService projectService,
                                   ISettingsService settingsService,
                                   IProjectSynchronizerService projectSynchronizerService,
                                   IStatusCategorySynchronizerService statusCategorySynchronizerService,
                                   IStatusSynchronizerService statusSynchronizerService,
                                   IIssueTypeSynchronizerService issueTypeSynchronizerService,
                                   IIssueSynchronizerService issueSynchronizerService)
        {
            this.projectService = projectService;
            this.settingsService = settingsService;
            this.synchronizerServices = new List<IBaseSynchronizerService>
            {
                projectSynchronizerService,
                statusCategorySynchronizerService,
                statusSynchronizerService,
                issueTypeSynchronizerService,
                issueSynchronizerService
            };
        }

        public async Task SynchronizeDataAsync(CancellationToken cancellationToken)
        {
            var projects = await projectService.LoadSelectedIdsAsync(cancellationToken);
            var settings = await settingsService.LoadDataAsync(cancellationToken);

            var configuration = IssueConfigurationSynchronizerDtoBuilder.GetInstance()
                                                                        .AddSettings(settings)
                                                                        .AddProjects(projects)
                                                                        .ToBuild();

            foreach (var synchronizer in synchronizerServices)
                await synchronizer.SynchronizeData(configuration, cancellationToken);
        }
    }
}