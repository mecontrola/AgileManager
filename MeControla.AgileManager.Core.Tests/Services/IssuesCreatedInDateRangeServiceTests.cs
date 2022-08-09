using MeControla.AgileManager.Core.Services;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Services
{
    public class IssuesCreatedInDateRangeServiceTests : BaseIssuesInDateRangesServiceTests<IssuesCreatedInDateRangeService>
    {
        protected override string GetJqlExpected()
            => "project = 'Search' AND status NOT IN (Removed,Cancelled) AND created >= '2000-01-01' AND created <= '2000-12-31' AND issuetype IN (1,3,6,7,12200)";

        [Fact(DisplayName = "[IssuesCreatedInDateRangeService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
        public async void DeveMontarJQLCorretamente()
            => await RunTest();
    }
}