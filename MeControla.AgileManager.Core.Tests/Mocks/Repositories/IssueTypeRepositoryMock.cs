using MeControla.AgileManager.DataStorage.Repositories;

namespace MeControla.AgileManager.Core.Tests.Mocks.Repositories
{
    public class IssueTypeRepositoryMock : BaseRepository
    {
        public static IIssueTypeRepository Create()
            => new IssueTypeRepository(GetDbInstance());
    }
}