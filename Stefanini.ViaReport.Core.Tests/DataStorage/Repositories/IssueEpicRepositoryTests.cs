using FluentAssertions;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities;
using Stefanini.ViaReport.Core.Tests.Mocks.Repositories;
using Stefanini.ViaReport.DataStorage.Repositories;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.DataStorage.Repositories
{
    public class IssueEpicRepositoryTests : BaseAsyncMethods
    {
        private readonly IIssueEpicRepository repository;

        public IssueEpicRepositoryTests()
        {
            repository = IssueEpicRepositoryMock.Create();
        }

        [Fact(DisplayName = "[IssueEpicRepository.FindByIssueIdAsync] Deve retornar o épico cadastrado de acordo com o identificador da Issue informada.")]
        public async void DeveRetornarEpicoDaIssueInformada()
        {
            var expected = IssueEpicMock.CreateByDataBase();
            var actual = await repository.FindByIssueIdAsync(expected.IssueId, GetCancellationToken());

            actual.Should().NotBeNull();
            actual.Quarter.Should().Be(expected.Quarter);
            actual.Progress.Should().Be(expected.Progress);
            actual.IssueId.Should().Be(expected.IssueId);
        }

        [Fact(DisplayName = "[IssueEpicRepository.RetrieveByDateRangeAsync] Deve retornar a lista de épicos de acordo com o projeto e quarter informado.")]
        public async void DeveRetornarListaEpicosIssueDoProjetoEQuanterInformado()
        {
            var expected = IssueEpicMock.CreateByDataBase();
            var actual = await repository.RetrieveByQuarterAsync(expected.Issue.ProjectId, expected.Quarter, GetCancellationToken());

            actual.Should().HaveCount(1);
            actual[0].Should().NotBeNull();
            actual[0].Quarter.Should().Be(expected.Quarter);
            actual[0].Progress.Should().Be(expected.Progress);
            actual[0].IssueId.Should().Be(expected.IssueId);
        }
    }
}