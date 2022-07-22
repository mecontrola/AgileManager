using NSubstitute;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Business;
using Stefanini.ViaReport.Core.Services;
using System.Threading;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Business
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