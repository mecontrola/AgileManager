using FluentAssertions;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Repositories;
using Stefanini.ViaReport.Data.Enums;
using Stefanini.ViaReport.DataStorage.Repositories;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.DataStorage.Repositories
{
    public class IssueStatusHistoryRepositoryTests : BaseAsyncMethods
    {
        private readonly IIssueStatusHistoryRepository repository;

        public IssueStatusHistoryRepositoryTests()
        {
            repository = IssueStatusHistoryRepositoryMock.Create();
        }

        [Fact(DisplayName = "[IssueStatusHistoryRepository.ExistsByIssueAndStatusAsync] Deve retornar true quando encontrar o identificador da Issue e Status informado.")]
        public async void DeveRetornarImpedimentoComDataInicialDaIssueInformada()
        {
            var actual = await repository.ExistsByIssueAndStatusAsync(DataMock.INT_ID_1, DataMock.INT_ID_5, GetCancellationToken());

            actual.Should().BeTrue();
        }

        [Fact(DisplayName = "[IssueStatusHistoryRepository.FindDateTimeFirstHistoryByStatusCategoryAsync] Deve retornar o DateTime da primeira ocorrência da categoria de um Status informado.")]
        public async void DeveRetornarListaImpedimentoIssueDurantePeriodoInformado()
        {
            var actual = await repository.FindDateTimeFirstHistoryByStatusCategoryAsync(DataMock.INT_ID_1, StatusCategories.Done, GetCancellationToken());

            actual.Should().NotBeNull();
            actual.Should().Be(DataMock.DATETIME_FIRST_HISTORY_FINDED);
        }
    }
}