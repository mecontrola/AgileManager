using FluentAssertions;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Helpers
{
    public class AverageUpstreamDownstreamRateHelperTests
    {
        private const decimal EXPECTED_VALUE = -0.2758721670486376368729309906M;

        private readonly IAverageUpstreamDownstreamRateHelper helper;

        public AverageUpstreamDownstreamRateHelperTests()
        {
            helper = new AverageUpstreamDownstreamRateHelper();
        }

        [Fact(DisplayName = "[AverageUpstreamDownstreamRateHelper.Calculate] Deve retornar o valor da média quando informado lista.")]
        public void DeveRetornarMediaQuandoInformadoLista()
            => helper.Calculate(AHMInfoDtoMock.Create())
                     .Should()
                     .Be(EXPECTED_VALUE);
    }
}