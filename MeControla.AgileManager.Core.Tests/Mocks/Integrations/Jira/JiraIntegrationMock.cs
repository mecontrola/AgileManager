using MeControla.AgileManager.Integrations.Jira;
using MeControla.AgileManager.Core.Services;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Tests.Mocks.Integrations.Jira
{
    //public class JiraIntegrationMock : Jira
    //{
    //    public JiraIntegrationMock(ISettingsService settings)
    //        : base(settings, JsonNamingPolicy.CamelCase)
    //    { }
    //
    //    public async Task<string> Execute(HttpStatusCode httpStatusCode, CancellationToken cancellationToken)
    //    {
    //        URL = $"{GetRouteBase()}?status={(int)httpStatusCode}";
    //
    //        return await GetAsync<string>(cancellationToken);
    //    }
    //
    //    public async Task<T> Execute<T>(string url, CancellationToken cancellationToken)
    //    {
    //        IsCached = true;
    //
    //        URL = url;
    //
    //        return await GetAsync<T>(cancellationToken);
    //    }
    //
    //    private static string GetRouteBase()
    //        => DataMock.ISSUE_SELF_1.Replace(DataMock.JIRA_HOST, string.Empty);
    //}
}