using Stefanini.Core.Settings;

namespace Stefanini.ViaReport.Data.Dtos.Settings
{
    public class AppSettingsDto : UserSettings
    {
        public bool PersistFilter { get; set; }
        public AppFilterDto FilterData { get; set; }
    }
}