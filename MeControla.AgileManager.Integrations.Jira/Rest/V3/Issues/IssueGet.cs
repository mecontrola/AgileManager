using MeControla.AgileManager.Integrations.Jira.Data.Configurations;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = MeControla.AgileManager.Integrations.Jira.Routes.ApiRoute.Issue;

namespace MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues
{
    public sealed class IssueGet : BaseJira, IIssueGet
    {
        public IssueGet(IOptionsMonitor<JiraConfiguration> configuration)
            : base(configuration, url: route.GET, cache: true, namingPolicy: JsonNamingPolicy.CamelCase)
        { }

        public async Task<IssueDto> Execute(string issueKey, CancellationToken cancellationToken)
        {
            AddParam(route.PARAM_KEY, issueKey);

            return await GetAsync<IssueDto>(cancellationToken);
        }
    }
}