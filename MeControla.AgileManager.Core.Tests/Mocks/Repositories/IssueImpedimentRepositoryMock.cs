using MeControla.AgileManager.DataStorage.Repositories;

namespace MeControla.AgileManager.Core.Tests.Mocks.Repositories
{
    public class IssueImpedimentRepositoryMock : BaseRepository
    {
        public static IIssueImpedimentRepository Create()
            => new IssueImpedimentRepository(GetDbInstance());
    }
}