using Stefanini.ViaReport.Updater.Core.Data.Configurations;
using Stefanini.ViaReport.Updater.Core.Exceptions;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Updater.Core.Integrations.Github
{
    public abstract class BaseGithubIntegration
    {
        private const string MEDIA_TYPE_JSON = "application/json";
        private const string MEDIA_USER_AGENT_NAME = "MeControlaUpdater";
        private const string MEDIA_USER_AGENT_VALUE = "v1.0.0.0";

        private readonly JsonSerializerOptions jsonOptions;
        private readonly IUpdaterConfiguration updaterConfiguration;

        public BaseGithubIntegration(IUpdaterConfiguration updaterConfiguration, JsonNamingPolicy propertyNamingPolicy)
        {
            this.updaterConfiguration = updaterConfiguration;

            jsonOptions = new()
            {
                PropertyNamingPolicy = propertyNamingPolicy,
                WriteIndented = false
            };
        }

        protected string URL { get; set; }

        protected string GetRoute()
            => $"{updaterConfiguration.GitUrl}{URL}";

        private static HttpClient CreateInstance()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.UserAgent.Add(CreateProductInfoHeader());
            client.DefaultRequestHeaders.Accept.Add(CreateMediaApllicationJson());
            return client;
        }

        private static MediaTypeWithQualityHeaderValue CreateMediaApllicationJson()
            => new(MEDIA_TYPE_JSON);

        private static ProductInfoHeaderValue CreateProductInfoHeader()
            => new(MEDIA_USER_AGENT_NAME, MEDIA_USER_AGENT_VALUE);

        protected async Task<TResponse> GetAsync<TResponse>(CancellationToken cancellationToken)
        {
            var client = CreateInstance();
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

            throw new GithubException($"Github Error: Status {response.StatusCode}");
        }

        private async Task<TResponse> GetDeserializeResponde<TResponse>(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();

            try
            {
                return GetDeserializeResponde<TResponse>(json);
            }
            catch (Exception ex)
            {

                throw new GithubException($"Jira Deserialize Error: {ex.Message}");
            }
        }

        private TResponse GetDeserializeResponde<TResponse>(string json)
            => JsonSerializer.Deserialize<TResponse>(json, jsonOptions);

        private static bool IsStatusOk(HttpResponseMessage response)
            => response.StatusCode.Equals(HttpStatusCode.OK);
    }
}