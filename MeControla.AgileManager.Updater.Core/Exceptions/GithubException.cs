using System;

namespace MeControla.AgileManager.Updater.Core.Exceptions
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