using Stefanini.ViaReport.Data.Configurations;
using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = Stefanini.ViaReport.Core.Integrations.Jira.Routes.ApiRoute.IssueType;

namespace Stefanini.ViaReport.Core.Integrations.Jira.V2.IssueTypes
{
    public class IssueTypeGetAll : BaseJiraIntegration, IIssueTypeGetAll
    {
        public IssueTypeGetAll(IJiraConfiguration jiraConfiguration)
            : base(jiraConfiguration, JsonNamingPolicy.CamelCase)
        {
            IsCached = true;
        }

        public async Task<IssueTypeDto[]> Execute(string username, string password, CancellationToken cancellationToken)
        {
            URL = route.GET_ALL;

            return await GetAsync<IssueTypeDto[]>(username, password, cancellationToken);
        }
    }
}