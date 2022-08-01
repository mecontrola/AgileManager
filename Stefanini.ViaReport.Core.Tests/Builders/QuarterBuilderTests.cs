using FluentAssertions;
using Stefanini.ViaReport.Core.Builders;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Builders
{
    public class QuarterBuilderTests
    {
        [Fact(DisplayName = "[QuarterBuilder.ToBuild] Deve criar a entidade com os dados informados.")]
        public void DeveCriarEntidadeComValoresDefinidos()
        {
            var expected = QuarterMock.CreateQ12000();
            var actual = QuarterBuilder.GetInstance()
                                       .SetName(DataMock.TEXT_QUARTER_1_2000)
                                       .ToBuild();

            actual.Name.Should().Be(expected.Name);
        }
    }
}