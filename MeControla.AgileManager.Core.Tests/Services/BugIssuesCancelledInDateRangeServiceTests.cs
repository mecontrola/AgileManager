using MeControla.AgileManager.Core.Services;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Services
{
    public class BugIssuesCancelledInDateRangeServiceTests : BaseIssuesInDateRangesServiceTests<BugIssuesCancelledInDateRangeService>
    {
        protected override string GetJqlExpected()
            => "project = 'Search' AND issuetype IN (1) AND resolved >= '2000-01-01' AND resolved <= '2000-12-31' AND status IN (Removed,Cancelled)";

        [Fact(DisplayName = "[BugIssuesCancelledInDateRangeService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
        public async void DeveMontarJQLCorretamente()
            => await RunTest();
    }
}