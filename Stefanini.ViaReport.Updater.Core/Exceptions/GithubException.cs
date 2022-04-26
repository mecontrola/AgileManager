using System;

namespace Stefanini.ViaReport.Updater.Core.Exceptions
{
    public class GithubException : Exception
    {
        public GithubException()
            : this(string.Empty)
        { }

        public GithubException(string message)
            : base(message)
        { }
    }
}