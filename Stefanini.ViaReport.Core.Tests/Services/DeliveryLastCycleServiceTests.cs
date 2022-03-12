using FluentAssertions;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Dto;
using Stefanini.ViaReport.Core.Tests.Mocks.Services;
using System.Threading;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class DeliveryLastCycleServiceTests
    {
        private readonly IDeliveryLastCycleService service;

        private readonly CancellationTokenSource cancellationTokenSource;

        public DeliveryLastCycleServiceTests()
        {
            var issuesResolvedInDateRangeService = IssuesResolvedInDateRangeServiceMock.Create();
            var statusDoneService = StatusDoneServiceMock.Create();
            var statusInProgressService = StatusInProgressServiceMock.Create();
            var issueGet = IssueGetMock.Create();

            service = new DeliveryLastCycleService(issuesResolvedInDateRangeService,
                                                   statusDoneService,
                                                   statusInProgressService,
                                                   new BusinessDayHelper(),
                                                   new RecoverDateTimeFirstStatusMatchBacklogHelper(),
                                                   issueGet);

            cancellationTokenSource = new CancellationTokenSource();
        }

        [Fact(DisplayName = "[DeliveryLastCycleService.GetData] Deve gerar os dados de Throughput e Lead Time referente ao projeto e intervalo de tempo informado.")]
        public async void DeveGerarDadosThroughputLeadtime()
        {
            var expected = DeliveryLastCycleDtoMock.Create();
            var actual = await service.GetData(DataMock.VALUE_USERNAME,
                                               DataMock.VALUE_PASSWORD,
                                               DataMock.TEXT_SEARCH_PROJECT,
                                               DataMock.DATETIME_START_CYCLE,
                                               DataMock.DATETIME_END_CYCLE,
                                               cancellationTokenSource.Token);

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}