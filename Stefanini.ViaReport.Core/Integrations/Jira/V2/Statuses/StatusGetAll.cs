using Stefanini.ViaReport.Core.Data.Configurations;
using Stefanini.ViaReport.Core.Data.Dto.Jira;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Integrations.Jira.V2.Statuses
{
    public class StatusGetAll : BaseJiraIntegration, IStatusGetAll
    {
        private const string API_URL = "/rest/api/2/status";

        public StatusGetAll(IJiraConfiguration jiraConfiguration)
            : base(jiraConfiguration, JsonNamingPolicy.CamelCase)
        { }

        public async Task<StatusDto[]> Execute(string username, string password, CancellationToken cancellationToken)
        {
            URL = API_URL;

            return await GetAsync<StatusDto[]>(username, password, cancellationToken);
        }
    }
}