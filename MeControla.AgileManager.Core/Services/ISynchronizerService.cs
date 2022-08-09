using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public interface ISynchronizerService
    {
        Task SynchronizeDataAsync(CancellationToken cancellationToken);
    }
}