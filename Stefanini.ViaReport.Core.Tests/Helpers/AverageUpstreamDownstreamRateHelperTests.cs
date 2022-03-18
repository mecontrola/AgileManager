using FluentAssertions;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Tests.Mocks.Dto;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Helpers
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