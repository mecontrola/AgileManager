using Stefanini.ViaReport.DataStorage.Repositories;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Repositories
{
    public class StatusCategoryRepositoryMock : BaseRepository
    {
        public static IStatusCategoryRepository Create()
            => new StatusCategoryRepository(GetDbInstance());
    }
}