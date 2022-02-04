namespace Stefanini.ViaReport.Core.Integrations.Routes
{
    internal static class EasyBIRoute
    {
        public static class Export
        {
            private const string URL_BASE = "/plugins/servlet/eazybi/accounts/{accountId}";

            public const string GET_ALL = URL_BASE + "/export/report/{reportId}.{reportFormat}";
        }
    }
}