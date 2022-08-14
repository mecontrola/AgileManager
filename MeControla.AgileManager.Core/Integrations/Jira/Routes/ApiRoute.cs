namespace MeControla.AgileManager.Core.Integrations.Jira.Routes
{
    public static class ApiRoute
    {
        const string URL_ROOT = "/rest/api/";
        const string VERSION_2 = "2";

        const string ROUTE_PREFIX_V2 = URL_ROOT + VERSION_2;

        public static class Field
        {
            private const string URL_BASE = ROUTE_PREFIX_V2 + "/field";

            public const string GET_ALL = URL_BASE;
        }

        public static class Issue
        {
            private const string URL_BASE = ROUTE_PREFIX_V2 + "/issue";

            public const string GET = URL_BASE + "/{issueKey}?expand=changelog";
        }

        public static class IssueType
        {
            private const string URL_BASE = ROUTE_PREFIX_V2 + "/issuetype";

            public const string GET_ALL = URL_BASE;
        }

        public static class Project
        {
            private const string URL_BASE = ROUTE_PREFIX_V2 + "/project";

            public const string GET_ALL = URL_BASE;
        }

        public static class Search
        {
            private const string URL_BASE = ROUTE_PREFIX_V2 + "/search";

            public const string POST = URL_BASE;
        }

        public static class Status
        {
            private const string URL_BASE = ROUTE_PREFIX_V2 + "/status";

            public const string GET_ALL = URL_BASE;
        }

        public static class StatusCategory
        {
            private const string URL_BASE = ROUTE_PREFIX_V2 + "/statuscategory";

            public const string GET_ALL = URL_BASE;
        }
    }
}