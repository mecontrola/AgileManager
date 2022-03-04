using Stefanini.ViaReport.Core.Data.Configurations;
using Stefanini.ViaReport.Core.Tests.Mocks.Server.Settings;
using Stefanini.ViaReport.Core.Tests.TestUtils;
using System.Threading;

namespace Stefanini.ViaReport.Core.Tests.Integrations.Jira
{
    public abstract class BaseJiraApiTests : BaseTestApi
    {
        private readonly IssueGetMock issueGetMock = new();
        private readonly ProjectGetAllMock projectGetAllMock = new();
        private readonly SearchPostMock searchPostMock = new();
        private readonly SessionGetMock sessionGetMock = new();
        private readonly StatusGetAllMock statusGetAllMock = new();

        private readonly CancellationTokenSource cancellationTokenSource = new();

        public BaseJiraApiTests()
            : base()
        { }

        protected void ConfigureIssueGet()
            => issueGetMock.Create(server);

        protected void ConfigureProjectGetAll()
            => projectGetAllMock.Create(server);

        protected void ConfigureSearchPost()
            => searchPostMock.Create(server);

        protected void ConfigureSessionGet()
            => sessionGetMock.Create(server);

        protected void ConfigureStatusGetAll()
            => statusGetAllMock.Create(server);

        protected IJiraConfiguration GetConfiguration()
            => new JiraConfiguration
            {
                Path = server.Urls[0],
                EasyBIAccount = "51",
                Cache = 0
            };

        protected CancellationToken GetCancellationToken()
            => cancellationTokenSource.Token;
    }
}