using NSubstitute;
using MeControla.AgileManager.TestingTools;
using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Services.Synchronizers;
using MeControla.AgileManager.Core.Tests.Mocks.Services;
using MeControla.AgileManager.Data.Dtos.Synchronizers;
using System.Threading;
using Xunit;
using Microsoft.Extensions.Logging;

namespace MeControla.AgileManager.Core.Tests.Services.Synchronizers
{
    public class SynchronizerServiceTests : BaseAsyncMethods
    {
        private readonly ICustomfieldSynchronizerService customfieldSynchronizerService;
        private readonly IProjectSynchronizerService projectSynchronizerService;
        private readonly IStatusCategorySynchronizerService statusCategorySynchronizerService;
        private readonly IStatusSynchronizerService statusSynchronizerService;
        private readonly IIssueTypeSynchronizerService issueTypeSynchronizerService;
        private readonly IIssueSynchronizerService issueSynchronizerService;

        private readonly ISynchronizerService service;

        public SynchronizerServiceTests()
        {
            var projectService = ProjectServiceMock.Create();
            var settingsService = SettingsServiceMock.Create();

            var logger = Substitute.For<ILogger<SynchronizerService>>();

            customfieldSynchronizerService = Substitute.For<ICustomfieldSynchronizerService>();
            projectSynchronizerService = Substitute.For<IProjectSynchronizerService>();
            statusCategorySynchronizerService = Substitute.For<IStatusCategorySynchronizerService>();
            statusSynchronizerService = Substitute.For<IStatusSynchronizerService>();
            issueTypeSynchronizerService = Substitute.For<IIssueTypeSynchronizerService>();
            issueSynchronizerService = Substitute.For<IIssueSynchronizerService>();

            service = new SynchronizerService(logger,
                                              projectService,
                                              settingsService,
                                              customfieldSynchronizerService,
                                              projectSynchronizerService,
                                              statusCategorySynchronizerService,
                                              statusSynchronizerService,
                                              issueTypeSynchronizerService,
                                              issueSynchronizerService);
        }

        [Fact(DisplayName = "[SynchronizerService.SynchronizeData] Deve executar todas as rotinas de sincronização.")]
        public async void DeveExecutarTodasRotinasSincronizacao()
        {
            await service.SynchronizeDataAsync(GetCancellationToken());

            await projectSynchronizerService.Received()
                                            .SynchronizeData(Arg.Any<IssueConfigurationSynchronizerDto>(),
                                                             Arg.Any<CancellationToken>());

            await statusCategorySynchronizerService.Received()
                                                   .SynchronizeData(Arg.Any<IssueConfigurationSynchronizerDto>(),
                                                                    Arg.Any<CancellationToken>());

            await statusSynchronizerService.Received()
                                           .SynchronizeData(Arg.Any<IssueConfigurationSynchronizerDto>(),
                                                            Arg.Any<CancellationToken>());

            await issueTypeSynchronizerService.Received()
                                              .SynchronizeData(Arg.Any<IssueConfigurationSynchronizerDto>(),
                                                               Arg.Any<CancellationToken>());

            await issueSynchronizerService.Received()
                                          .SynchronizeData(Arg.Any<IssueConfigurationSynchronizerDto>(),
                                                           Arg.Any<CancellationToken>());
        }
    }
}