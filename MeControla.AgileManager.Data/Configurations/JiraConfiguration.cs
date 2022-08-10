namespace MeControla.AgileManager.Data.Configurations
{
    public class JiraConfiguration : CacheConfiguration, IJiraConfiguration
    {
        public string Url { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}