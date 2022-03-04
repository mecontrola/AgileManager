using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Tests.TestUtils.Helpers;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Dto
{
    public class StatusDtoMock
    {
        private const string SEARCH_RESULT_FILE_NAME = "status.get.all.json";

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

        public static StatusDto[] CreateByJson()
            => ApiUtilMockHelper.LoadJsonMock<StatusDto[]>(SEARCH_RESULT_FILE_NAME);
    }
}