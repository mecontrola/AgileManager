using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Data.Dtos.Jira;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = MeControla.AgileManager.Core.Integrations.Jira.Routes.AuthRoute.Session;

namespace MeControla.AgileManager.Core.Integrations.Jira.V1.Auth
{
    public class SessionGet : BaseJiraIntegration, ISessionGet
    {
        public SessionGet(ISettingsService settings)
            : base(settings, JsonNamingPolicy.CamelCase)
        { }

        public async Task<SessionDto> Execute(CancellationToken cancellationToken)
        {
            URL = route.GET;

            return await GetAsync<SessionDto>(cancellationToken);
        }
    }
}