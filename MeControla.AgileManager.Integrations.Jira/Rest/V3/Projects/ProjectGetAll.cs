using MeControla.AgileManager.Integrations.Jira.Data.Configurations;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = MeControla.AgileManager.Integrations.Jira.Routes.ApiRoute.Project;

namespace MeControla.AgileManager.Integrations.Jira.Rest.V3.Projects
{
    public class ProjectGetAll : BaseJira, IProjectGetAll
    {
        public ProjectGetAll(IOptionsMonitor<JiraConfiguration> configuration)
            : base(configuration, url: route.GET_ALL, cache: true, namingPolicy: JsonNamingPolicy.CamelCase)
        { }

        public async Task<ProjectDto[]> Execute(CancellationToken cancellationToken)
            => await GetAsync<ProjectDto[]>(cancellationToken);
    }
}