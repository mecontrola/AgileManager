using Stefanini.ViaReport.Core.Integrations.Jira;
using Stefanini.ViaReport.Data.Configurations;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Integrations.Jira
{
    public class JiraIntegrationMock : BaseJiraIntegration
    {
        public JiraIntegrationMock(IJiraConfiguration jiraConfiguration)
            : base(jiraConfiguration, JsonNamingPolicy.CamelCase)
        { }

        public async Task<string> Execute(string username, string password, HttpStatusCode httpStatusCode, CancellationToken cancellationToken)
        {
            URL = $"{GetRouteBase()}?status={(int)httpStatusCode}";

            return await GetAsync<string>(username, password, cancellationToken);
        }

        private static string GetRouteBase()
            => DataMock.ISSUE_SELF_1.Replace(DataMock.JIRA_HOST, string.Empty);
    }
}