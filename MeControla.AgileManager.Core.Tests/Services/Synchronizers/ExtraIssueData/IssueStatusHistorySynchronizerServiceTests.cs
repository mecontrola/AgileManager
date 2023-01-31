using NSubstitute;
using MeControla.AgileManager.TestingTools;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.Services.Synchronizers.ExtraIssueData;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Entities;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Parameters;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.DataStorage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.Logging;

namespace MeControla.AgileManager.Core.Tests.Services.Synchronizers.ExtraIssueData
{
    public class IssueStatusHistorySynchronizerServiceTests : BaseAsyncMethods
    {
        private readonly IIssueRepository issueRepository;
        private readonly IIssueStatusHistoryRepository issueStatusHistoryRepository;

        private readonly IIssueStatusHistorySynchronizerService issueDataSynchronizerService;

        public IssueStatusHistorySynchronizerServiceTests()
        {
            var checkChangelogTypeHelper = new CheckChangelogTypeHelper();

            issueRepository = CreateIssueRepositoryMock();

            issueStatusHistoryRepository = Substitute.For<IIssueStatusHistoryRepository>();

            var logger = Substitute.For<ILogger<IssueStatusHistorySynchronizerService>>();
            issueDataSynchronizerService = new IssueStatusHistorySynchronizerService(logger,
                                                                                     issueRepository,
                                                                                     issueStatusHistoryRepository,
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

        [Fact(DisplayName = "[IssueStatusHistorySynchronizerService.Save] Deve adicionar as informações do histórico da issue quando não existirem os dados no banco de dados.")]
        public async void DeveAdicionarIssueInexistente()
        {
            SetExistsByIssueAndStatusAsyncReturns(false);

            await issueDataSynchronizerService.Save(IssueSynchronizerParamMock.Create(), GetCancellationToken());

            await issueStatusHistoryRepository.Received(1)
                                              .CreateAsync(Arg.Any<IssueStatusHistory>(),
                                                           Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "[IssueStatusHistorySynchronizerService.Save] Deve encerrar a adicação das informações do histórico da issue quando existirem os dados no banco de dados.")]
        public async void DeveAtualizarIssueExistente()
        {
            SetExistsByIssueAndStatusAsyncReturns(true);

            await issueDataSynchronizerService.Save(IssueSynchronizerParamMock.Create(), GetCancellationToken());

            await issueStatusHistoryRepository.Received(0)
                                              .CreateAsync(Arg.Any<IssueStatusHistory>(),
                                                           Arg.Any<CancellationToken>());
        }

        private void SetExistsByIssueAndStatusAsyncReturns(bool value)
        {
            issueStatusHistoryRepository.ExistsByIssueAndStatusAsync(Arg.Any<long>(),
                                                                     Arg.Any<long>(), 
                                                                     Arg.Any<CancellationToken>())
                                        .Returns(Task.FromResult(value));
        }
    }
}