using FluentAssertions;
using MeControla.AgileManager.TestingTools;
using MeControla.AgileManager.Core.Mappers.EntityToDto;
using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos;
using MeControla.AgileManager.Core.Tests.Mocks.Repositories;
using MeControla.AgileManager.Data.Enums;
using System;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Services
{
    public class DownstreamIndicatorsServiceTests : BaseAsyncMethods
    {
        private static readonly int DOWNSTREAM_INDICATOR_TYPES_TOTAL = Enum.GetNames(typeof(DownstreamIndicatorTypes)).Length;

        private readonly IDownstreamIndicatorsService service;

        public DownstreamIndicatorsServiceTests()
        {
            var issueRepository = IssueRepositoryMock.Create();
            var issueEntityToDtoMapper = new IssueEntityToDtoMapper();

            service = new DownstreamIndicatorsService(issueRepository, issueEntityToDtoMapper);
        }

        [Fact(DisplayName = "[DownstreamIndicatorsService.GetData] Deve gerar o relatório de bugs e débitos técnicos que foram tratados no período informado.")]
        public async void DeveGerarRelatorioBugsDebitosUltimoCiclo()
        {
            var expected = DownstreamIndicatorDtoMock.Create();
            var actual = await service.GetData(DataMock.INT_ID_1, DataMock.DATETIME_LAST_CYCLE_INIT, DataMock.DATETIME_LAST_CYCLE_END, GetCancellationToken());

            actual.Should().NotBeNull();
            actual.Bugs.Keys.Should().HaveCount(DOWNSTREAM_INDICATOR_TYPES_TOTAL);
            actual.TechnicalDebit.Keys.Should().HaveCount(DOWNSTREAM_INDICATOR_TYPES_TOTAL);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}