using Stefanini.ViaReport.Core.Services;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class TechnicalDebitIssuesResolvedInDateRangeServiceTests : BaseIssuesInDateRangesServiceTests<TechnicalDebitIssuesResolvedInDateRangeService>
    {
        protected override string GetJqlExpected()
            => "project = 'project' AND issuetype IN (12200) AND resolved >= '2000-01-01' AND resolved <= '2000-12-31' AND status IN (Done)";

        [Fact(DisplayName = "[TechnicalDebitIssuesResolvedInDateRangeService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
        public void DeveMontarJQLCorretamente()
            => RunTest();
    }
}