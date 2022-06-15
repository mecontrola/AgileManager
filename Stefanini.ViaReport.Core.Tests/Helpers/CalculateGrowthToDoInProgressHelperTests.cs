using FluentAssertions;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Helpers
{
    public class CalculateGrowthToDoInProgressHelperTests
    {
        private readonly ICalculateGrowthToDoInProgressHelper helper;

        public CalculateGrowthToDoInProgressHelperTests()
        {
            helper = new CalculateGrowthToDoInProgressHelper();
        }

        [Fact(DisplayName = "[CalculateGrowthToDoInProgressHelper.Execute] Deve realizar o cálculo da relação entre os itens em To Do com os de In Progress.")]
        public void DeveCalculaRelacaoToDoComInProgress()
        {
            var expected = GrowthCFDInfoDtoMock.CreateCheckCalculateGrowthToDoInProgress();
            var actual = helper.Execute(CFDInfoDtoMock.CreateCheckFile());

            actual.Should().BeEquivalentTo(expected);
        }
    }
}