namespace MeControla.AgileManager.Integrations.Jira.Data.Configurations
{
    public class JiraConfiguration : CacheConfiguration
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}