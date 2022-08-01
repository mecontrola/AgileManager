using Stefanini.ViaReport.DataStorage.Repositories;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Repositories
{
    public class QuarterRepositoryMock : BaseRepository
    {
        public static IQuarterRepository Create()
            => new QuarterRepository(GetDbInstance());
    }
}