using System;

namespace MeControla.AgileManager.Integrations.Jira.Exceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException()
            : base(null)
        { }
    }
}