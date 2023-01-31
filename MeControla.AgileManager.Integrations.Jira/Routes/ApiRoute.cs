namespace MeControla.AgileManager.Integrations.Jira.Routes
{
    public static class ApiRoute
    {
        const string URL_ROOT = "/rest/api/";
        const string VERSION_3 = "3";

        const string ROUTE_PREFIX_V3 = URL_ROOT + VERSION_3;

        public static class Context
        {
            private const string URL_BASE = Field.GET + "/context";

            public const string PARAM_FIELD_ID = Field.PARAM_ID;
            public const string PARAM_ID = "{contextId}";

            public const string GET_ALL = URL_BASE;
            public const string GET = URL_BASE + $"/{PARAM_ID}";
        }

        public static class Field
        {
            private const string URL_BASE = ROUTE_PREFIX_V3 + "/field";

            public const string PARAM_ID = "{fieldId}";

            public const string GET_ALL = URL_BASE;
            public const string GET = URL_BASE + $"/{PARAM_ID}";
        }

        public static class Issue
        {
            private const string URL_BASE = ROUTE_PREFIX_V3 + "/issue";

            public const string PARAM_KEY = "{issueKey}";

            public const string GET = URL_BASE + $"/{PARAM_KEY}?expand=changelog";
        }

        public static class IssueType
        {
            private const string URL_BASE = ROUTE_PREFIX_V3 + "/issuetype";

            public const string GET_ALL = URL_BASE;
        }

        public static class Option
        {
            private const string URL_BASE = Context.GET + "/option";

            public const string PARAM_FIELD_ID = Context.PARAM_FIELD_ID;
            public const string PARAM_CONTEXT_ID = Context.PARAM_ID;

            public const string GET_ALL = URL_BASE;
        }

        public static class Project
        {
            private const string URL_BASE = ROUTE_PREFIX_V3 + "/project";

            public const string GET_ALL = URL_BASE;
        }

        public static class Search
        {
            private const string URL_BASE = ROUTE_PREFIX_V3 + "/search";

            public const string POST = URL_BASE;
        }

        public static class Status
        {
            private const string URL_BASE = ROUTE_PREFIX_V3 + "/status";

            public const string GET_ALL = URL_BASE;
        }

        public static class StatusCategory
        {
            private const string URL_BASE = ROUTE_PREFIX_V3 + "/statuscategory";

            public const string GET_ALL = URL_BASE;
        }
    }
}