using MeControla.AgileManager.Core.Tests.TestUtils.Helpers;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;

namespace MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira
{
    public class SessionDtoMock
    {
        private const string SESSION_RESULT_FILE_NAME = "session.get.json";

        public static SessionDto CreateByJson()
            => ApiUtilMockHelper.LoadJsonMock<SessionDto>(SESSION_RESULT_FILE_NAME);
    }
}