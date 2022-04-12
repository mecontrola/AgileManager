using NSubstitute;
using Stefanini.ViaReport.Core.Data.Dto.Jira.Inputs;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.TestUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class IssuesNotCancelledAndRemovedServiceTests : BaseAsyncMethods
    {
        private const string PROJECT = "project";

        private readonly IIssuesNotCancelledAndRemovedService service;
        private readonly ISearchPost api;

        public IssuesNotCancelledAndRemovedServiceTests()
        {
            api = Substitute.For<ISearchPost>();

            service = new IssuesNotCancelledAndRemovedService(api);
        }

        private static string GetJqlExpected()
            => "project = 'project' AND issuetype NOT IN (5,6) AND status NOT IN (Removed,Cancelled)";

        [Fact(DisplayName = "[IssuesNotCancelledAndRemovedService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
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