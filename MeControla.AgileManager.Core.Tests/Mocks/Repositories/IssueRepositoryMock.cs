using MeControla.AgileManager.DataStorage.Repositories;

namespace MeControla.AgileManager.Core.Tests.Mocks.Repositories
{
    public class IssueRepositoryMock : BaseRepository
    {
        public static IIssueRepository Create()
            => new IssueRepository(GetDbInstance());
    }
}