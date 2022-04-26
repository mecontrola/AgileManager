using Stefanini.ViaReport.Updater.Core.Data.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Updater.Core.Integrations.Github.Repos
{
    public interface IReleasesLastest
    {
        Task<ReleaseDto> Execute(CancellationToken cancellationToken);
    }
}