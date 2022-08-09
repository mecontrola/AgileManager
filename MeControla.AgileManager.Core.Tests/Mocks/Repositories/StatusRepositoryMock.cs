using MeControla.AgileManager.DataStorage.Repositories;

namespace MeControla.AgileManager.Core.Tests.Mocks.Repositories
{
    public class StatusRepositoryMock : BaseRepository
    {
        public static IStatusRepository Create()
            => new StatusRepository(GetDbInstance());
    }
}