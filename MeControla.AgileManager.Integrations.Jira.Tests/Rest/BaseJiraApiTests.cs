using MeControla.AgileManager.Integrations.Jira.Data.Configurations;
using MeControla.AgileManager.Integrations.Jira.Tests.Mocks;
using MeControla.AgileManager.Integrations.Jira.Tests.Mocks.Server.Settings;
using MeControla.AgileManager.TestingTools;
using Microsoft.Extensions.Options;
using NSubstitute;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Rest
{
    public abstract class BaseJiraApiTests : BaseTestApi
    {
        private readonly ContextGetAllMock contextGetAllMock = new();
        private readonly FieldGetAllMock fieldGetAllMock = new();
        private readonly IssueGetMock issueGetMock = new();
        private readonly IssueTypeGetMock issueTypeGetMock = new();
        private readonly OptionGetAllMock optionGetAllMock = new();
        private readonly ProjectGetAllMock projectGetAllMock = new();
        private readonly SearchPostMock searchPostMock = new();
        private readonly SessionGetMock sessionGetMock = new();
        private readonly StatusGetAllMock statusGetAllMock = new();
        private readonly StatusCategoryGetAllMock statusCategoryGetAllMock = new();
        private readonly ExceptionApiMock exceptionApiMock = new();

        public BaseJiraApiTests()
            : base()
        { }

        protected void ConfigureContextGetAll()
            => contextGetAllMock.Create(server);

        protected void ConfigureFieldGetAll()
            => fieldGetAllMock.Create(server);

        protected void ConfigureIssueGet()
            => issueGetMock.Create(server);

        protected void ConfigureIssueTypeGetAll()
            => issueTypeGetMock.Create(server);

        protected void ConfigureOptionGetAll()
            => optionGetAllMock.Create(server);

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

        public IOptionsMonitor<JiraConfiguration> GetConfiguration()
        {
            var config = new JiraConfiguration
            {
                Url = server.Urls[0],
                Username = DataMock.VALUE_USERNAME,
                Password = DataMock.VALUE_PASSWORD,
                Cache = DataMock.INT_CACHE_MINUTES
            };

            var optionsMonitor = Substitute.For<IOptionsMonitor<JiraConfiguration>>();
            optionsMonitor.CurrentValue.Returns(config);

            return optionsMonitor;
        }
    }
}