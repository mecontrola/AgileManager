using Stefanini.ViaReport.Core.Data.Configurations;
using Stefanini.ViaReport.Core.Data.Dto.Jira;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects
{
    public class ProjectGetAll : BaseJiraIntegration, IProjectGetAll
    {
        private const string API_URL = "/rest/api/2/project";

        public ProjectGetAll(IJiraConfiguration jiraConfiguration)
            : base(jiraConfiguration, JsonNamingPolicy.CamelCase)
        {
            IsCached = true;
        }

        public async Task<ProjectDto[]> Execute(string username, string password, CancellationToken cancellationToken)
        {
            URL = API_URL;

            return await GetAsync<ProjectDto[]>(username, password, cancellationToken);
        }
    }
}