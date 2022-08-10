using MeControla.AgileManager.Core.Services;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Business
{
    public class SynchronizerBusiness : ISynchronizerBusiness
    {
        private readonly ISynchronizerService synchronizerService;

        public SynchronizerBusiness(ISynchronizerService synchronizerService)
        {
            this.synchronizerService = synchronizerService;
        }

        public async Task SynchronizeDataAsync(CancellationToken cancellationToken)
            => await synchronizerService.SynchronizeDataAsync(cancellationToken);
    }
}