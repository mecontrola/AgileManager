using MeControla.AgileManager.DataStorage.Repositories;

namespace MeControla.AgileManager.Core.Tests.Mocks.Repositories
{
    public class QuarterRepositoryMock : BaseRepository
    {
        public static IQuarterRepository Create()
            => new QuarterRepository(GetDbInstance());
    }
}