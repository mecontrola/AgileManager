namespace Stefanini.GitHub.Core.Integrations.Routes
{
    internal static class GitHubRoutes
    {
        public static class UserInfo
        {
            public const string INFO_GET = "/";
        }

        public static class Search
        {
            private const string URL_BASE = "/search";

            public const string ISSUES_GET = URL_BASE + "/issues?q={query}";
        }
    }
}