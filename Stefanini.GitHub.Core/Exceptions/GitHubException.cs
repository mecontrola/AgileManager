using System;

namespace Stefanini.GitHub.Core.Exceptions
{
    public class GitHubException : Exception
    {
        public GitHubException(string message)
            : base(message)
        { }
    }
}