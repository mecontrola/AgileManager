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
    public class IssuesEpicByLabelServiceTests : BaseAsyncMethods
    {
        private static readonly string[] LABELS_EPICS = new[] { "LABEL1", "LABEL2" };

        private readonly IIssuesEpicByLabelService service;
        private readonly ISearchPost api;

        public IssuesEpicByLabelServiceTests()
        {
            api = Substitute.For<ISearchPost>();

            service = new IssuesEpicByLabelService(api);
        }

        private static string GetJqlExpected()
            => "project = 'Search' AND issuetype IN (6) AND status NOT IN (Removed,Cancelled) AND labels IN ('LABEL1','LABEL2')";

        [Fact(DisplayName = "[IssuesEpicByLabelService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
        public async void DeveMontarJQLCorretamente()
        {
            await service.GetData(DataMock.TEXT_SEARCH_PROJECT,
                                  LABELS_EPICS,
                                  GetCancellationToken());

            var expected = SearchInputDtoMock.CreateWithJqlCustom(GetJqlExpected());

            await api.Received().Execute(ArgEx.IsEquivalentTo(expected),
                                         Arg.Any<CancellationToken>());
        }
    }
}