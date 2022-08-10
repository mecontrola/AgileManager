using MeControla.AgileManager.Core.Business;
using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.TestingTools;
using NSubstitute;
using System.Threading;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Business
{
    public class SynchronizerBusinessTests : BaseAsyncMethods
    {
        private readonly ISynchronizerService synchronizerService;

        private readonly ISynchronizerBusiness synchronizerBusiness;

        public SynchronizerBusinessTests()
        {
            synchronizerService = Substitute.For<ISynchronizerService>();

            synchronizerBusiness = new SynchronizerBusiness(synchronizerService);
        }

        [Fact(DisplayName = "[SynchronizerBusiness.SynchronizeDataAsync] Deve executar a chamada do service para realizar a sincronização dos dados.")]
        public async void DeveRetornarListaQuartersDisponiveis()
        {
            await synchronizerBusiness.SynchronizeDataAsync(GetCancellationToken());

            await synchronizerService.Received()
                                     .SynchronizeDataAsync(Arg.Any<CancellationToken>());
        }
    }
}