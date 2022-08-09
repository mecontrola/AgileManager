using MeControla.AgileManager.DataStorage.Repositories;

namespace MeControla.AgileManager.Core.Tests.Mocks.Repositories
{
    public class ProjectCategoryRepositoryMock : BaseRepository
    {
        public static IProjectCategoryRepository Create()
            => new ProjectCategoryRepository(GetDbInstance());
    }
}