using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Business
{
    public interface ISynchronizerBusiness
    {
        Task SynchronizeDataAsync(CancellationToken cancellationToken);
    }
}