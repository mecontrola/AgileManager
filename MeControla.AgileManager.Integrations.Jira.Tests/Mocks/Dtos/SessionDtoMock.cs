using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.AgileManager.Integrations.Jira.Tests.TestUtils.Helpers;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Mocks.Data.Dtos
{
    public class SessionDtoMock
    {
        private const string SESSION_RESULT_FILE_NAME = "session.get.json";

        public static SessionDto CreateByJson()
            => ApiUtilMockHelper.LoadJsonMock<SessionDto>(SESSION_RESULT_FILE_NAME);
    }
}