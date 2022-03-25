using Stefanini.GitHub.Core.Data.Configurations;
using Stefanini.GitHub.Core.Exceptions;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.GitHub.Core.Integrations.GitHub
{
    public abstract class BaseGitHubIntegration
    {
        private const string AUTHENTICATION_TYPE_BASIC = "Basic";
        private const string MEDIA_TYPE_JSON = "application/vnd.github.v3+json";

        private readonly JsonSerializerOptions jsonOptions;
        private readonly IGitHubConfiguration gitHubConfiguration;

        public BaseGitHubIntegration(IGitHubConfiguration gitHubConfiguration, JsonNamingPolicy propertyNamingPolicy)
        {
            this.gitHubConfiguration = gitHubConfiguration;

            jsonOptions = new()
            {
                PropertyNamingPolicy = propertyNamingPolicy,
                WriteIndented = false
            };
        }

        protected string URL { get; set; }

        protected string GetRoute()
            => $"{gitHubConfiguration.Path}{URL}";

        protected static HttpClient CreateInstance(string username, string password)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(CreateMediaApllicationJson());
            client.DefaultRequestHeaders.Authorization = CreateAuthenticationHeader(username, password);
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("ScraperBot", "1.0"));
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
            var client = CreateInstance(username, password);
            var response = await client.GetAsync(GetRoute(), cancellationToken);
            return await GetResponse<TResponse>(response);
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
                throw new GitHubAuthenticationException();

            if (IsStatusForbidden(response))
                throw new GitHubForbiddenException();

            throw new GitHubException($"Jira Error: Status {response.StatusCode}");
        }

        private async Task<TResponse> GetDeserializeResponde<TResponse>(HttpResponseMessage response)
            => JsonSerializer.Deserialize<TResponse>(await response.Content.ReadAsStringAsync(), jsonOptions);

        private static bool IsStatusOk(HttpResponseMessage response)
            => response.StatusCode.Equals(HttpStatusCode.OK);

        private static bool IsStatusUnauthorized(HttpResponseMessage response)
            => response.StatusCode.Equals(HttpStatusCode.Unauthorized);

        private static bool IsStatusForbidden(HttpResponseMessage response)
            => response.StatusCode.Equals(HttpStatusCode.Forbidden);
    }
}