using MeControla.AgileManager.Integrations.Jira.Data.Configurations;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = MeControla.AgileManager.Integrations.Jira.Routes.ApiRoute.Option;

namespace MeControla.AgileManager.Integrations.Jira.Rest.V3.Options
{
    public class OptionGetAll : BaseJira, IOptionGetAll
    {
        public OptionGetAll(IOptionsMonitor<JiraConfiguration> configuration)
            : base(configuration, url: route.GET_ALL, cache: true, namingPolicy: JsonNamingPolicy.CamelCase)
        { }

        public async Task<FieldContextOptionDto> Execute(string fieldId, string contextId, CancellationToken cancellationToken)
        {
            AddParam(route.PARAM_FIELD_ID, fieldId);
            AddParam(route.PARAM_CONTEXT_ID, contextId);

            return await GetAsync<FieldContextOptionDto>(cancellationToken);
        }
    }
}