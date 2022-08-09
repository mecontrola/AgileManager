using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Data.Dtos.Jira;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = MeControla.AgileManager.Core.Integrations.Jira.Routes.ApiRoute.StatusCategory;

namespace MeControla.AgileManager.Core.Integrations.Jira.V2.StatusCategories
{
    public class StatusCategoryGetAll : BaseJiraIntegration, IStatusCategoryGetAll
    {
        public StatusCategoryGetAll(ISettingsService settings)
            : base(settings, JsonNamingPolicy.CamelCase)
        {
            IsCached = true;
        }

        public async Task<StatusCategoryDto[]> Execute(CancellationToken cancellationToken)
        {
            URL = route.GET_ALL;

            return await GetAsync<StatusCategoryDto[]>(cancellationToken);
        }
    }
}