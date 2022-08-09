using MeControla.AgileManager.DataStorage.Repositories;

namespace MeControla.AgileManager.Core.Tests.Mocks.Repositories
{
    public class StatusCategoryRepositoryMock : BaseRepository
    {
        public static IStatusCategoryRepository Create()
            => new StatusCategoryRepository(GetDbInstance());
    }
}