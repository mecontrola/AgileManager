using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Services
{
    public class StatusInProgressServiceTests : BaseStatusServiceTests<StatusInProgressService>
    {
        [Fact(DisplayName = "[StatusInProgressService.GetList] Deve retornar um dictionary (id, name), contendo os status da categoria In Progress.")]
        public async void DeveRetornarStatusCategoriaInProgress()
            => await RunTest(StatusDtoMock.CreateDictionaryInProgress());
    }
}