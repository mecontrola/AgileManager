using System.IO;

namespace MeControla.AgileManager.Integrations.Jira.Exceptions
{
    public class CacheNotFoundException : IOException
    {
        public CacheNotFoundException()
            : base(null)
        { }
    }
}