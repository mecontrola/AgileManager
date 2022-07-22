using Stefanini.ViaReport.Data.Dtos.Settings;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public interface ISettingsBusiness
    {
        Task<AppSettingsDto> LoadDataAsync(CancellationToken cancellationToken);
        Task<bool> SaveAuthenticationAsync(string username, string password, CancellationToken cancellationToken);
        Task<bool> SavePreferencesAsync(bool persistFilter, bool syncAllData, CancellationToken cancellationToken);
        Task<bool> SaveFilterDataAsync(AppFilterDto filterData, CancellationToken cancellationToken);
        Task<bool> IsAuthenticationDataValidAsync(CancellationToken cancellationToken);
    }
}