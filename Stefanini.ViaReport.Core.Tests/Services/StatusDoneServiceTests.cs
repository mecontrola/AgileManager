using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Mocks.Dto;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class StatusDoneServiceTests : BaseStatusServiceTests<StatusDoneService>
    {
        [Fact(DisplayName = "[StatusDoneService.GetList] Deve retornar um dictionary (id, name), contendo os status da categoria Done.")]
        public async void DeveRetornarStatusCategoriaInProgress()
            => await RunTest(StatusDtoMock.CreateDictionaryDone());
    }
}