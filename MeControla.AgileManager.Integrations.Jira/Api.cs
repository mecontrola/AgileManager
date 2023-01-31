using MeControla.AgileManager.Integrations.Jira.Exceptions;
using MeControla.AgileManager.Integrations.Jira.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira
{
    internal sealed class Api
    {
        private const string AUTHENTICATION_TYPE_BASIC = "Basic";
        private const string MEDIA_TYPE_JSON = "application/json";

        private readonly JsonSerializerOptions jsonOptions = new()
        {
            WriteIndented = false
        };

        public Api()
        { }

        public Api(JsonNamingPolicy propertyNamingPolicy)
            : this(propertyNamingPolicy, Array.Empty<JsonConverter>())
        { }

        public Api(JsonNamingPolicy propertyNamingPolicy, IList<JsonConverter> converters)
        {
            jsonOptions.PropertyNamingPolicy = propertyNamingPolicy;

            if (converters != null && converters.Any())
                foreach (var converter in converters)
                    jsonOptions.Converters.Add(converter);
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public async Task<TResponse> GetAsync<TResponse>(string url, CancellationToken cancellationToken)
            => await RequestData<TResponse>((client) => client.GetAsync(url, cancellationToken));

        public async Task<TResponse> PostAsync<TResponse, TRequest>(string url, TRequest request, CancellationToken cancellationToken)
        {
            var content = MountContent(request);
            return await RequestData<TResponse>((client) => client.PostAsync(url, content, cancellationToken));
        }

        private async Task<TResponse> RequestData<TResponse>(Func<HttpClient, Task<HttpResponseMessage>> callFunc)
        {
            try
            {
                var client = CreateInstance();
                var response = await callFunc(client);
                return await GetResponse<TResponse>(response);
            }
            catch (HttpRequestException ex)
            {
                if (ex.InnerException is SocketException)
                    throw new UnknownHostException();

                throw;
            }
        }

        private HttpClient CreateInstance()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(CreateMediaApllicationJson());

            if (!string.IsNullOrWhiteSpace(Username))
                client.DefaultRequestHeaders.Authorization = CreateAuthenticationHeader(Username, Password);

            return client;
        }

        private static MediaTypeWithQualityHeaderValue CreateMediaApllicationJson()
            => new(MEDIA_TYPE_JSON);

        private static AuthenticationHeaderValue CreateAuthenticationHeader(string username, string password)
            => new(AUTHENTICATION_TYPE_BASIC, GetAuhenticationBase64(username, password));

        private static string GetAuhenticationBase64(string username, string password)
            => Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));

        private StringContent MountContent<T>(T data)
        {
            var json = JsonSerializer.Serialize<T>(data, jsonOptions);
            return new StringContent(json, Encoding.UTF8, MEDIA_TYPE_JSON);
        }

        public async Task<TResponse> GetResponse<TResponse>(HttpResponseMessage response)
        {
            await GetResponseError(response);

            return await GetDeserializeResponde<TResponse>(response);
        }

        private async Task<TResponse> GetDeserializeResponde<TResponse>(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResponse>(json, jsonOptions);
        }

        private static async Task GetResponseError(HttpResponseMessage response)
        {
            if (StatusCodeHelper.IsStatusOk(response))
                return;

            if (StatusCodeHelper.IsStatusUnauthorized(response))
                throw new AuthenticationException();

            if (StatusCodeHelper.IsStatusForbidden(response))
                throw new ForbiddenException();

            var body = await response.Content.ReadAsStringAsync();
            throw new Exception($"API\nError: Status {response.StatusCode}\nDescription: {body}");
        }
    }
}