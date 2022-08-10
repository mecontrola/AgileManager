using FluentAssertions;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.Tests.Mocks;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Helpers
{
    public class QuarterGenerateListHelperTests
    {
        private const int LENGTH_DEFAULT = 6;
        private const int LENGTH_PARTIAL = 3;

        private static readonly IList<string> EXPECTED = new List<string> { "Q22000", "Q12000", "Q41999", "Q31999", "Q21999", "Q11999" };

        private readonly IQuarterGenerateListHelper helper;

        public QuarterGenerateListHelperTests()
        {
            helper = new QuarterGenerateListHelper(new QuarterFromDateTimeHelper());
        }

        [Fact(DisplayName = "[QuarterGenerateListHelper.Create] Deve gerar lista padrão de quarters, contendo 6 itens, a partir de uma base data informada.")]
        public void DeveGerarListaDefaultQuartersDataBase()
        {
            var expected = EXPECTED;
            var actual = helper.Create(DataMock.DATETIME_QUARTER_2_2000);

            actual.Count.Should().Be(LENGTH_DEFAULT);
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[QuarterGenerateListHelper.Create] Deve gerar lista de quarters, contendo 3 itens, a partir de uma base data informada.")]
        public void DeveGerarListaQuartersDataBase()
        {
            var expected = EXPECTED.Take(LENGTH_PARTIAL);
            var actual = helper.Create(DataMock.DATETIME_QUARTER_2_2000, LENGTH_PARTIAL);

            actual.Count.Should().Be(LENGTH_PARTIAL);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}