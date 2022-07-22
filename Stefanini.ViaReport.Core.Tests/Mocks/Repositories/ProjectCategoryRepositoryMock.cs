using Stefanini.ViaReport.DataStorage.Repositories;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Repositories
{
    public class ProjectCategoryRepositoryMock : BaseRepository
    {
        public static IProjectCategoryRepository Create()
            => new ProjectCategoryRepository(GetDbInstance());
    }
}