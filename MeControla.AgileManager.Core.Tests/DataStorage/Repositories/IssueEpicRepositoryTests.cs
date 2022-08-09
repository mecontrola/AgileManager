using FluentAssertions;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Entities;
using MeControla.AgileManager.Core.Tests.Mocks.Repositories;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.AgileManager.TestingTools;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.DataStorage.Repositories
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
            var actual = await repository.RetrieveByQuarterAsync(expected.Issue.ProjectId, expected.QuarterId.Value, GetCancellationToken());

            actual.Should().HaveCount(1);
            actual[0].Should().NotBeNull();
            actual[0].Quarter.Should().Be(expected.Quarter);
            actual[0].Progress.Should().Be(expected.Progress);
            actual[0].IssueId.Should().Be(expected.IssueId);
        }
    }
}