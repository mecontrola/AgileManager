using FluentAssertions;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos;
using Stefanini.ViaReport.Core.Tests.Mocks.Helpers;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class QuarterServiceTests : BaseAsyncMethods
    {
        private readonly IQuarterService quarterService;

        public QuarterServiceTests()
        {
            var quarterGenerateListHelper = QuarterGenerateListHelperMock.Create();

            quarterService = new QuarterService(quarterGenerateListHelper);
        }

        [Fact(DisplayName = "[QuarterService.LoadAllAsync] Deve retornar a lista dos quarters habilitados a partir do dia de hoje.")]
        public async void DeveRetornarListaQuarters()
        {
            var actual = await quarterService.LoadAllAsync(GetCancellationToken());
            var expected = QuarterDtoMock.CreateList();

            actual.Should().BeEquivalentTo(expected);
        }
    }
}