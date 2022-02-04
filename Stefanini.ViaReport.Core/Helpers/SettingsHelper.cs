using Stefanini.Core.Extensions;
using Stefanini.Core.Settings;

namespace Stefanini.ViaReport.Core.Helpers
{
    public class SettingsHelper : ISettingsHelper
    {
        private const string SETTINGS_FILENAME = "usersettings.json";

        private readonly ISettingsManager<UserSettings> settingsManager;

        public SettingsHelper()
            : this(new SettingsManager<UserSettings>(SETTINGS_FILENAME))
        { }

        public SettingsHelper(ISettingsManager<UserSettings> settingsManager)
        {
            this.settingsManager = settingsManager;

            Data = new()
            {
                Username = settingsManager.Data.Username,
                Password = settingsManager.Data.Password.Base64Decode(),
            };
        }

        public UserSettings Data { get; set; }

        public void Save()
        {
            settingsManager.Data.Username = Data.Username;
            settingsManager.Data.Password = Data.Password.Base64Encode();
            settingsManager.SaveSettings();
        }
    }
}