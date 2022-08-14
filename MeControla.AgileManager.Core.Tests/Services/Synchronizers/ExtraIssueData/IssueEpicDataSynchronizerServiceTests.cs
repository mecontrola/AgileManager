using NSubstitute;
using MeControla.AgileManager.TestingTools;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.Services.Synchronizers.ExtraIssueData;
using MeControla.AgileManager.Core.Tests.Mocks;
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
    public class IssueEpicDataSynchronizerServiceTests : BaseAsyncMethods
    {
        private readonly IIssueRepository issueRepository;
        private readonly IIssueEpicRepository issueEpicRepository;
        private readonly IQuarterRepository quarterRepository;

        private readonly IIssueEpicDataSynchronizerService issueEpicDataSynchronizerService;

        public IssueEpicDataSynchronizerServiceTests()
        {
            var issueFieldsValidationHelper = new IssueFieldsValidationHelper();

            issueRepository = CreateIssueRepositoryMock();

            quarterRepository = CreateQuarterRepositoryMock();

            issueEpicRepository = Substitute.For<IIssueEpicRepository>();

            var logger = Substitute.For<ILogger<IssueEpicDataSynchronizerService>>();
            issueEpicDataSynchronizerService = new IssueEpicDataSynchronizerService(logger,
                                                                                    issueRepository,
                                                                                    issueEpicRepository,
                                                                                    quarterRepository,
                                                                                    issueFieldsValidationHelper);
        }

        [Fact(DisplayName = "[IssueEpicDataSynchronizerService.Save] Deve finalizar rotina quando a issue informada não for do tipo épico.")]
        public async void DeveFinalizarQuandoIssueNaoEpico()
        {
            await issueEpicDataSynchronizerService.Save(IssueSynchronizerParamMock.Create(), GetCancellationToken());

            await issueRepository.Received(0)
                                 .FindByKeyAsync(Arg.Any<string>(),
                                                 Arg.Any<CancellationToken>());

            await issueEpicRepository.Received(0)
                                     .CreateAsync(Arg.Any<IssueEpic>(),
                                                  Arg.Any<CancellationToken>());

            await issueEpicRepository.Received(0)
                                     .UpdateAsync(Arg.Any<IssueEpic>(),
                                                  Arg.Any<CancellationToken>());
        }

        private static IIssueRepository CreateIssueRepositoryMock()
        {
            var repository = Substitute.For<IIssueRepository>();

            repository.FindByKeyAsync(Arg.Any<string>(),
                                      Arg.Any<CancellationToken>())
                      .Returns(Task.FromResult(IssueMock.CreateAllFilledEpic()));

            return repository;
        }

        private static IQuarterRepository CreateQuarterRepositoryMock()
        {
            var repository = Substitute.For<IQuarterRepository>();

            repository.RetrieveByNameAsync(Arg.Any<string>(),
                                           Arg.Any<CancellationToken>())
                      .Returns(Task.FromResult(QuarterMock.CreateQ12000()));

            return repository;
        }

        [Fact(DisplayName = "[IssueEpicDataSynchronizerService.Save] Deve criar a informação do épico quando a issue for do tipo épico e a informação não existir.")]
        public async void DeveCriarQuandoIssueEpicoEInformacaoNaoExistir()
        {
            issueEpicRepository.FindByIssueIdAsync(Arg.Any<long>(),
                                                   Arg.Any<CancellationToken>())
                               .Returns(Task.FromResult<IssueEpic>(null));

            await issueEpicDataSynchronizerService.Save(IssueSynchronizerParamMock.CreateEpic(), GetCancellationToken());

            await issueEpicRepository.Received(1)
                                     .CreateAsync(Arg.Any<IssueEpic>(),
                                                  Arg.Any<CancellationToken>());

            await issueEpicRepository.Received(0)
                                     .UpdateAsync(Arg.Any<IssueEpic>(),
                                                  Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "[IssueEpicDataSynchronizerService.Save] Deve atualizar a informação do épico quando a issue for do tipo épico e a informação existir.")]
        public async void DeveAtualizarQuandoIssueEpicoEInformacaoExistir()
        {
            var paramEpic = IssueSynchronizerParamMock.CreateEpic();
            paramEpic.IssueDto.Fields.Labels = new string[] { DataMock.TEXT_QUARTER_1_2000 };

            issueEpicRepository.FindByIssueIdAsync(Arg.Any<long>(),
                                                   Arg.Any<CancellationToken>())
                               .Returns(Task.FromResult(IssueEpicMock.Create()));

            await issueEpicDataSynchronizerService.Save(paramEpic, GetCancellationToken());

            await issueEpicRepository.Received(0)
                                     .CreateAsync(Arg.Any<IssueEpic>(),
                                                  Arg.Any<CancellationToken>());

            await issueEpicRepository.Received(1)
                                     .UpdateAsync(Arg.Any<IssueEpic>(),
                                                  Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "[IssueEpicDataSynchronizerService.Save] Deve atualizar a informação do épico quando a issue for do tipo épico, lista de quarters for vazia e a informação existir.")]
        public async void DeveAtualizarQuandoIssueEpicoEInformacaoExistirEListaQuartersVazia()
        {
            var paramEpic = IssueSynchronizerParamMock.CreateEpic();
            paramEpic.IssueDto.Fields.Labels = Array.Empty<string>();

            issueEpicRepository.FindByIssueIdAsync(Arg.Any<long>(),
                                                   Arg.Any<CancellationToken>())
                               .Returns(Task.FromResult(IssueEpicMock.Create()));

            await issueEpicDataSynchronizerService.Save(paramEpic, GetCancellationToken());

            await issueEpicRepository.Received(0)
                                     .CreateAsync(Arg.Any<IssueEpic>(),
                                                  Arg.Any<CancellationToken>());

            await issueEpicRepository.Received(1)
                                     .UpdateAsync(Arg.Any<IssueEpic>(),
                                                  Arg.Any<CancellationToken>());
        }
    }
}