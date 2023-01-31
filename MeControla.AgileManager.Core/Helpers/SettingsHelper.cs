using MeControla.AgileManager.Data.Dtos.Settings;
using MeControla.Core.Extensions;
using MeControla.Kernel.Settings;
using System.IO;

namespace MeControla.AgileManager.Core.Helpers
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
                Url = settingsManager.Data.Url.Base64Decode(),
                Username = settingsManager.Data.Username.Base64Decode(),
                Password = settingsManager.Data.Password.Base64Decode(),
                PersistFilter = settingsManager.Data.PersistFilter,
                SyncAllData = settingsManager.Data.SyncAllData,
                FilterData = settingsManager.Data.FilterData,
                Cache = settingsManager.Data.Cache,
            };
        }

        public AppSettingsDto Data { get; set; }

        public void Save()
        {
            settingsManager.Data.Url = Data.Url.Base64Encode();
            settingsManager.Data.Username = Data.Username.Base64Encode();
            settingsManager.Data.Password = Data.Password.Base64Encode();
            settingsManager.Data.PersistFilter = Data.PersistFilter;
            settingsManager.Data.SyncAllData = Data.SyncAllData;
            settingsManager.Data.FilterData = settingsManager.Data.PersistFilter
                                            ? Data.FilterData
                                            : null;
            settingsManager.Data.Cache = Data.Cache;
            settingsManager.SaveSettings();
        }

        public FileSystemWatcher CreateWatcher()
            => new()
            {
                Path = Directory.GetCurrentDirectory(),
                NotifyFilter = NotifyFilters.LastWrite,
                Filter = SETTINGS_FILENAME,
                EnableRaisingEvents = true
            };
    }
}