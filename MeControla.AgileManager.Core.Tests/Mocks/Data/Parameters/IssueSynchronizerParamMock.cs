using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Entities;
using MeControla.AgileManager.Data.Parameters;

namespace MeControla.AgileManager.Core.Tests.Mocks.Data.Parameters
{
    public class IssueSynchronizerParamMock
    {
        public static IssueSynchronizerParam Create()
            => new()
            {
                IssueDto = IssueDtoMock.CreateAllFilledStory(),
                ProjectId = DataMock.INT_ID_1,
                Statuses = StatusMock.CreateDictionary(),
                IssueTypes = IssueTypeMock.CreateDictionary()
            };

        public static IssueSynchronizerParam CreateEpic()
            => new()
            {
                IssueDto = IssueDtoMock.CreateAllFilledEpic(),
                ProjectId = DataMock.INT_ID_1,
                Statuses = StatusMock.CreateDictionary(),
                IssueTypes = IssueTypeMock.CreateDictionary()
            };
    }
}