namespace Stefanini.ViaReport.Core.Data.Configurations
{
    public class JiraConfiguration : CacheConfiguration, IJiraConfiguration
    {
        public string Path { get; set; }
        public string EasyBIAccount { get; set; }
    }
}