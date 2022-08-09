using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Data.Dtos.Jira;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = MeControla.AgileManager.Core.Integrations.Jira.Routes.ApiRoute.Project;

namespace MeControla.AgileManager.Core.Integrations.Jira.V2.Projects
{
    public class ProjectGetAll : BaseJiraIntegration, IProjectGetAll
    {
        public ProjectGetAll(ISettingsService settings)
            : base(settings, JsonNamingPolicy.CamelCase)
        {
            IsCached = true;
        }

        public async Task<ProjectDto[]> Execute(CancellationToken cancellationToken)
        {
            URL = route.GET_ALL;

            return await GetAsync<ProjectDto[]>(cancellationToken);
        }
    }
}