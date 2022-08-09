using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.Core.Tests.Mocks.Server.Settings;
using MeControla.AgileManager.Data.Configurations;
using MeControla.AgileManager.TestingTools;
using NSubstitute;

namespace MeControla.AgileManager.Core.Tests.Integrations.Jira
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

        protected ISettingsService GetSettings()
        {
            var service = Substitute.For<ISettingsService>();
            service.GetJiraConfiguration()
                   .Returns(GetConfiguration());
            return service;
        }

        private IJiraConfiguration GetConfiguration()
            => new JiraConfiguration
            {
                Url = server.Urls[0],
                Username = DataMock.VALUE_USERNAME,
                Password = DataMock.VALUE_PASSWORD,
                Cache = 5
            };
    }
}