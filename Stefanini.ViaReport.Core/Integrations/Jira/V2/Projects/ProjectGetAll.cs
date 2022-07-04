using Stefanini.ViaReport.Data.Configurations;
using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = Stefanini.ViaReport.Core.Integrations.Jira.Routes.ApiRoute.Project;

namespace Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects
{
    public class ProjectGetAll : BaseJiraIntegration, IProjectGetAll
    {
        public ProjectGetAll(IJiraConfiguration jiraConfiguration)
            : base(jiraConfiguration, JsonNamingPolicy.CamelCase)
        {
            IsCached = true;
        }

        public async Task<ProjectDto[]> Execute(string username, string password, CancellationToken cancellationToken)
        {
            URL = route.GET_ALL;

            return await GetAsync<ProjectDto[]>(username, password, cancellationToken);
        }
    }
}