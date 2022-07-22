using FluentAssertions;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Business;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos;
using Stefanini.ViaReport.Core.Tests.Mocks.Services;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Business
{
    public class ProjectBusinessTests : BaseAsyncMethods
    {
        private readonly IProjectBusiness projectBusiness;

        public ProjectBusinessTests()
        {
            var projectService = ProjectServiceMock.Create();

            projectBusiness = new ProjectBusiness(projectService);
        }

        [Fact(DisplayName = "[ProjectBusiness.ListAllWithCategoryAsync] Deve executar a chamada do service e retornar a lista dos projetos com a informação de categoria.")]
        public async void DeveExecutarListAllWithCategoryAsyncRetornarLista()
        {
            var actual = await projectBusiness.ListAllWithCategoryAsync(GetCancellationToken());
            var expected = ProjectDtoMock.CreateList();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[ProjectBusiness.ListSelectedWithCategoryAsync] Deve executar a chamada do service e retornar a lista dos projetos selecionados com a informação de categoria.")]
        public async void DeveExecutarListSelectedWithCategoryAsyncRetornarLista()
        {
            var actual = await projectBusiness.ListSelectedWithCategoryAsync(GetCancellationToken());
            var expected = ProjectDtoMock.CreateListSelected();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[ProjectBusiness.ListSelectedIdsAsync] Deve executar a chamada do service e retornar a lista do Ids dos projetos selecionados.")]
        public async void DeveExecutarListSelectedIdsAsyncRetornarLista()
        {
            var actual = await projectBusiness.ListSelectedIdsAsync(GetCancellationToken());
            var expected = DataMock.PROJECTS;

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[ProjectBusiness.SetSelectedByIdAsync] Deve executar a chamado do service e retornar true quando atualizar a seleção dos ids informados.")]
        public async void DeveExecutarSetSelectedByIdAsyncRetornarTrueQuandoSalvarTudo()
        {
            var actual = await projectBusiness.SetSelectedByIdAsync(DataMock.PROJECTS, GetCancellationToken());

            actual.Should().BeTrue();
        }

        [Fact(DisplayName = "[ProjectBusiness.SetSelectedByIdAsync] Deve executar a chamado do service e retornar false quando ocorrer um erro ao atualizar a seleção dos ids informados.")]
        public async void DeveExecutarSetSelectedByIdAsyncRetornarFalseQuandoOcorrerErro()
        {
            var ids = new long[] { DataMock.INT_ID_1, DataMock.INT_ID_2 };
            var actual = await projectBusiness.SetSelectedByIdAsync(ids, GetCancellationToken());

            actual.Should().BeFalse();
        }
    }
}