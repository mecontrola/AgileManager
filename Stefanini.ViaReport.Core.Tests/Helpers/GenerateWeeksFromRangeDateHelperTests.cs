using FluentAssertions;
using Stefanini.ViaReport.Core.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Helpers
{
    public class GenerateWeeksFromRangeDateHelperTests
    {
        private readonly IGenerateWeeksFromRangeDateHelper helper;

        private static readonly DateTime RANGE_INI = new(2021, 12, 12);
        private static readonly DateTime RANGE_END = new(2022, 1, 12);

        public GenerateWeeksFromRangeDateHelperTests()
        {
            helper = new GenerateWeeksFromRangeDateHelper();
        }

        [Fact(DisplayName = "[GenerateWeeksFromRangeDateHelper.GetGroupBy] Deve retornar a lista de semanas existentes no intervalo informado agrupando as semanas em 1 semana.")]
        public void DeveGerarListaSemanasAgrupadoPadrao()
        {
            var expected = GetExpectWeekGroupOneWeek();
            var actual = helper.GenerateList(RANGE_INI, RANGE_END);
            actual.Should().HaveCount(expected.Count);
            actual.Should().Contain(expected);
        }

        [Fact(DisplayName = "[GenerateWeeksFromRangeDateHelper.GetGroupBy] Deve retornar a lista de semanas existentes no intervalo informado agrupando as semanas em 2 semanas.")]
        public void DeveGerarListaSemanasAgrupado2Semanas()
        {
            var expected = GetExpectWeekGroupTwoWeeks();
            var actual = helper.GenerateList(RANGE_INI, RANGE_END, 2);
            actual.Should().HaveCount(expected.Count);
            actual.Should().Contain(expected);
        }

        private static IDictionary<string, Tuple<DateTime, DateTime>> GetExpectWeekGroupOneWeek()
            => new Dictionary<string, Tuple<DateTime, DateTime>>
            {
                { "49|2021", Tuple.Create(new DateTime(2021, 12, 6), new DateTime(2021, 12, 12)) },
                { "50|2021", Tuple.Create(new DateTime(2021, 12, 13), new DateTime(2021, 12, 19)) },
                { "51|2021", Tuple.Create(new DateTime(2021, 12, 20), new DateTime(2021, 12, 26)) },
                { "52|2021", Tuple.Create(new DateTime(2021, 12, 27), new DateTime(2022, 1, 2)) },
                { "1|2022", Tuple.Create(new DateTime(2022, 1, 3), new DateTime(2022, 1, 9)) },
                { "2|2022", Tuple.Create(new DateTime(2022, 1, 10), new DateTime(2022, 1, 16)) }
            };

        private static IDictionary<string, Tuple<DateTime, DateTime>> GetExpectWeekGroupTwoWeeks()
            => new Dictionary<string, Tuple<DateTime, DateTime>>
            {
                { "25|2021", Tuple.Create(new DateTime(2021, 11, 29), new DateTime(2021, 12, 12)) },
                { "26|2021", Tuple.Create(new DateTime(2021, 12, 13), new DateTime(2021, 12, 26)) },
                { "1|2021", Tuple.Create(new DateTime(2021, 12, 27), new DateTime(2022, 1, 9)) },
                { "2|2022", Tuple.Create(new DateTime(2022, 1, 10), new DateTime(2022, 1, 23)) }
            };
    }
}