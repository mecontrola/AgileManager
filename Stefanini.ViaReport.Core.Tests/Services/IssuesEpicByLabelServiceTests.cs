using NSubstitute;
using Stefanini.ViaReport.Core.Data.Dto.Jira.Inputs;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.TestUtils;
using System.Threading;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class IssuesEpicByLabelServiceTests : BaseAsyncMethods
    {
        private const string PROJECT = "project";

        private readonly IIssuesEpicByLabelService service;
        private readonly ISearchPost api;

        public IssuesEpicByLabelServiceTests()
        {
            api = Substitute.For<ISearchPost>();

            service = new IssuesEpicByLabelService(api);
        }

        private static string GetJqlExpected()
            => "project = 'project' AND issuetype IN (6) AND status NOT IN (Removed,Cancelled) AND labels IN (LABEL1,LABEL2)";

        [Fact(DisplayName = "[IssuesEpicByLabelService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
        public void DeveMontarJQLCorretamente()
        {
            service.GetData(string.Empty, string.Empty, PROJECT, new[] { "LABEL1", "LABEL2" }, GetCancellationToken());

            api.Received().Execute(Arg.Any<string>(),
                                   Arg.Any<string>(),
                                   Arg.Is<SearchInputDto>(x => x.Jql.Equals(GetJqlExpected())),
                                   Arg.Any<CancellationToken>());
        }
    }
}