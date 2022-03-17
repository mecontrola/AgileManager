using NSubstitute;
using Stefanini.ViaReport.Core.Data.Dto.Jira.Inputs;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.TestUtils;
using System.Threading;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class IssuesNotFixVersionServiceTests : BaseAsyncMethods
    {
        private const string PROJECT = "project";

        private readonly IIssuesNotFixVersionService service;
        private readonly ISearchPost api;

        public IssuesNotFixVersionServiceTests()
        {
            api = Substitute.For<ISearchPost>();

            service = new IssuesNotFixVersionService(api);
        }

        protected static string GetJqlExpected()
            => "project = 'project' AND fixVersion IS NULL AND status NOT IN (Removed,Cancelled) AND statusCategory NOT IN ('To Do') AND issuetype NOT IN (6,5)";

        [Fact(DisplayName = "[IssuesNotFixVersionService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
        public void DeveMontarJQLCorretamente()
        {
            service.GetData(string.Empty, string.Empty, PROJECT, GetCancellationToken());

            api.Received().Execute(Arg.Any<string>(),
                                   Arg.Any<string>(),
                                   Arg.Is<SearchInputDto>(x => x.Jql.Equals(GetJqlExpected())),
                                   Arg.Any<CancellationToken>());
        }
    }
}