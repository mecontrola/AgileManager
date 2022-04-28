namespace Stefanini.ViaReport.Updater.Core.Data.Configurations
{
    public class UpdaterConfiguration : IUpdaterConfiguration
    {
        public string ApplicationName { get; set; }
        public string FilenameToDownload { get; set; }
        public string RenameFileDownloaded { get; set; }
        public string GitUrl { get; set; }
    }
}