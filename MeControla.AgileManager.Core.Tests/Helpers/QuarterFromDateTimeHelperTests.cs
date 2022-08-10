using FluentAssertions;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.Tests.Mocks;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Helpers
{
    public class QuarterFromDateTimeHelperTests
    {
        private readonly IQuarterFromDateTimeHelper helper;

        public QuarterFromDateTimeHelperTests()
        {
            helper = new QuarterFromDateTimeHelper();
        }

        [Fact(DisplayName = "[QuarterFromDateTimeHelper.GetQuarter] Deve retornar Q12000 quando informado o DateTime 2000-2-2.")]
        public void DeveRetornarQ12000()
        {
            var expected = DataMock.TEXT_QUARTER_1_2000;
            var actual = helper.GetQuarter(DataMock.DATETIME_QUARTER_1_2000);
            actual.Should().Be(expected);
        }

        [Fact(DisplayName = "[QuarterFromDateTimeHelper.GetQuarter] Deve retornar Q22000 quando informado o DateTime 2000-5-5.")]
        public void DeveRetornarQ22000()
        {
            var expected = DataMock.TEXT_QUARTER_2_2000;
            var actual = helper.GetQuarter(DataMock.DATETIME_QUARTER_2_2000);
            actual.Should().Be(expected);
        }

        [Fact(DisplayName = "[QuarterFromDateTimeHelper.GetQuarter] Deve retornar Q32000 quando informado o DateTime 2000-8-8.")]
        public void DeveRetornarQ32000()
        {
            var expected = DataMock.TEXT_QUARTER_3_2000;
            var actual = helper.GetQuarter(DataMock.DATETIME_QUARTER_3_2000);
            actual.Should().Be(expected);
        }

        [Fact(DisplayName = "[QuarterFromDateTimeHelper.GetQuarter] Deve retornar Q42000 quando informado o DateTime 2000-11-11.")]
        public void DeveRetornarQ42000()
        {
            var expected = DataMock.TEXT_QUARTER_4_2000;
            var actual = helper.GetQuarter(DataMock.DATETIME_QUARTER_4_2000);
            actual.Should().Be(expected);
        }
    }
}