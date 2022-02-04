using Stefanini.ViaReport.Core.Services;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class TechnicalDebitIssuesOpenedInDateRangeServiceTests : BaseIssuesInDateRangesServiceTests<TechnicalDebitIssuesOpenedInDateRangeService>
    {
        protected override string GetJqlExpected()
            => "project = 'project' AND issuetype IN (12200) AND statusCategory NOT IN ('Done')";

        [Fact(DisplayName = "[TechnicalDebitIssuesOpenedInDateRangeService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
        public void DeveMontarJQLCorretamente()
            => RunTest();
    }
}