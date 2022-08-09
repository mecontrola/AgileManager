using FluentAssertions;
using MeControla.Kernel.Extensions;
using MeControla.Kernel.Tests.Mocks;
using Xunit;

namespace MeControla.Kernel.Tests.Extensions
{
    public class DateTimeExtensionsTests
    {
        [Fact(DisplayName = "[DateTimeExtensions.GetWeekOfYear] Deve retornar o número da semana de um DateTime.")]
        public void DeveRetornarSemanaAnoDeDateTime()
            => DataMock.DATETIME_QUARTER_2_2000.GetWeekOfYear().Should().Be(DataMock.WEEK_YEAR);
    }
}