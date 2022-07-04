using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public interface ISynchronizerService
    {
        Task SynchronizeDataAsync(CancellationToken cancellationToken);
    }
}