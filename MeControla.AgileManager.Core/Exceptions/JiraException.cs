using System;

namespace MeControla.AgileManager.Core.Exceptions
{
    public class JiraException : Exception
    {
        public JiraException(string message)
            : base(message)
        { }
    }
}