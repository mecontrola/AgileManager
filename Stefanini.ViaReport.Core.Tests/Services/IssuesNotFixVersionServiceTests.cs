﻿using NSubstitute;
using Stefanini.ViaReport.Core.Data.Dto.Jira.Inputs;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Core.Services;
using System.Threading;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class IssuesNotFixVersionServiceTests
    {
        private const string PROJECT = "project";

        private readonly IIssuesNotFixVersionService service;
        private readonly ISearchPost api;

        private readonly CancellationTokenSource cancellationTokenSource;

        public IssuesNotFixVersionServiceTests()
        {
            api = Substitute.For<ISearchPost>();

            service = new IssuesNotFixVersionService(api);
            cancellationTokenSource = new CancellationTokenSource();
        }

        protected static string GetJqlExpected()
            => "project = 'project' AND fixVersion IS NULL AND status NOT IN (Removed,Cancelled) AND statusCategory NOT IN ('To Do') AND issuetype NOT IN (6,5)";

        [Fact(DisplayName = "[IssuesNotFixVersionService.GetData] Deve montar o JQL de acordo com o parametros criados.")]
        public void DeveMontarJQLCorretamente()
        {
            service.GetData(string.Empty, string.Empty, PROJECT, cancellationTokenSource.Token);

            api.Received().Execute(Arg.Any<string>(),
                                   Arg.Any<string>(),
                                   Arg.Is<SearchInputDto>(x => x.Jql.Equals(GetJqlExpected())),
                                   Arg.Any<CancellationToken>());
        }
    }
}