using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Updater.Core.Helpers
{
    public interface IStep01Helper
    {
        Task Run(CancellationToken cancellationToken);
    }
}