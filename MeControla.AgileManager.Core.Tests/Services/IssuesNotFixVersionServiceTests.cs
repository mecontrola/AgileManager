using MeControla.AgileManager.Core.Integrations.Jira.V2.Projects;
using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.TestingTools;
using MeControla.AgileManager.Updater.Core.Tests.Mocks.Data.Dtos.Jira.Inputs;
using NSubstitute;
using NSubstitute.Equivalency;
using System.Threading;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Services
{
    public class IssuesNotFixVersionServiceTests : BaseAsyncMethods
    {
        private readonly IIssuesNotFixVersionService service;
        private readonly ISearchPost api;

        public IssuesNotFixVersionServiceTests()
        {
            api = Substitute.For<ISearchPost>();

            service = new IssuesNotFixVersionService(api);
        }

        protected static string GetJqlExpected()
            => "project = 'Search' AND fixVersion IS NULL AND status NOT IN (Removed,Cancelled) AND statusCategory NOT IN ('To Do') AND issuetype NOT IN (6,5)";

        [Fact(DisplayName = "[IssuesNotFixVersionService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
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