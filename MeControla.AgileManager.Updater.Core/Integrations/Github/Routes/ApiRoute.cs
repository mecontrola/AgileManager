namespace MeControla.AgileManager.Updater.Core.Integrations.Github.Routes
{
    public static class ApiRoute
    {
        const string URL_ROOT = "/repos/mecontrola/stefanini";

        public static class Releases
        {
            private const string URL_BASE = URL_ROOT + "/releases";

            public const string LASTEST = URL_BASE + "/latest";
        }
    }
}