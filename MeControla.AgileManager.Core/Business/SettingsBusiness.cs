using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Data.Dtos.Settings;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Business
{
    public class SettingsBusiness : ISettingsBusiness
    {
        private readonly ISettingsService settingsService;

        public SettingsBusiness(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        public async Task<AppSettingsDto> LoadDataAsync(CancellationToken cancellationToken)
            => await settingsService.LoadDataAsync(cancellationToken);

        public async Task<bool> SavePreferencesAsync(bool persistFilter, bool syncAllData, int cache, CancellationToken cancellationToken)
            => await settingsService.SavePreferencesAsync(persistFilter, syncAllData, cache, cancellationToken);

        public async Task<bool> SaveAuthenticationAsync(string url, string username, string password, CancellationToken cancellationToken)
            => await settingsService.SaveAuthenticationAsync(url, username, password, cancellationToken);

        public async Task<bool> SaveFilterDataAsync(AppFilterDto filterData, CancellationToken cancellationToken)
            => await settingsService.SaveFilterDataAsync(filterData, cancellationToken);

        public async Task<bool> IsAuthenticationDataValidAsync(CancellationToken cancellationToken)
            => await settingsService.IsAuthenticationDataValidAsync(cancellationToken);
    }
}