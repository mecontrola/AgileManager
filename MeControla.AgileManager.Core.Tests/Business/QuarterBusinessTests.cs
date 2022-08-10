using FluentAssertions;
using MeControla.AgileManager.Core.Business;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos;
using MeControla.AgileManager.Core.Tests.Mocks.Services;
using MeControla.AgileManager.TestingTools;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Business
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