using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class StatusInProgressServiceTests : BaseStatusServiceTests<StatusInProgressService>
    {
        [Fact(DisplayName = "[StatusInProgressService.GetList] Deve retornar um dictionary (id, name), contendo os status da categoria In Progress.")]
        public async void DeveRetornarStatusCategoriaInProgress()
            => await RunTest(StatusDtoMock.CreateDictionaryInProgress());
    }
}