using FluentAssertions;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Business;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos;
using Stefanini.ViaReport.Core.Tests.Mocks.Services;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Business
{
    public class QuarterBusinessTests : BaseAsyncMethods
    {
        private readonly IQuarterBusiness quarterBusiness;

        public QuarterBusinessTests()
        {
            var quarterService = QuarterServiceMock.Create();

            quarterBusiness = new QuarterBusiness(quarterService);
        }

        [Fact(DisplayName = "[QuarterBusiness.ListAllAsync] Deve executar a chamada do service e retornar a lista dos quarters.")]
        public async void DeveExecutarListAllWithCategoryAsyncRetornarLista()
        {
            var actual = await quarterBusiness.ListAllAsync(GetCancellationToken());
            var expected = QuarterDtoMock.CreateList();

            actual.Should().BeEquivalentTo(expected);
        }
    }
}