using Stefanini.ViaReport.Core.Data.Dto.Jira;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Dto
{
    public class StatusDtoMock
    {
        public static StatusDto CreateBacklog()
            => new()
            {
                Name = DataMock.ISSUE_STATUS_1
            };

        public static StatusDto CreateReplanishment()
            => new()
            {
                Name = DataMock.ISSUE_STATUS_2
            };
    }
}