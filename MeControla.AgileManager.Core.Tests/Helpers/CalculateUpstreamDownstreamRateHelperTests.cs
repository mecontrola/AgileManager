using FluentAssertions;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Helpers
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