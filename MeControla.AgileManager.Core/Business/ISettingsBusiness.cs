using MeControla.AgileManager.Data.Dtos.Settings;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Business
{
    public interface ISettingsBusiness
    {
        Task<AppSettingsDto> LoadDataAsync(CancellationToken cancellationToken);
        Task<bool> SaveAuthenticationAsync(string url, string username, string password, CancellationToken cancellationToken);
        Task<bool> SavePreferencesAsync(bool persistFilter, bool syncAllData, int cache, CancellationToken cancellationToken);
        Task<bool> SaveFilterDataAsync(AppFilterDto filterData, CancellationToken cancellationToken);
        Task<bool> IsAuthenticationDataValidAsync(CancellationToken cancellationToken);
    }
}