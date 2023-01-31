using MeControla.AgileManager.Integrations.Jira.Converters;
using MeControla.AgileManager.Integrations.Jira.Data.Configurations;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira
{
    public class BaseJira
    {
        private readonly string url;

        private readonly Api api;
        private readonly Cache cache;
        private readonly Parameters parameters;

        public BaseJira(IOptionsMonitor<JiraConfiguration> configuration,
                        string url,
                        JsonNamingPolicy namingPolicy)
            : this(configuration, url, false, namingPolicy)
        { }

        public BaseJira(IOptionsMonitor<JiraConfiguration> configuration,
                        string url,
                        bool cache,
                        JsonNamingPolicy namingPolicy)
        {
            this.url = $"{configuration.CurrentValue.Url}{url}";

            if (cache)
                this.cache = new Cache(configuration);

            api = new Api(namingPolicy, GetDefaultConverters())
            {
                Username = configuration.CurrentValue.Username,
                Password = configuration.CurrentValue.Password,
            };
            parameters = new Parameters();
        }

        private static IList<JsonConverter> GetDefaultConverters()
            => new List<JsonConverter> { new DateTimeJiraConverter() };

        protected void AddParam(string key, int value)
            => parameters.Add(key, value);

        protected void AddParam(string key, long value)
            => parameters.Add(key, value);

        protected void AddParam(string key, string value)
            => parameters.Add(key, value);

        private string GetRouteWithParams()
        {
            var route = url;

            foreach ((string key, string value) in parameters)
                route = route.Replace(key, value);

            return route;
        }

        protected async Task<TResponse> GetAsync<TResponse>(CancellationToken cancellationToken)
        {
            var route = GetRouteWithParams();

            if (!cache?.IsExpired(route) ?? false)
                return cache.Read<TResponse>(route);

            var response = await api.GetAsync<TResponse>(route, cancellationToken);

            cache?.Write(route, response);

            return response;
        }

        protected async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken)
        {
            var route = GetRouteWithParams();

            return await api.PostAsync<TResponse, TRequest>(route, request, cancellationToken);
        }
    }
}