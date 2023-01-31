using MeControla.AgileManager.Integrations.Jira.Data.Configurations;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = MeControla.AgileManager.Integrations.Jira.Routes.AuthRoute.Session;

namespace MeControla.AgileManager.Integrations.Jira.Rest.V1.Auth
{
    public sealed class SessionGet : BaseJira, ISessionGet
    {
        public SessionGet(IOptionsMonitor<JiraConfiguration> configuration)
            : base(configuration, url: route.GET, namingPolicy: JsonNamingPolicy.CamelCase)
        { }

        public async Task<SessionDto> Execute(CancellationToken cancellationToken)
            => await GetAsync<SessionDto>(cancellationToken);
    }
}