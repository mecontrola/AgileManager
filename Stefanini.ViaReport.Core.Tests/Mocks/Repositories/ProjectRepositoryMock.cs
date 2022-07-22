using Stefanini.ViaReport.DataStorage.Repositories;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Repositories
{
    public class ProjectRepositoryMock : BaseRepository
    {
        public static IProjectRepository Create()
            => new ProjectRepository(GetDbInstance());
    }
}