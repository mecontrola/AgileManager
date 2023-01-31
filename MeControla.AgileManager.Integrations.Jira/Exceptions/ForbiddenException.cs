using System;

namespace MeControla.AgileManager.Integrations.Jira.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException()
            : base(null)
        { }
    }
}