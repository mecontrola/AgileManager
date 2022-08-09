using MeControla.AgileManager.DataStorage.Repositories;

namespace MeControla.AgileManager.Core.Tests.Mocks.Repositories
{
    public class IssueStatusHistoryRepositoryMock : BaseRepository
    {
        public static IIssueStatusHistoryRepository Create()
            => new IssueStatusHistoryRepository(GetDbInstance());
    }
}