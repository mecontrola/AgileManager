using MeControla.AgileManager.Integrations.Jira.Data.Configurations;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = MeControla.AgileManager.Integrations.Jira.Routes.ApiRoute.Field;

namespace MeControla.AgileManager.Integrations.Jira.Rest.V3.Fields
{
    public class FieldGetAll : BaseJira, IFieldGetAll
    {
        public FieldGetAll(IOptionsMonitor<JiraConfiguration> configuration)
            : base(configuration, url: route.GET_ALL, cache: true, namingPolicy: JsonNamingPolicy.CamelCase)
        { }

        public async Task<FieldDto[]> Execute(CancellationToken cancellationToken)
            => await GetAsync<FieldDto[]>(cancellationToken);
    }
}