using Stefanini.ViaReport.Data.Configurations;
using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = Stefanini.ViaReport.Core.Integrations.Jira.Routes.ApiRoute.Issue;

namespace Stefanini.ViaReport.Core.Integrations.Jira.V2.Issues
{
    public class IssueGet : BaseJiraIntegration, IIssueGet
    {
        public IssueGet(IJiraConfiguration jiraConfiguration)
            : base(jiraConfiguration, JsonNamingPolicy.CamelCase)
        {
            IsCached = true;
        }

        public async Task<IssueDto> Execute(string username, string password, string issueKey, CancellationToken cancellationToken)
        {
            URL = route.GET.Replace("{issueKey}", issueKey);

            return await GetAsync<IssueDto>(username, password, cancellationToken);
        }
    }
}