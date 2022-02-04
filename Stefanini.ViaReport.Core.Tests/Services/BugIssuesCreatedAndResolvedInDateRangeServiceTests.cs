using Stefanini.ViaReport.Core.Services;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class BugIssuesCreatedAndResolvedInDateRangeServiceTests : BaseIssuesInDateRangesServiceTests<BugIssuesCreatedAndResolvedInDateRangeService>
    {
        protected override string GetJqlExpected()
            => "project = 'project' AND issuetype IN (1) AND created >= '2000-01-01' AND created <= '2000-12-31' AND resolved >= '2000-01-01' AND resolved <= '2000-12-31' AND status IN (Done) AND status NOT IN (Removed,Cancelled)";

        [Fact(DisplayName = "[BugIssuesCreatedAndResolvedInDateRangeService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
        public void DeveMontarJQLCorretamente()
            => RunTest();
    }
}