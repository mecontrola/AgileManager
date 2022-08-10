using MeControla.AgileManager.Core.Services;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Services
{
    public class BugIssuesCreatedInDateRangeServiceTests : BaseIssuesInDateRangesServiceTests<BugIssuesCreatedInDateRangeService>
    {
        protected override string GetJqlExpected()
            => "project = 'Search' AND issuetype IN (1) AND created >= '2000-01-01' AND created <= '2000-12-31'";

        [Fact(DisplayName = "[BugIssuesCreatedInDateRangeService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
        public async void DeveMontarJQLCorretamente()
            => await RunTest();
    }
}