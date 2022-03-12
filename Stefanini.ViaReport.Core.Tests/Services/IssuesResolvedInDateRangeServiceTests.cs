using Stefanini.ViaReport.Core.Services;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class IssuesResolvedInDateRangeServiceTests : BaseIssuesInDateRangesServiceTests<IssuesResolvedInDateRangeService>
    {
        protected override string GetJqlExpected()
            => "project = 'project' AND status NOT IN (Removed,Cancelled) AND resolved >= '2000-01-01' AND resolved <= '2000-12-31' AND issuetype IN (1,3,4,7,12200) ORDER BY key";

        [Fact(DisplayName = "[IssuesResolvedInDateRangeService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
        public void DeveMontarJQLCorretamente()
            => RunTest();
    }
}