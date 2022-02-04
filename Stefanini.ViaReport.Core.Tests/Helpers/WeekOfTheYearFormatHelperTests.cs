using FluentAssertions;
using Stefanini.ViaReport.Core.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Helpers
{
    public class WeekOfTheYearFormatHelperTests
    {
        private readonly IWeekOfTheYearFormatHelper helper;

        public WeekOfTheYearFormatHelperTests()
        {
            helper = new WeekOfTheYearFormatHelper();
        }

        [Theory(DisplayName = "[WeekOfTheYearFormatHelper.Format] Deve formatar a data para exibir a semana do ano.")]
        [MemberData(nameof(GetEnumeratorCases))]
        public void DeveFormatDataComNumeroSemanaAno(DateTime dateTime, string expected)
        {
            var actual = helper.Format(dateTime);
            actual.Should().BeEquivalentTo(expected);
        }

        public static IEnumerable<object[]> GetEnumeratorCases()
        {
            yield return new object[] { new DateTime(2021, 12, 20), "W51, 2021-12-20" };
            yield return new object[] { new DateTime(2022, 1, 3), "W1, 2022-01-03" };
        }
    }
}