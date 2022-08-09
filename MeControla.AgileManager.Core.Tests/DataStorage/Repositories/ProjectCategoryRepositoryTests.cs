using FluentAssertions;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.Core.Tests.Mocks.Repositories;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.AgileManager.TestingTools;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.DataStorage.Repositories
{
    public class ProjectCategoryRepositoryTests : BaseAsyncMethods
    {
        private readonly IProjectCategoryRepository repository;

        public ProjectCategoryRepositoryTests()
        {
            repository = ProjectCategoryRepositoryMock.Create();
        }

        [Fact(DisplayName = "[ProjectCategoryRepository.FindByKeyAsync] Deve retornar project category quando campo Key válido.")]
        public async void DeveRetornarProjectCategoryQuandoCampoKeyValido()
        {
            var actual = await repository.FindByKeyAsync(DataMock.KEY_PROJECT_CATEGORY, GetCancellationToken());

            actual.Name.Should().BeEquivalentTo(DataMock.NAME_PROJECT_CATEGORY);
        }

        [Fact(DisplayName = "[ProjectCategoryRepository.FindByKeyAsync] Deve retornar null quando campo Key inválido.")]
        public async void DeveRetornarNullQuandoCampoKeyInvalido()
        {
            var actual = await repository.FindByKeyAsync(DataMock.KEY_NOT_FOUND, GetCancellationToken());

            actual.Should().BeNull();
        }
    }
}