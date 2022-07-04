using Stefanini.ViaReport.Data.Configurations;
using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = Stefanini.ViaReport.Core.Integrations.Jira.Routes.ApiRoute.Status;

namespace Stefanini.ViaReport.Core.Integrations.Jira.V2.Statuses
{
    public class StatusGetAll : BaseJiraIntegration, IStatusGetAll
    {
        public StatusGetAll(IJiraConfiguration jiraConfiguration)
            : base(jiraConfiguration, JsonNamingPolicy.CamelCase)
        {
            IsCached = true;
        }

        public async Task<StatusDto[]> Execute(string username, string password, CancellationToken cancellationToken)
        {
            URL = route.GET_ALL;

            return await GetAsync<StatusDto[]>(username, password, cancellationToken);
        }
    }
}