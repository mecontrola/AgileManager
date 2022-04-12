using Stefanini.Core.Settings;

namespace Stefanini.Core.Data.Dto.Settings
{
    public class AppSettingsDto : UserSettings
    {
        public bool PersistFilter { get; set; }
        public AppFilterDto FilterData { get; set; }
    }
}