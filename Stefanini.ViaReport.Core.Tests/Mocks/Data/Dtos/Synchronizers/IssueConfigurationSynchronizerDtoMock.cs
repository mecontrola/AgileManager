using Stefanini.ViaReport.Data.Dtos.Synchronizers;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Synchronizers
{
    public class IssueConfigurationSynchronizerDtoMock
    {
        public static IssueConfigurationSynchronizerDto Create()
            => new()
            {
                Username = DataMock.VALUE_USERNAME,
                Password = DataMock.VALUE_PASSWORD,
                Projects = DataMock.PROJECTS,
                SyncAllData = false,
            };

        public static IssueConfigurationSynchronizerDto CreateWithSyncAllData()
            => new()
            {
                Username = DataMock.VALUE_USERNAME,
                Password = DataMock.VALUE_PASSWORD,
                Projects = DataMock.PROJECTS,
                SyncAllData = true,
            };
    }
}