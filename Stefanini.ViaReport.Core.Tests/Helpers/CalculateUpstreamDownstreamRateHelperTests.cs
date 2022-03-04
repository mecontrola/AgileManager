using FluentAssertions;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Tests.Mocks.Dto;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Helpers
{
    public class CalculateUpstreamDownstreamRateHelperTests
    {
        private readonly ICalculateUpstreamDownstreamRateHelper helper;

        public CalculateUpstreamDownstreamRateHelperTests()
        {
            var weekOfTheYearFormatHelper = new WeekOfTheYearFormatHelper();

            helper = new CalculateUpstreamDownstreamRateHelper(weekOfTheYearFormatHelper);
        }

        [Fact(DisplayName = "[CalculateUpstreamDownstreamRateHelper.Execute] Deve realizar o cálculo para informar a saúde do backlog.")]
        public void DeveRealizarCalculoSaudeBacklog()
        {
            var expected = AHMInfoDtoMock.Create();
            var actual = helper.Execute(GrowthCFDInfoDtoMock.Create());

            actual.Should().BeEquivalentTo(expected);
        }
    }
}