using MeControla.AgileManager.DataStorage.Repositories;

namespace MeControla.AgileManager.Core.Tests.Mocks.Repositories
{
    public class IssueEpicRepositoryMock : BaseRepository
    {
        public static IIssueEpicRepository Create()
            => new IssueEpicRepository(GetDbInstance());
    }
}