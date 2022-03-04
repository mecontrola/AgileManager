using Stefanini.ViaReport.Core.Data.Configurations;
using Stefanini.ViaReport.Core.Data.Dto.Jira;
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
        { }

        public async Task<StatusDto[]> Execute(string username, string password, CancellationToken cancellationToken)
        {
            URL = route.GET_ALL;

            return await GetAsync<StatusDto[]>(username, password, cancellationToken);
        }
    }
}