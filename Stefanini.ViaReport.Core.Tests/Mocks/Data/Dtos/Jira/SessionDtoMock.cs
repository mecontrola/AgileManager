using Stefanini.ViaReport.Core.Tests.TestUtils.Helpers;
using Stefanini.ViaReport.Data.Dtos.Jira;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira
{
    public class SessionDtoMock
    {
        private const string SESSION_RESULT_FILE_NAME = "session.get.json";

        public static SessionDto CreateByJson()
            => ApiUtilMockHelper.LoadJsonMock<SessionDto>(SESSION_RESULT_FILE_NAME);
    }
}