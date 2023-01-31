using MeControla.AgileManager.Core.Builders.Configurations;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Data.Dtos.Settings;
using MeControla.AgileManager.Integrations.Jira.Data.Configurations;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsHelper settingsHelper;

        public SettingsService(ISettingsHelper settingsHelper)
        {
            this.settingsHelper = settingsHelper;
        }

        public async Task<AppSettingsDto> LoadDataAsync(CancellationToken cancellationToken)
            => await Task.Run(() => settingsHelper.Data, cancellationToken);

        public async Task<bool> SaveAuthenticationAsync(string url, string username, string password, CancellationToken cancellationToken)
            => await SaveDataAsync(new AppSettingsDto
            {
                Url = url,
                Username = username,
                Password = password,
                FilterData = settingsHelper.Data.FilterData,
                PersistFilter = settingsHelper.Data.PersistFilter,
                SyncAllData = settingsHelper.Data.SyncAllData,
                Cache = settingsHelper.Data.Cache,
            }, cancellationToken);

        public async Task<bool> SavePreferencesAsync(bool persistFilter, bool syncAllData, int cache, CancellationToken cancellationToken)
            => await SaveDataAsync(new AppSettingsDto
            {
                Url = settingsHelper.Data.Url,
                Username = settingsHelper.Data.Username,
                Password = settingsHelper.Data.Password,
                FilterData = settingsHelper.Data.FilterData,
                PersistFilter = persistFilter,
                SyncAllData = syncAllData,
                Cache = cache,
            }, cancellationToken);

        public async Task<bool> SaveFilterDataAsync(AppFilterDto filterData, CancellationToken cancellationToken)
            => await SaveDataAsync(new AppSettingsDto
            {
                Url = settingsHelper.Data.Url,
                Username = settingsHelper.Data.Username,
                Password = settingsHelper.Data.Password,
                FilterData = filterData,
                PersistFilter = settingsHelper.Data.PersistFilter,
                SyncAllData = settingsHelper.Data.SyncAllData,
                Cache = settingsHelper.Data.Cache,
            }, cancellationToken);

        private async Task<bool> SaveDataAsync(AppSettingsDto appSettingsDto, CancellationToken cancellationToken)
            => await Task.Run(() =>
            {
                settingsHelper.Data = appSettingsDto;
                settingsHelper.Save();

                return true;
            }, cancellationToken);

        public async Task<bool> IsAuthenticationDataValidAsync(CancellationToken cancellationToken)
            => await Task.Run(() => !string.IsNullOrWhiteSpace(settingsHelper.Data.Url)
                                 && !string.IsNullOrWhiteSpace(settingsHelper.Data.Username)
                                 && !string.IsNullOrWhiteSpace(settingsHelper.Data.Password), cancellationToken);

        public JiraConfiguration GetJiraConfiguration()
            => JiraConfigurationBuilder.GetInstance()
                                       .SetUsername(settingsHelper.Data.Username)
                                       .SetPassword(settingsHelper.Data.Password)
                                       .SetUrl(settingsHelper.Data.Url)
                                       .SetCache(settingsHelper.Data.Cache)
                                       .ToBuild();

        public void RunCheckJiraConfigurationChanged(Action<JiraConfiguration> action)
        {
            var watcher = settingsHelper.CreateWatcher();
            watcher.Changed += (object sender, FileSystemEventArgs e) =>
            {
                if (e.ChangeType != WatcherChangeTypes.Changed)
                    return;

                action?.Invoke(GetJiraConfiguration());
            };
        }
    }
}