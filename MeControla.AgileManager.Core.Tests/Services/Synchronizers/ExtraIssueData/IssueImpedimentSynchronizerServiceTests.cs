using NSubstitute;
using MeControla.AgileManager.TestingTools;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.Services.Synchronizers.ExtraIssueData;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Entities;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Parameters;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.DataStorage.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.Logging;

namespace MeControla.AgileManager.Core.Tests.Services.Synchronizers.ExtraIssueData
{
    public class IssueImpedimentSynchronizerServiceTests : BaseAsyncMethods
    {
        private readonly IIssueRepository issueRepository;
        private readonly IIssueImpedimentRepository issueImpedimentRepository;

        private readonly IIssueImpedimentSynchronizerService issueImpedimentSynchronizerService;

        public IssueImpedimentSynchronizerServiceTests()
        {
            var checkChangelogTypeHelper = new CheckChangelogTypeHelper();

            issueRepository = CreateIssueRepositoryMock();

            issueImpedimentRepository = Substitute.For<IIssueImpedimentRepository>();

            var logger = Substitute.For<ILogger<IssueImpedimentSynchronizerService>>();
            issueImpedimentSynchronizerService = new IssueImpedimentSynchronizerService(logger,
                                                                                        issueRepository,
                                                                                        issueImpedimentRepository,
                                                                                        checkChangelogTypeHelper);
        }

        private static IIssueRepository CreateIssueRepositoryMock()
        {
            var repository = Substitute.For<IIssueRepository>();
            repository.FindByKeyAsync(Arg.Any<string>(),
                                      Arg.Any<CancellationToken>())
                      .Returns(Task.FromResult(IssueMock.CreateAllFilledStory()));

            return repository;
        }

        [Fact(DisplayName = "[IssueImpedimentSynchronizerService.Save] Deve finalizar rotina quando a issue informada não tiver impedimentos reportados.")]
        public async void DeveFinalizarQuandoNaoTiverImpedimento()
        {
            var paramEpic = IssueSynchronizerParamMock.CreateEpic();
            paramEpic.IssueDto.Changelog = ChangelogDtoMock.CreateEmpty();

            await issueImpedimentSynchronizerService.Save(paramEpic, GetCancellationToken());

            await issueRepository.Received(0)
                                 .FindByKeyAsync(Arg.Any<string>(),
                                                 Arg.Any<CancellationToken>());

            await issueImpedimentRepository.Received(0)
                                           .RetrieveByIssueAndStartAsync(Arg.Any<long>(),
                                                                         Arg.Any<DateTime>(),
                                                                         Arg.Any<CancellationToken>());

            await issueImpedimentRepository.Received(0)
                                           .CreateAsync(Arg.Any<IssueImpediment>(),
                                                        Arg.Any<CancellationToken>());

            await issueImpedimentRepository.Received(0)
                                           .UpdateAsync(Arg.Any<IssueImpediment>(),
                                                        Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "[IssueImpedimentSynchronizerService.Save] Deve criar a informação do impedimento quando existir impedimento em aberto reportado.")]
        public async void DeveCriarQuandoImpedimentoNaoExistir()
        {
            await issueImpedimentSynchronizerService.Save(IssueSynchronizerParamMock.CreateEpic(), GetCancellationToken());

            await issueRepository.Received(1)
                                 .FindByKeyAsync(Arg.Any<string>(),
                                                 Arg.Any<CancellationToken>());

            await issueImpedimentRepository.Received(1)
                                           .RetrieveByIssueAndStartAsync(Arg.Any<long>(),
                                                                         Arg.Any<DateTime>(),
                                                                         Arg.Any<CancellationToken>());

            await issueImpedimentRepository.Received(1)
                                           .CreateAsync(Arg.Any<IssueImpediment>(),
                                                        Arg.Any<CancellationToken>());

            await issueImpedimentRepository.Received(0)
                                           .UpdateAsync(Arg.Any<IssueImpediment>(),
                                                        Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "[IssueImpedimentSynchronizerService.Save] Deve criar a informação do impedimento quando existir impedimento em aberto reportado.")]
        public async void DeveAtualizarQuandoImpedimentoEncerado()
        {
            issueImpedimentRepository.RetrieveByIssueAndStartAsync(Arg.Any<long>(),
                                                                   Arg.Any<DateTime>(),
                                                                   Arg.Any<CancellationToken>())
                                     .Returns(Task.FromResult(IssueImpedimentMock.CreateByDataBase()));

            var paramEpic = IssueSynchronizerParamMock.CreateEpic();
            paramEpic.IssueDto.Changelog.Histories.Add(HistoryDtoMock.CreateImpedimentClose());

            await issueImpedimentSynchronizerService.Save(paramEpic, GetCancellationToken());

            await issueRepository.Received(1)
                                 .FindByKeyAsync(Arg.Any<string>(),
                                                 Arg.Any<CancellationToken>());

            await issueImpedimentRepository.Received(1)
                                           .RetrieveByIssueAndStartAsync(Arg.Any<long>(),
                                                                         Arg.Any<DateTime>(),
                                                                         Arg.Any<CancellationToken>());

            await issueImpedimentRepository.Received(0)
                                           .CreateAsync(Arg.Any<IssueImpediment>(),
                                                        Arg.Any<CancellationToken>());

            await issueImpedimentRepository.Received(1)
                                           .UpdateAsync(Arg.Any<IssueImpediment>(),
                                                        Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "[IssueImpedimentSynchronizerService.Save] Deve finalizar rotina quando a issue informada tiver impedimentos reportados finalizados.")]
        public async void DeveFinalizarQuandoTiverImpedimentoFinalizado()
        {
            issueImpedimentRepository.RetrieveByIssueAndStartAsync(Arg.Any<long>(),
                                                                   Arg.Any<DateTime>(),
                                                                   Arg.Any<CancellationToken>())
                                     .Returns(Task.FromResult(IssueImpedimentMock.Create()));

            var paramEpic = IssueSynchronizerParamMock.CreateEpic();
            paramEpic.IssueDto.Changelog.Histories.Add(HistoryDtoMock.CreateImpedimentClose());

            await issueImpedimentSynchronizerService.Save(paramEpic, GetCancellationToken());

            await issueRepository.Received(1)
                                 .FindByKeyAsync(Arg.Any<string>(),
                                                 Arg.Any<CancellationToken>());

            await issueImpedimentRepository.Received(1)
                                           .RetrieveByIssueAndStartAsync(Arg.Any<long>(),
                                                                         Arg.Any<DateTime>(),
                                                                         Arg.Any<CancellationToken>());

            await issueImpedimentRepository.Received(0)
                                           .CreateAsync(Arg.Any<IssueImpediment>(),
                                                        Arg.Any<CancellationToken>());

            await issueImpedimentRepository.Received(0)
                                           .UpdateAsync(Arg.Any<IssueImpediment>(),
                                                        Arg.Any<CancellationToken>());
        }
    }
}