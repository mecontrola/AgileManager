using FluentAssertions;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Repositories;
using Stefanini.ViaReport.DataStorage.Repositories;
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
    }
}