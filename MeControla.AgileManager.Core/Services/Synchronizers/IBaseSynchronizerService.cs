using MeControla.AgileManager.Data.Dtos.Synchronizers;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services.Synchronizers
{
    public interface IBaseSynchronizerService
    {
        Task SynchronizeData(ConfigurationSynchronizerDto configurationSynchronizerDto, CancellationToken cancellationToken);
    }
}