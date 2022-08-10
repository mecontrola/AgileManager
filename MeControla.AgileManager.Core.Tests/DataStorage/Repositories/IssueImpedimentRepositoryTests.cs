using FluentAssertions;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Entities;
using MeControla.AgileManager.Core.Tests.Mocks.Repositories;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.AgileManager.TestingTools;
using System;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.DataStorage.Repositories
{
    public class IssueImpedimentRepositoryTests : BaseAsyncMethods
    {
        private readonly IIssueImpedimentRepository repository;

        public IssueImpedimentRepositoryTests()
        {
            repository = IssueImpedimentRepositoryMock.Create();
        }

        [Fact(DisplayName = "[IssueImpedimentRepository.RetrieveByIssueAndStartAsync] Deve retornar o impedimento cadastrado com a data inicial informada.")]
        public async void DeveRetornarImpedimentoComDataInicialDaIssueInformada()
        {
            var expected = IssueImpedimentMock.CreateByDataBase();
            var actual = await repository.RetrieveByIssueAndStartAsync(expected.IssueId, expected.Start, GetCancellationToken());

            actual.Should().NotBeNull();
            actual.Start.Should().Be(expected.Start);
            actual.End.Should().Be(expected.End);
            actual.IssueId.Should().Be(expected.IssueId);
        }

        [Fact(DisplayName = "[IssueImpedimentRepository.RetrieveByDateRangeAsync] Deve retornar a lista de impedimentos de uma issue de acordo com o período informado.")]
        public async void DeveRetornarListaImpedimentoIssueDurantePeriodoInformado()
        {
            var expected = IssueImpedimentMock.CreateByDataBase();
            var actual = await repository.RetrieveByDateRangeAsync(DataMock.INT_ID_1, new DateTime(2021, 8, 1), new DateTime(2021, 10, 1), GetCancellationToken());

            actual.Should().HaveCount(2);
            actual[1].Should().NotBeNull();
            actual[1].Start.Should().Be(expected.Start);
            actual[1].End.Should().Be(expected.End);
            actual[1].IssueId.Should().Be(expected.IssueId);
        }
    }
}