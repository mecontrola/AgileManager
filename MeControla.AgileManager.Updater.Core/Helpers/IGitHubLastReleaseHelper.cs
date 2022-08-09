using MeControla.AgileManager.Updater.Core.Data.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Updater.Core.Helpers
{
    public interface IGitHubLastReleaseHelper
    {
        Task<ReleaseDto> GetLastRelease(CancellationToken cancellationToken);
    }
}