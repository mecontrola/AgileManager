using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Updater.Core.Helpers
{
    public interface IStep01Helper
    {
        Task Run(CancellationToken cancellationToken);
    }
}