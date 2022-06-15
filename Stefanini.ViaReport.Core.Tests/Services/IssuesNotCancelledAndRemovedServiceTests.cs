using NSubstitute;
using NSubstitute.Equivalency;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks.Data.Dtos.Jira.Inputs;
using System.Threading;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
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
            await service.GetData(DataMock.VALUE_USERNAME,
                                  DataMock.VALUE_PASSWORD,
                                  DataMock.TEXT_SEARCH_PROJECT,
                                  GetCancellationToken());

            var expected = SearchInputDtoMock.CreateWithJqlCustom(GetJqlExpected());

            await api.Received().Execute(Arg.Is<string>(x => x.Equals(DataMock.VALUE_USERNAME)),
                                         Arg.Is<string>(x => x.Equals(DataMock.VALUE_PASSWORD)),
                                         ArgEx.IsEquivalentTo(expected),
                                         Arg.Any<CancellationToken>());
        }
    }
}