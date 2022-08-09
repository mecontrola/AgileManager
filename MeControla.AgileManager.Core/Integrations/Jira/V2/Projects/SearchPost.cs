using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Dtos.Jira.Inputs;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = MeControla.AgileManager.Core.Integrations.Jira.Routes.ApiRoute.Search;

namespace MeControla.AgileManager.Core.Integrations.Jira.V2.Projects
{
    public class SearchPost : BaseJiraIntegration, ISearchPost
    {
        public SearchPost(ISettingsService settings)
            : base(settings, JsonNamingPolicy.CamelCase)
        { }

        public async Task<SearchDto> Execute(SearchInputDto request, CancellationToken cancellationToken)
        {
            URL = route.POST;

            return await PostAsync<SearchInputDto, SearchDto>(request, cancellationToken);
        }
    }
}