using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Server.Settings;
using Stefanini.ViaReport.Data.Configurations;

namespace Stefanini.ViaReport.Core.Tests.Integrations.Jira
{
    public abstract class BaseJiraApiTests : BaseTestApi
    {
        private readonly IssueGetMock issueGetMock = new();
        private readonly IssueTypeGetMock issueTypeGetMock = new();
        private readonly ProjectGetAllMock projectGetAllMock = new();
        private readonly SearchPostMock searchPostMock = new();
        private readonly SessionGetMock sessionGetMock = new();
        private readonly StatusGetAllMock statusGetAllMock = new();
        private readonly StatusCategoryGetAllMock statusCategoryGetAllMock = new();
        private readonly ExceptionApiMock exceptionApiMock = new();

        public BaseJiraApiTests()
            : base()
        { }

        protected void ConfigureIssueGet()
            => issueGetMock.Create(server);

        protected void ConfigureIssueTypeGetAll()
            => issueTypeGetMock.Create(server);

        protected void ConfigureProjectGetAll()
            => projectGetAllMock.Create(server);

        protected void ConfigureSearchPost()
            => searchPostMock.Create(server);

        protected void ConfigureSessionGet()
            => sessionGetMock.Create(server);

        protected void ConfigureStatusGetAll()
            => statusGetAllMock.Create(server);

        protected void ConfigureStatusCategoryGetAll()
            => statusCategoryGetAllMock.Create(server);

        protected void ConfigureExceptionApi()
            => exceptionApiMock.Create(server);

        protected IJiraConfiguration GetConfiguration()
            => new JiraConfiguration
            {
                Path = server.Urls[0],
                EasyBIAccount = DataMock.TEXT_EASYBI_ACCOUNT,
                Cache = 5
            };
    }
}