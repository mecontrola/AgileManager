using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Tests.TestUtils.Helpers;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Dto
{
    public class SessionDtoMock
    {
        private const string SESSION_RESULT_FILE_NAME = "session.get.json";

        public static SessionDto CreateByJson()
            => ApiUtilMockHelper.LoadJsonMock<SessionDto>(SESSION_RESULT_FILE_NAME);
    }
}