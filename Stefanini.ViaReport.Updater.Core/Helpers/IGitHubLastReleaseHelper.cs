using Stefanini.ViaReport.Updater.Core.Data.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Updater.Core.Helpers
{
    public interface IGitHubLastReleaseHelper
    {
        Task<ReleaseDto> GetLastRelease(CancellationToken cancellationToken);
    }
}