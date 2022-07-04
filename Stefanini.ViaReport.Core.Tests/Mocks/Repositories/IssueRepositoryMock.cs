using Stefanini.ViaReport.DataStorage.Repositories;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Repositories
{
    public class IssueRepositoryMock : BaseRepository
    {
        public static IIssueRepository Create()
            => new IssueRepository(GetDbInstance());
    }
}