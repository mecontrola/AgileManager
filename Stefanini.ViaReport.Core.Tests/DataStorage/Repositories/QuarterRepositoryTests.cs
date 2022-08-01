using FluentAssertions;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities;
using Stefanini.ViaReport.Core.Tests.Mocks.Repositories;
using Stefanini.ViaReport.DataStorage.Repositories;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.DataStorage.Repositories
{
    public class QuarterRepositoryTests : BaseAsyncMethods
    {
        private readonly IQuarterRepository repository;

        public QuarterRepositoryTests()
        {
            repository = QuarterRepositoryMock.Create();
        }

        [Fact(DisplayName = "[QuarterRepository.RetrieveByNameAsync] Deve retornar o quarter quando campo name informado foi de um quarter existente.")]
        public async void DeveRetornarQuarterQuandoCampoNameQuarterExistente()
        {
            var actual = await repository.RetrieveByNameAsync(DataMock.TEXT_QUARTER_1_2000, GetCancellationToken());

            actual.Should().NotBeNull();
        }

        [Fact(DisplayName = "[QuarterRepository.RetrieveByNameAsync] Deve retornar nulo quando campo name informado foi de um quarter inexistente.")]
        public async void DeveRetornarNuloQuandoCampoNameQuarterInexistente()
        {
            var actual = await repository.RetrieveByNameAsync(DataMock.TEXT_SEARCH_PROJECT, GetCancellationToken());

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[QuarterRepository.Get5LastListAsync] Deve retornar a lista dos 5 mais recentes quarters adicionados.")]
        public async void DeveRetornarLista5QuartersRecentes()
        {
            var expected = QuarterMock.CreateList();
            var actual = await repository.Get5LastListAsync(GetCancellationToken());

            actual.Should().HaveCount(5);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}