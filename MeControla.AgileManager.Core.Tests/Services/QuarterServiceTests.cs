using FluentAssertions;
using MeControla.AgileManager.TestingTools;
using MeControla.AgileManager.Core.Mappers.EntityToDto;
using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos;
using MeControla.AgileManager.Core.Tests.Mocks.Helpers;
using MeControla.AgileManager.Core.Tests.Mocks.Repositories;
using MeControla.AgileManager.DataStorage.Repositories;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Services
{
    public class QuarterServiceTests : BaseAsyncMethods
    {
        private readonly IQuarterRepository quarterRepository;

        private readonly IQuarterService quarterService;

        public QuarterServiceTests()
        {
            quarterRepository = QuarterRepositoryMock.Create();

            quarterService = new QuarterService(quarterRepository, new QuarterEntityToDtoMapper());
        }

        [Fact(DisplayName = "[QuarterService.LoadAllAsync] Deve retornar a lista dos quarters habilitados a partir do dia de hoje.")]
        public async void DeveRetornarListaQuarters()
        {
            var actual = await quarterService.LoadAllAsync(GetCancellationToken());
            var expected = QuarterDtoMock.CreateList();

            actual.Should().BeEquivalentTo(expected);
        }
    }
}