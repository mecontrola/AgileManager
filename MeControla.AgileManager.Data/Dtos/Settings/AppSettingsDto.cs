using MeControla.Kernel.Settings;

namespace MeControla.AgileManager.Data.Dtos.Settings
{
    public class AppSettingsDto : UserSettings
    {
        public bool PersistFilter { get; set; }
        public bool SyncAllData { get; set; }
        public int Cache { get; set; }
        public AppFilterDto FilterData { get; set; }
    }
}