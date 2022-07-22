using Stefanini.ViaReport.Data.Configurations;
using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = Stefanini.ViaReport.Core.Integrations.Jira.Routes.ApiRoute.StatusCategory;

namespace Stefanini.ViaReport.Core.Integrations.Jira.V2.StatusCategories
{
    public class StatusCategoryGetAll : BaseJiraIntegration, IStatusCategoryGetAll
    {
        public StatusCategoryGetAll(IJiraConfiguration jiraConfiguration)
            : base(jiraConfiguration, JsonNamingPolicy.CamelCase)
        {
            IsCached = true;
        }

        public async Task<StatusCategoryDto[]> Execute(string username, string password, CancellationToken cancellationToken)
        {
            URL = route.GET_ALL;

            return await GetAsync<StatusCategoryDto[]>(username, password, cancellationToken);
        }
    }
}