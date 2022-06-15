using Stefanini.ViaReport.Core.Services;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class BugIssuesOpenedInDateRangeServiceTests : BaseIssuesInDateRangesServiceTests<BugIssuesOpenedInDateRangeService>
    {
        protected override string GetJqlExpected()
            => "project = 'Search' AND issuetype IN (1) AND statusCategory NOT IN ('Done')";

        [Fact(DisplayName = "[BugIssuesOpenedInDateRangeService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
        public async void DeveMontarJQLCorretamente()
            => await RunTest();
    }
}