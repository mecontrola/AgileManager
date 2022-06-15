using Stefanini.ViaReport.DataStorage.Repositories;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Repositories
{
    public class IssueTypeRepositoryMock : BaseRepository
    {
        public static IIssueTypeRepository Create()
            => new IssueTypeRepository(GetDbInstance());
    }
}