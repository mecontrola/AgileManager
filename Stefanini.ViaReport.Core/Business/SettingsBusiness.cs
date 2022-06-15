using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Data.Dtos.Settings;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
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

        public async Task<bool> SavePreferencesAsync(bool persistFilter, CancellationToken cancellationToken)
            => await settingsService.SavePreferencesAsync(persistFilter, cancellationToken);

        public async Task<bool> SaveAuthenticationAsync(string username, string password, CancellationToken cancellationToken)
            => await settingsService.SaveAuthenticationAsync(username, password, cancellationToken);

        public async Task<bool> SaveFilterDataAsync(AppFilterDto filterData, CancellationToken cancellationToken)
            => await settingsService.SaveFilterDataAsync(filterData, cancellationToken);

        public async Task<bool> IsAuthenticationDataValidAsync(CancellationToken cancellationToken)
            => await settingsService.IsAuthenticationDataValidAsync(cancellationToken);
    }
}