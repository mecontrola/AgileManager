using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Data.Dtos.Jira;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = MeControla.AgileManager.Core.Integrations.Jira.Routes.ApiRoute.Issue;

namespace MeControla.AgileManager.Core.Integrations.Jira.V2.Issues
{
    public class IssueGet : BaseJiraIntegration, IIssueGet
    {
        public IssueGet(ISettingsService settings)
            : base(settings, JsonNamingPolicy.CamelCase)
        {
            IsCached = true;
        }

        public async Task<IssueDto> Execute(string issueKey, CancellationToken cancellationToken)
        {
            URL = route.GET.Replace("{issueKey}", issueKey);

            return await GetAsync<IssueDto>(cancellationToken);
        }
    }
}