using FluentAssertions;
using Stefanini.ViaReport.Core.Builders;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Builders
{
    public class IssueEpicBuilderTests
    {
        [Fact(DisplayName = "[IssueEpicBuilder.ToBuild] Deve criar a entidade com os dados informados.")]
        public void DeveCriarEntidadeComValoresDefinidos()
        {
            var expected = IssueEpicMock.Create();
            var actual = IssueEpicBuilder.GetInstance()
                                         .SetProgress(DataMock.VALUE_DEFAULT_9)
                                         .SetQuarter(DataMock.TEXT_QUARTER_1_2000)
                                         .SetIssueId(DataMock.ID_ISSUE)
                                         .ToBuild();

            actual.Progress.Should().Be(expected.Progress);
            actual.Quarter.Should().Be(expected.Quarter);
            actual.IssueId.Should().Be(expected.IssueId);
        }
    }
}