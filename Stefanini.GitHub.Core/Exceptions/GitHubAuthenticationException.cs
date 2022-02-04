using System;

namespace Stefanini.GitHub.Core.Exceptions
{
    public class GitHubAuthenticationException : Exception
    {
        public GitHubAuthenticationException()
            : base(null)
        { }
    }
}