using MeControla.AgileManager.Integrations.Jira.Data.Configurations;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = MeControla.AgileManager.Integrations.Jira.Routes.ApiRoute.Context;

namespace MeControla.AgileManager.Integrations.Jira.Rest.V3.Contexts
{
    public class ContextGetAll : BaseJira, IContextGetAll
    {
        public ContextGetAll(IOptionsMonitor<JiraConfiguration> configuration)
            : base(configuration, url: route.GET_ALL, cache: true, namingPolicy: JsonNamingPolicy.CamelCase)
        { }

        public async Task<FieldContextDto> Execute(string fieldId, CancellationToken cancellationToken)
        {
            AddParam(route.PARAM_FIELD_ID, fieldId);

            return await GetAsync<FieldContextDto>(cancellationToken);
        }
    }
}