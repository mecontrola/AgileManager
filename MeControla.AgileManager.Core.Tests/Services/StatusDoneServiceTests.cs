using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Services
{
    public class StatusDoneServiceTests : BaseStatusServiceTests<StatusDoneService>
    {
        [Fact(DisplayName = "[StatusDoneService.GetList] Deve retornar um dictionary (id, name), contendo os status da categoria Done.")]
        public async void DeveRetornarStatusCategoriaInProgress()
            => await RunTest(StatusDtoMock.CreateDictionaryDone());
    }
}