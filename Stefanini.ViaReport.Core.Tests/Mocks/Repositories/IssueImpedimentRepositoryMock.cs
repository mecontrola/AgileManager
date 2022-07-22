using Stefanini.ViaReport.DataStorage.Repositories;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Repositories
{
    public class IssueImpedimentRepositoryMock : BaseRepository
    {
        public static IIssueImpedimentRepository Create()
            => new IssueImpedimentRepository(GetDbInstance());
    }
}