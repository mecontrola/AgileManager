namespace Stefanini.GitHub.Core.Data.Configurations
{
    public interface IGitHubConfiguration
    {
        string Path { get; }
        string Username { get; }
        string Password { get; }
    }
}