using Stefanini.ViaReport.Core.Data.Configurations;
using Stefanini.ViaReport.Core.Data.Dto.Jira;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = Stefanini.ViaReport.Core.Integrations.Jira.Routes.AuthRoute.Session;

namespace Stefanini.ViaReport.Core.Integrations.Jira.V1.Auth
{
    public class SessionGet : BaseJiraIntegration, ISessionGet
    {
        public SessionGet(IJiraConfiguration jiraConfiguration)
            : base(jiraConfiguration, JsonNamingPolicy.CamelCase)
        { }

        public async Task<SessionDto> Execute(string username, string password, CancellationToken cancellationToken)
        {
            URL = route.GET;

            return await GetAsync<SessionDto>(username, password, cancellationToken);
        }
    }
}