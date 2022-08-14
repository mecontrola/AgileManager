using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Data.Dtos.Jira;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = MeControla.AgileManager.Core.Integrations.Jira.Routes.ApiRoute.Field;

namespace MeControla.AgileManager.Core.Integrations.Jira.V2.Fields
{
    public class FieldGetAll : BaseJiraIntegration, IFieldGetAll
    {
        public FieldGetAll(ISettingsService settings)
            : base(settings, JsonNamingPolicy.CamelCase)
        {
            IsCached = true;
        }

        public async Task<FieldDto[]> Execute(CancellationToken cancellationToken)
        {
            URL = route.GET_ALL;

            return await GetAsync<FieldDto[]>(cancellationToken);
        }
    }
}