namespace MeControla.AgileManager.Core.Integrations.Jira.Routes
{
    public static class AuthRoute
    {
        const string URL_ROOT = "/rest/auth/";
        const string VERSION_1 = "1";

        const string ROUTE_PREFIX_V1 = URL_ROOT + VERSION_1;

        public static class Session
        {
            public const string GET = ROUTE_PREFIX_V1 + "/session";
        }
    }
}