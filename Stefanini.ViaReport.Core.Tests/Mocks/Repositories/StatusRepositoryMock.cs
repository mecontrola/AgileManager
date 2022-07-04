using Stefanini.ViaReport.DataStorage.Repositories;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Repositories
{
    public class StatusRepositoryMock : BaseRepository
    {
        public static IStatusRepository Create()
            => new StatusRepository(GetDbInstance());
    }
}