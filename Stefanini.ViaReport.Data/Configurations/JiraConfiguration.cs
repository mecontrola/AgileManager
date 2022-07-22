namespace Stefanini.ViaReport.Data.Configurations
{
    public class JiraConfiguration : CacheConfiguration, IJiraConfiguration
    {
        public string Path { get; set; }
        public string EasyBIAccount { get; set; }
    }
}