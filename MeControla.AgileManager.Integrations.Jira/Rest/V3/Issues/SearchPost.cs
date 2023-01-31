using MeControla.AgileManager.Integrations.Jira.Data.Configurations;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos.Inputs;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = MeControla.AgileManager.Integrations.Jira.Routes.ApiRoute.Search;

namespace MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues
{
    public sealed class SearchPost : BaseJira, ISearchPost
    {
        public SearchPost(IOptionsMonitor<JiraConfiguration> configuration)
            : base(configuration, url: route.POST, namingPolicy: JsonNamingPolicy.CamelCase)
        { }

        public async Task<SearchDto> Execute(SearchInputDto request, CancellationToken cancellationToken)
            => await PostAsync<SearchInputDto, SearchDto>(request, cancellationToken);
    }
}