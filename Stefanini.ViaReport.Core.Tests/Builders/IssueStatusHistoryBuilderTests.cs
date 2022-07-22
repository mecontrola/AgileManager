using FluentAssertions;
using Stefanini.ViaReport.Core.Builders;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Builders
{
    public class IssueStatusHistoryBuilderTests
    {
        [Fact(DisplayName = "[IssueStatusHistoryBuilder.ToBuild] Deve criar a entidade com os dados informados.")]
        public void DeveCriarEntidadeComValoresDefinidos()
        {
            var expected = IssueStatusHistoryMock.Create();
            var actual = IssueStatusHistoryBuilder.GetInstance()
                                                  .SetDateTime(DataMock.DATETIME_FIRST_DAY_YEAR)
                                                  .SetIssueId(DataMock.ID_ISSUE)
                                                  .SetStatusId(DataMock.INT_STATUS_EM_DESENVOLVIMENTO)
                                                  .ToBuild();

            actual.DateTime.Should().Be(expected.DateTime);
            actual.IssueId.Should().Be(expected.IssueId);
            actual.StatusId.Should().Be(expected.StatusId);
        }
    }
}