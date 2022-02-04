using System;

namespace Stefanini.GitHub.Core.Exceptions
{
    public class GitHubForbiddenException : Exception
    {
        public GitHubForbiddenException()
            : base(null)
        { }
    }
}