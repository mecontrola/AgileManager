using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Data.Dtos.Jira;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = MeControla.AgileManager.Core.Integrations.Jira.Routes.ApiRoute.Status;

namespace MeControla.AgileManager.Core.Integrations.Jira.V2.Statuses
{
    public class StatusGetAll : BaseJiraIntegration, IStatusGetAll
    {
        public StatusGetAll(ISettingsService settings)
            : base(settings, JsonNamingPolicy.CamelCase)
        {
            IsCached = true;
        }

        public async Task<StatusDto[]> Execute(CancellationToken cancellationToken)
        {
            URL = route.GET_ALL;

            return await GetAsync<StatusDto[]>(cancellationToken);
        }
    }
}