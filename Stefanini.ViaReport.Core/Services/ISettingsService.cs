using Stefanini.ViaReport.Data.Dtos.Settings;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public interface ISettingsService
    {
        Task<AppSettingsDto> LoadDataAsync(CancellationToken cancellationToken);
        Task<bool> SavePreferencesAsync(bool persistFilter, CancellationToken cancellationToken);
        Task<bool> SaveAuthenticationAsync(string username, string password, CancellationToken cancellationToken);
        Task<bool> SaveFilterDataAsync(AppFilterDto filterData, CancellationToken cancellationToken);
        Task<bool> IsAuthenticationDataValidAsync(CancellationToken cancellationToken);
    }
}