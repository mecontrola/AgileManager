using FluentAssertions;
using MeControla.AgileManager.Core.Builders;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Entities;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Builders
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
                                                  .SetFromStatusId(DataMock.INT_STATUS_PARA_DESENVOLVIMENTO)
                                                  .SetToStatusId(DataMock.INT_STATUS_EM_DESENVOLVIMENTO)
                                                  .ToBuild();

            actual.DateTime.Should().Be(expected.DateTime);
            actual.IssueId.Should().Be(expected.IssueId);
            actual.FromStatusId.Should().Be(expected.FromStatusId);
            actual.ToStatusId.Should().Be(expected.ToStatusId);
        }
    }
}