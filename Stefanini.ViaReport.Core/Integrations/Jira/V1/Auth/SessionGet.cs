using Stefanini.ViaReport.Core.Data.Configurations;
using Stefanini.ViaReport.Core.Data.Dto.Jira;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Integrations.Jira.V1.Auth
{
    public class SessionGet : BaseJiraIntegration, ISessionGet
    {
        private const string API_URL = "/rest/auth/1/session";

        public SessionGet(IJiraConfiguration jiraConfiguration)
            : base(jiraConfiguration, JsonNamingPolicy.CamelCase)
        { }

        public async Task<SessionDto> Execute(string username, string password, CancellationToken cancellationToken)
        {
            URL = API_URL;

            return await GetAsync<SessionDto>(username, password, cancellationToken);
        }
    }
}