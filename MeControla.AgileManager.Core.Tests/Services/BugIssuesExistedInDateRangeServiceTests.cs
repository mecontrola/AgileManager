using MeControla.AgileManager.Core.Services;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Services
{
    public class BugIssuesExistedInDateRangeServiceTests : BaseIssuesInDateRangesServiceTests<BugIssuesExistedInDateRangeService>
    {
        protected override string GetJqlExpected()
            => "project = 'Search' AND issuetype IN (1) AND created < '2000-01-01' AND status NOT IN (Removed,Cancelled) AND ((resolved IS NULL AND status NOT IN (Removed,Cancelled)) OR (resolved >= '2000-01-01' AND resolved <= '2000-12-31'))";

        [Fact(DisplayName = "[BugIssuesExistedInDateRangeService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
        public async void DeveMontarJQLCorretamente()
            => await RunTest();
    }
}