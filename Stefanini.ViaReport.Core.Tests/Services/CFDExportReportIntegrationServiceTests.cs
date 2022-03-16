using NSubstitute;
using Stefanini.ViaReport.Core.Data.Dto.Jira.Inputs;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.TestUtils;
using System.Threading;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class CFDExportReportIntegrationServiceTests : BaseAsyncMethods
    {
        private const string PROJECT = "project";

        private readonly ICFDExportReportIntegrationService service;
        private readonly ISearchPost api;

        public CFDExportReportIntegrationServiceTests()
        {
            api = Substitute.For<ISearchPost>();

            service = new CFDExportReportIntegrationService(api);
        }

        private static string GetJqlExpected()
            => "project = 'project' AND status NOT IN (Removed,Cancelled) AND issuetype IN (3,4,7)";

        [Fact(DisplayName = "[IssuesEpicByLabelService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
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