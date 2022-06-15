using Stefanini.ViaReport.Core.Converters;
using Stefanini.ViaReport.Core.Exceptions;
using Stefanini.ViaReport.Data.Configurations;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Integrations.Jira
{
    public abstract class BaseJiraIntegration : BaseCacheJiraIntegration
    {
        private const string AUTHENTICATION_TYPE_BASIC = "Basic";
        private const string MEDIA_TYPE_JSON = "application/json";

        private readonly JsonSerializerOptions jsonOptions;
        private readonly IJiraConfiguration jiraConfiguration;

        public BaseJiraIntegration(IJiraConfiguration jiraConfiguration, JsonNamingPolicy propertyNamingPolicy)
            : base(jiraConfiguration)
        {
            this.jiraConfiguration = jiraConfiguration;

            jsonOptions = new()
            {
                PropertyNamingPolicy = propertyNamingPolicy,
                WriteIndented = false
            };
            jsonOptions.Converters.Add(new DateTimeJiraConverter());
        }

        protected string URL { get; set; }

        protected string GetRoute()
            => $"{jiraConfiguration.Path}{URL}";

        protected static HttpClient CreateInstance(string username, string password)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(CreateMediaApllicationJson());
            client.DefaultRequestHeaders.Authorization = CreateAuthenticationHeader(username, password);
            return client;
        }

        private static MediaTypeWithQualityHeaderValue CreateMediaApllicationJson()
            => new(MEDIA_TYPE_JSON);

        private static AuthenticationHeaderValue CreateAuthenticationHeader(string username, string password)
            => new(AUTHENTICATION_TYPE_BASIC, GetAuhenticationBase64(username, password));

        private static string GetAuhenticationBase64(string username, string password)
            => Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));

        protected async Task<TResponse> GetAsync<TResponse>(string username, string password, CancellationToken cancellationToken)
        {
            var route = GetRoute();

            if (IsLoadCachedFile(route))
            {
                var json = LoadCacheFile(route);
                return GetDeserializeResponde<TResponse>(json);
            }

            return await RequestData<TResponse>(username, password, (client) => client.GetAsync(route, cancellationToken));
        }

        protected async Task<TResponse> PostAsync<TRequest, TResponse>(string username, string password, TRequest request, CancellationToken cancellationToken)
        {
            var content = MountContent(request);
            return await RequestData<TResponse>(username, password, (client) => client.PostAsync(GetRoute(), content, cancellationToken));
        }

        private async Task<TResponse> RequestData<TResponse>(string username, string password, Func<HttpClient, Task<HttpResponseMessage>> callFunc)
        {
            try
            {
                var client = CreateInstance(username, password);
                var response = await callFunc(client);
                return await GetResponse<TResponse>(response);
            }
            catch (HttpRequestException ex)
            {
                if (ex.InnerException is SocketException)
                    throw new JiraUnknownHostException();

                throw ex;
            }
        }

        private StringContent MountContent<T>(T data)
        {
            var json = JsonSerializer.Serialize<T>(data, jsonOptions);
            return new StringContent(json, Encoding.UTF8, MEDIA_TYPE_JSON);
        }

        private async Task<TResponse> GetResponse<TResponse>(HttpResponseMessage response)
        {
            GetResponseError(response);

            return await GetDeserializeResponde<TResponse>(response);
        }

        private static void GetResponseError(HttpResponseMessage response)
        {
            if (IsStatusOk(response))
                return;

            if (IsStatusUnauthorized(response))
                throw new JiraAuthenticationException();

            if (IsStatusForbidden(response))
                throw new JiraForbiddenException();

            throw new JiraException($"Jira Error: Status {response.StatusCode}");
        }

        private async Task<TResponse> GetDeserializeResponde<TResponse>(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();

            if (IsCachedResponse())
                SaveCacheFile(response.RequestMessage.RequestUri.AbsoluteUri, json);

            try
            {
                return GetDeserializeResponde<TResponse>(json);
            }
            catch (Exception ex)
            {
                throw new JiraException($"Jira Deserialize Error: {ex.Message}");
            }
        }

        private TResponse GetDeserializeResponde<TResponse>(string json)
            => JsonSerializer.Deserialize<TResponse>(json, jsonOptions);

        private static bool IsStatusOk(HttpResponseMessage response)
            => response.StatusCode.Equals(HttpStatusCode.OK);

        private static bool IsStatusUnauthorized(HttpResponseMessage response)
            => response.StatusCode.Equals(HttpStatusCode.Unauthorized);

        private static bool IsStatusForbidden(HttpResponseMessage response)
            => response.StatusCode.Equals(HttpStatusCode.Forbidden);
    }
}