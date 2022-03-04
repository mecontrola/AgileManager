using FluentAssertions;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Tests.Mocks;
using System;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Helpers
{
    public class DateTimeFromStringHelperTests
    {
        private readonly IDateTimeFromStringHelper helper;

        public DateTimeFromStringHelperTests()
        {
            helper = new DateTimeFromStringHelper();
        }

        [Fact(DisplayName = "[DateTimeFromStringHelper.Convert] Deve retornar mínimo valor do DateTime quando passado uma string inválida.")]
        public void DeveRetornarDateTimeMinimal()
        {
            var expected = DateTime.MinValue;
            var actual = helper.Convert(string.Empty);
            actual.Should().Be(expected);
        }

        [Fact(DisplayName = "[DateTimeFromStringHelper.Convert] Deve retornar um DateTime da data informada quando passado uma string válida.")]
        public void DeveRetornarDateTimeInformada()
        {
            var expected = DataMock.DATETIME_QUARTER_2_2000;
            var actual = helper.Convert(DataMock.TEXT_DATETIME_WITH_WEEK);
            actual.Should().Be(expected);
        }
    }
}