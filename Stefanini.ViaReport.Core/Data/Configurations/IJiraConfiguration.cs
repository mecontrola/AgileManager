namespace Stefanini.ViaReport.Core.Data.Configurations
{
    public interface IJiraConfiguration : ICacheConfiguration
    {
        string EasyBIAccount { get; }
        string Path { get; }
    }
}