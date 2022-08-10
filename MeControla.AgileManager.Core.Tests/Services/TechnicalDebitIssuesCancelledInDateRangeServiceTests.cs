using MeControla.AgileManager.Core.Services;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Services
{
    public class TechnicalDebitIssuesCancelledInDateRangeServiceTests : BaseIssuesInDateRangesServiceTests<TechnicalDebitIssuesCancelledInDateRangeService>
    {
        protected override string GetJqlExpected()
            => "project = 'Search' AND issuetype IN (12200) AND resolved >= '2000-01-01' AND resolved <= '2000-12-31' AND status IN (Removed,Cancelled)";

        [Fact(DisplayName = "[TechnicalDebitIssuesCancelledInDateRangeService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
        public async void DeveMontarJQLCorretamente()
            => await RunTest();
    }
}