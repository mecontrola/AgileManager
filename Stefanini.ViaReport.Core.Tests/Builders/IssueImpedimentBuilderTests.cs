using FluentAssertions;
using Stefanini.ViaReport.Core.Builders;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Builders
{
    public class IssueImpedimentBuilderTests
    {
        [Fact(DisplayName = "[IssueImpedimentBuilder.ToBuild] Deve criar a entidade com os dados informados.")]
        public void DeveCriarEntidadeComValoresDefinidos()
        {
            var expected = IssueImpedimentMock.Create();
            var actual = IssueImpedimentBuilder.GetInstance()
                                               .SetStart(DataMock.DATETIME_QUARTER_1_2000)
                                               .SetEnd(DataMock.DATETIME_QUARTER_2_2000)
                                               .SetIssueId(DataMock.ID_ISSUE)
                                               .ToBuild();

            actual.Start.Should().Be(expected.Start);
            actual.End.Should().Be(expected.End);
            actual.IssueId.Should().Be(expected.IssueId);
        }
    }
}