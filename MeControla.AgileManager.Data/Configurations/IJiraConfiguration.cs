namespace MeControla.AgileManager.Data.Configurations
{
    public interface IJiraConfiguration : ICacheConfiguration
    {
        string Url { get; }
        string Username { get; }
        string Password { get; }
    }
}