using MeControla.AgileManager.Data.Entities;

namespace MeControla.AgileManager.Core.Tests.Mocks.Data.Entities
{
    public class IssueEpicMock
    {
        public static IssueEpic Create()
            => new()
            {
                Id = DataMock.INT_ID_1,
                Progress = DataMock.VALUE_DEFAULT_9,
                QuarterId = DataMock.INT_ID_1,
                IssueId = DataMock.ID_ISSUE,
            };

        public static IssueEpic CreateByDataBase()
            => new()
            {
                Progress = DataMock.VALUE_DEFAULT_50,
                QuarterId = DataMock.INT_ID_3,
                IssueId = DataMock.INT_ID_3,
                Issue = IssueMock.CreateAllFilledEpic()
            };
    }
}