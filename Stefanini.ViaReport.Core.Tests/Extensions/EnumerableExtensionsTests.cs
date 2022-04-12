using FluentAssertions;
using Stefanini.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Extensions
{
    public class EnumerableExtensionsTests
    {
        private readonly TimeSpan EXPECTED_AVERAGE = new(11, 40, 0);
        private readonly TimeSpan EXPECTED_SUM = new(35, 0, 0);

        private readonly IList<TimeSpan> ACTUAL_LIST = new List<TimeSpan>
        {
             TimeSpan.FromHours(10), TimeSpan.FromHours(12), TimeSpan.FromHours(13)
        };

        [Fact(DisplayName = "[Enumerable.Sum] Deve retornar a soma dos itens contidos em um lista de TimeSpan.")]
        public void DeveSomarValoresTimeSpan()
            => ACTUAL_LIST.Sum(x => x)
                          .Should()
                          .Be(EXPECTED_SUM);

        [Fact(DisplayName = "[Enumerable.Average] Deve retornar a média dos itens contidos em um lista de TimeSpan.")]
        public void DeveMediaValoresTimeSpan()
            => ACTUAL_LIST.Average(x => x)
                          .Should()
                          .Be(EXPECTED_AVERAGE);
    }
}