using MeControla.AgileManager.Updater.Core.Data.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Updater.Core.Integrations.Github.Repos
{
    public interface IReleasesLastest
    {
        Task<ReleaseDto> Execute(CancellationToken cancellationToken);
    }
}