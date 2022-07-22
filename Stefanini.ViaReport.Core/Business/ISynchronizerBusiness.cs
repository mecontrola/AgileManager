using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public interface ISynchronizerBusiness
    {
        Task SynchronizeDataAsync(CancellationToken cancellationToken);
    }
}