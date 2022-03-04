using Stefanini.ViaReport.Core.Data.Configurations;
using Stefanini.ViaReport.Core.Data.Dto.Jira;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Integrations.Jira.V2.Issues
{
    public class IssueGet : BaseJiraIntegration, IIssueGet
    {
        private const string API_URL = "/rest/api/2/issue/{issueKey}?expand=changelog";

        public IssueGet(IJiraConfiguration jiraConfiguration)
            : base(jiraConfiguration, JsonNamingPolicy.CamelCase)
        {
            IsCached = true;
        }

        public async Task<IssueDto> Execute(string username, string password, string issueKey, CancellationToken cancellationToken)
        {
            URL = API_URL.Replace("{issueKey}", issueKey);
            
            return await GetAsync<IssueDto>(username, password, cancellationToken);
        }
    }
}