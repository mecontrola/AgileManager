namespace MeControla.AgileManager.Updater.Core.Data.Configurations
{
    public interface IUpdaterConfiguration
    {
        string ApplicationName { get; }
        string FilenameToDownload { get; }
        string RenameFileDownloaded { get; }
        string GitUrl { get; }
    }
}