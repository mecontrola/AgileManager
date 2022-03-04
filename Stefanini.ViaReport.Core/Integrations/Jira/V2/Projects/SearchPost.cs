using Stefanini.ViaReport.Core.Data.Configurations;
using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Data.Dto.Jira.Inputs;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = Stefanini.ViaReport.Core.Integrations.Jira.Routes.ApiRoute.Search;

namespace Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects
{
    public class SearchPost : BaseJiraIntegration, ISearchPost
    {
        public SearchPost(IJiraConfiguration jiraConfiguration)
            : base(jiraConfiguration, JsonNamingPolicy.CamelCase)
        { }

        public async Task<SearchDto> Execute(string username, string password, SearchInputDto request, CancellationToken cancellationToken)
        {
            URL = route.POST;

            return await PostAsync<SearchInputDto, SearchDto>(username, password, request, cancellationToken);
        }
    }
}