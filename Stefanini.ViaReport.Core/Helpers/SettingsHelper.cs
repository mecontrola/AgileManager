using Stefanini.Core.Extensions;
using Stefanini.Core.Settings;
using Stefanini.ViaReport.Data.Dtos.Settings;

namespace Stefanini.ViaReport.Core.Helpers
{
    public class SettingsHelper : ISettingsHelper
    {
        private const string SETTINGS_FILENAME = "usersettings.json";

        private readonly ISettingsManager<AppSettingsDto> settingsManager;

        public SettingsHelper()
            : this(new SettingsManager<AppSettingsDto>(SETTINGS_FILENAME))
        { }

        public SettingsHelper(ISettingsManager<AppSettingsDto> settingsManager)
        {
            this.settingsManager = settingsManager;

            Data = new()
            {
                Username = settingsManager.Data.Username,
                Password = settingsManager.Data.Password.Base64Decode(),
                PersistFilter = settingsManager.Data.PersistFilter,
                SyncAllData = settingsManager.Data.SyncAllData,
                FilterData = settingsManager.Data.FilterData,
            };
        }

        public AppSettingsDto Data { get; set; }

        public void Save()
        {
            settingsManager.Data.Username = Data.Username;
            settingsManager.Data.Password = Data.Password.Base64Encode();
            settingsManager.Data.PersistFilter = Data.PersistFilter;
            settingsManager.Data.SyncAllData = Data.SyncAllData;
            settingsManager.Data.FilterData = settingsManager.Data.PersistFilter
                                            ? Data.FilterData
                                            : null;
            settingsManager.SaveSettings();
        }
    }
}