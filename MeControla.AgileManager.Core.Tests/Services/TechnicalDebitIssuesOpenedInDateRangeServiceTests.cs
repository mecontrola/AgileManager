using MeControla.AgileManager.Core.Services;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Services
{
    public class TechnicalDebitIssuesOpenedInDateRangeServiceTests : BaseIssuesInDateRangesServiceTests<TechnicalDebitIssuesOpenedInDateRangeService>
    {
        protected override string GetJqlExpected()
            => "project = 'Search' AND issuetype IN (12200) AND statusCategory NOT IN ('Done')";

        [Fact(DisplayName = "[TechnicalDebitIssuesOpenedInDateRangeService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
        public async void DeveMontarJQLCorretamente()
            => await RunTest();
    }
}