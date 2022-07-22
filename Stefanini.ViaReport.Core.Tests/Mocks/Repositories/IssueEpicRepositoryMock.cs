using Stefanini.ViaReport.DataStorage.Repositories;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Repositories
{
    public class IssueEpicRepositoryMock : BaseRepository
    {
        public static IIssueEpicRepository Create()
            => new IssueEpicRepository(GetDbInstance());
    }
}