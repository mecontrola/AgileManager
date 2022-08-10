using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Data.Dtos.Jira;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = MeControla.AgileManager.Core.Integrations.Jira.Routes.ApiRoute.IssueType;

namespace MeControla.AgileManager.Core.Integrations.Jira.V2.IssueTypes
{
    public class IssueTypeGetAll : BaseJiraIntegration, IIssueTypeGetAll
    {
        public IssueTypeGetAll(ISettingsService settings)
            : base(settings, JsonNamingPolicy.CamelCase)
        {
            IsCached = true;
        }

        public async Task<IssueTypeDto[]> Execute(CancellationToken cancellationToken)
        {
            URL = route.GET_ALL;

            return await GetAsync<IssueTypeDto[]>(cancellationToken);
        }
    }
}