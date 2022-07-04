using Stefanini.ViaReport.Core.Services;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class TechnicalDebitIssuesCreatedAndResolvedInDateRangeServiceTests : BaseIssuesInDateRangesServiceTests<TechnicalDebitIssuesCreatedAndResolvedInDateRangeService>
    {
        protected override string GetJqlExpected()
            => "project = 'Search' AND issuetype IN (12200) AND created >= '2000-01-01' AND created <= '2000-12-31' AND resolved >= '2000-01-01' AND resolved <= '2000-12-31' AND status IN (Done)";

        [Fact(DisplayName = "[TechnicalDebitIssuesCreatedAndResolvedInDateRangeService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
        public async void DeveMontarJQLCorretamente()
            => await RunTest();
    }
}