using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Data.Dtos.Settings;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
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

        public async Task<bool> SaveAuthenticationAsync(string username, string password, CancellationToken cancellationToken)
            => await SaveDataAsync(new AppSettingsDto
            {
                Username = username,
                Password = password,
                FilterData = settingsHelper.Data.FilterData,
                PersistFilter = settingsHelper.Data.PersistFilter,
                SyncAllData = settingsHelper.Data.SyncAllData,
            }, cancellationToken);

        public async Task<bool> SavePreferencesAsync(bool persistFilter, bool syncAllData, CancellationToken cancellationToken)
            => await SaveDataAsync(new AppSettingsDto
            {
                Username = settingsHelper.Data.Username,
                Password = settingsHelper.Data.Password,
                FilterData = settingsHelper.Data.FilterData,
                PersistFilter = persistFilter,
                SyncAllData = syncAllData,
            }, cancellationToken);

        public async Task<bool> SaveFilterDataAsync(AppFilterDto filterData, CancellationToken cancellationToken)
            => await SaveDataAsync(new AppSettingsDto
            {
                Username = settingsHelper.Data.Username,
                Password = settingsHelper.Data.Password,
                FilterData = filterData,
                PersistFilter = settingsHelper.Data.PersistFilter,
                SyncAllData = settingsHelper.Data.SyncAllData,
            }, cancellationToken);

        private async Task<bool> SaveDataAsync(AppSettingsDto appSettingsDto, CancellationToken cancellationToken)
            => await Task.Run(() =>
            {
                settingsHelper.Data = appSettingsDto;
                settingsHelper.Save();

                return true;
            }, cancellationToken);

        public async Task<bool> IsAuthenticationDataValidAsync(CancellationToken cancellationToken)
            => await Task.Run(() => !string.IsNullOrWhiteSpace(settingsHelper.Data.Username)
                                 && !string.IsNullOrWhiteSpace(settingsHelper.Data.Password), cancellationToken);
    }
}