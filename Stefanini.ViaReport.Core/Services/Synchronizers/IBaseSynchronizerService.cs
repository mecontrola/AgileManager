using Stefanini.ViaReport.Data.Dtos.Synchronizers;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services.Synchronizers
{
    public interface IBaseSynchronizerService
    {
        Task SynchronizeData(ConfigurationSynchronizerDto configurationSynchronizerDto, CancellationToken cancellationToken);
    }
}