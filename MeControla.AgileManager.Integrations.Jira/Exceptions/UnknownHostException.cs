using System;

namespace MeControla.AgileManager.Integrations.Jira.Exceptions
{
    public class UnknownHostException : Exception
    {
        public UnknownHostException()
            : base(null)
        { }
    }
}