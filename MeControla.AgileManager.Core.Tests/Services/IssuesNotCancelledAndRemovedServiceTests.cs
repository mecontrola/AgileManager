using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
using MeControla.AgileManager.TestingTools;
using MeControla.AgileManager.Updater.Core.Tests.Mocks.Data.Dtos.Jira.Inputs;
using NSubstitute;
using NSubstitute.Equivalency;
using System.Threading;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Services
{
    public class IssuesNotCancelledAndRemovedServiceTests : BaseAsyncMethods
    {
        private readonly IIssuesNotCancelledAndRemovedService service;
        private readonly ISearchPost api;

        public IssuesNotCancelledAndRemovedServiceTests()
        {
            api = Substitute.For<ISearchPost>();

            service = new IssuesNotCancelledAndRemovedService(api);
        }

        private static string GetJqlExpected()
            => "project = 'Search' AND issuetype NOT IN (5,6) AND status NOT IN (Removed,Cancelled)";

        [Fact(DisplayName = "[IssuesNotCancelledAndRemovedService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
        public async void DeveMontarJQLCorretamente()
        {
            await service.GetData(DataMock.TEXT_SEARCH_PROJECT,
                                  GetCancellationToken());

            var expected = SearchInputDtoMock.CreateWithJqlCustom(GetJqlExpected());

            await api.Received().Execute(ArgEx.IsEquivalentTo(expected),
                                         Arg.Any<CancellationToken>());
        }
    }
}