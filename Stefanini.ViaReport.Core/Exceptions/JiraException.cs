using System;

namespace Stefanini.ViaReport.Core.Exceptions
{
    public class JiraException : Exception
    {
        public JiraException(string message)
            : base(message)
        { }
    }
}