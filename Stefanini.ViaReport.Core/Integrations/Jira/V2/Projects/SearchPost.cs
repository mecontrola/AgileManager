using Stefanini.ViaReport.Core.Data.Configurations;
using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Data.Dto.Jira.Inputs;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects
{
    public class SearchPost : BaseJiraIntegration, ISearchPost
    {
        private const string API_URL = "/rest/api/2/search?expand=changelog";

        public SearchPost(IJiraConfiguration jiraConfiguration)
            : base(jiraConfiguration, JsonNamingPolicy.CamelCase)
        { }

        public async Task<SearchDto> Execute(string username, string password, SearchInputDto request, CancellationToken cancellationToken)
        {
            URL = API_URL;

            return await PostAsync<SearchInputDto, SearchDto>(username, password, request, cancellationToken);
        }
    }
}