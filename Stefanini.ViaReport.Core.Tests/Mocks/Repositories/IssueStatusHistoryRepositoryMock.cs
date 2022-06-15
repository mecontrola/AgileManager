using Stefanini.ViaReport.DataStorage.Repositories;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Repositories
{
    public class IssueStatusHistoryRepositoryMock : BaseRepository
    {
        public static IIssueStatusHistoryRepository Create()
            => new IssueStatusHistoryRepository(GetDbInstance());
    }
}