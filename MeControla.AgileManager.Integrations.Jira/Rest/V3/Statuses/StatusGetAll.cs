using MeControla.AgileManager.Integrations.Jira.Data.Configurations;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = MeControla.AgileManager.Integrations.Jira.Routes.ApiRoute.Status;

namespace MeControla.AgileManager.Integrations.Jira.Rest.V3.Statuses
{
    public sealed class StatusGetAll : BaseJira, IStatusGetAll
    {
        public StatusGetAll(IOptionsMonitor<JiraConfiguration> configuration)
            : base(configuration, url: route.GET_ALL, cache: true, namingPolicy: JsonNamingPolicy.CamelCase)
        { }

        public async Task<StatusDto[]> Execute(CancellationToken cancellationToken)
            => await GetAsync<StatusDto[]>(cancellationToken);
    }
}