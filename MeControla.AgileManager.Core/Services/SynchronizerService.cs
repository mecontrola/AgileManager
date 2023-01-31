using MeControla.AgileManager.Core.Builders.Dtos;
using MeControla.AgileManager.Core.Services.Synchronizers;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public class SynchronizerService : ISynchronizerService
    {
        private readonly ILogger<SynchronizerService> logger;

        private readonly IProjectService projectService;
        private readonly ISettingsService settingsService;
        private readonly IEnumerable<IBaseSynchronizerService> synchronizerServices;

        public SynchronizerService(ILogger<SynchronizerService> logger,
                                   IProjectService projectService,
                                   ISettingsService settingsService,
                                   ICustomfieldSynchronizerService fieldSynchronizerService,
                                   IClassOfServiceSynchronizerService classesOfServiceSynchronizerService,
                                   IProjectSynchronizerService projectSynchronizerService,
                                   IStatusCategorySynchronizerService statusCategorySynchronizerService,
                                   IStatusSynchronizerService statusSynchronizerService,
                                   IIssueTypeSynchronizerService issueTypeSynchronizerService,
                                   IIssueSynchronizerService issueSynchronizerService)
        {
            this.logger = logger;

            this.projectService = projectService;
            this.settingsService = settingsService;
            this.synchronizerServices = new List<IBaseSynchronizerService>
            {
                fieldSynchronizerService,
                classesOfServiceSynchronizerService,
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

            logger.LogInformation("[Synchronize] Start.");

            foreach (var synchronizer in synchronizerServices)
                await synchronizer.SynchronizeData(configuration, cancellationToken);

            logger.LogInformation("[Synchronize] Stop.");
        }
    }
}