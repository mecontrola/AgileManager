using FluentAssertions;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Repositories;
using Stefanini.ViaReport.DataStorage.Repositories;
using System.Linq;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.DataStorage.Repositories
{
    public class ProjectRepositoryTests : BaseAsyncMethods
    {
        private readonly IProjectRepository repository;

        public ProjectRepositoryTests()
        {
            repository = ProjectRepositoryMock.Create();
        }

        [Fact(DisplayName = "[ProjectRepository.ExistsByKeyAsync] Deve retornar true quando campo Key informado foi de um project válido.")]
        public async void DeveRetornarTrueQuandoCampoKeyDeProjectValido()
        {
            var actual = await repository.ExistsByKeyAsync(DataMock.KEY_PROJECT, GetCancellationToken());

            actual.Should().BeTrue();
        }

        [Fact(DisplayName = "[ProjectRepository.ExistsByKeyAsync] Deve retornar false quando campo Key informado foi de um project inválido.")]
        public async void DeveRetornarFalseQuandoCampoKeyDeProjectInvalido()
        {
            var actual = await repository.ExistsByKeyAsync(DataMock.KEY_NOT_FOUND, GetCancellationToken());

            actual.Should().BeFalse();
        }

        [Fact(DisplayName = "[ProjectRepository.FindAllInIdListAsync] Deve retornar uma lista contendo o projetos que contem os correspondentes Ids informados.")]
        public async void DeveRetornarListaProjetosDosIdsInformados()
        {
            var actual = await repository.FindAllInIdListAsync(new long[] { DataMock.INT_ID_1 }, GetCancellationToken());

            actual.Count().Should().Be(1);
            actual[0].Id.Should().Be(DataMock.INT_ID_1);
            actual[0].Name.Should().Be(DataMock.TEXT_SEARCH_PROJECT);
        }

        [Fact(DisplayName = "[ProjectRepository.FindAllWithCategoryAsync] Deve retornar uma lista contendo o projetos que contem os correspondentes Ids informados.")]
        public async void DeveRetornarListaTodosProjetosComCategoria()
        {
            var actual = await repository.FindAllWithCategoryAsync(GetCancellationToken());

            actual.Count().Should().Be(4);
            actual[0].ProjectCategory.Should().NotBeNull();
            actual[1].ProjectCategory.Should().NotBeNull();
            actual[2].ProjectCategory.Should().NotBeNull();
            actual[3].ProjectCategory.Should().NotBeNull();
        }

        [Fact(DisplayName = "[ProjectRepository.FindSelectedWithCategoryAsync] Deve retornar uma lista contendo os projetos selecionados com as que contem os correspondentes Ids informados.")]
        public async void DeveRetornarListaProjetosSelecionadosComCategoria()
        {
            var actual = await repository.FindSelectedWithCategoryAsync(GetCancellationToken());

            actual.Count().Should().Be(2);
            actual[0].Id.Should().Be(DataMock.INT_ID_1);
            actual[0].Name.Should().Be(DataMock.TEXT_SEARCH_PROJECT);
            actual[1].Id.Should().Be(DataMock.INT_ID_2);
            actual[1].Name.Should().Be(DataMock.TEXT_LOYALTY_PROJECT);
        }
    }
}