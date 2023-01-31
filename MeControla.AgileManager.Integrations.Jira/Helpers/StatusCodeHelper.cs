using System.Net;
using System.Net.Http;

namespace MeControla.AgileManager.Integrations.Jira.Helpers
{
    internal static class StatusCodeHelper
    {
        internal static bool IsStatusOk(HttpResponseMessage response)
        => response.StatusCode.Equals(HttpStatusCode.OK);

        internal static bool IsStatusUnauthorized(HttpResponseMessage response)
            => response.StatusCode.Equals(HttpStatusCode.Unauthorized);

        internal static bool IsStatusForbidden(HttpResponseMessage response)
            => response.StatusCode.Equals(HttpStatusCode.Forbidden);
    }
}