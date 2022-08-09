using MeControla.AgileManager.DataStorage.Repositories;

namespace MeControla.AgileManager.Core.Tests.Mocks.Repositories
{
    public class ProjectRepositoryMock : BaseRepository
    {
        public static IProjectRepository Create()
            => new ProjectRepository(GetDbInstance());
    }
}