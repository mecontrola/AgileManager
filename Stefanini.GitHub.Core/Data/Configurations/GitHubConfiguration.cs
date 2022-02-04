namespace Stefanini.GitHub.Core.Data.Configurations
{
    public class GitHubConfiguration : IGitHubConfiguration
    {
        public string Path { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}