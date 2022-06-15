namespace Stefanini.ViaReport.Data.Configurations
{
    public interface IJiraConfiguration : ICacheConfiguration
    {
        string EasyBIAccount { get; }
        string Path { get; }
    }
}