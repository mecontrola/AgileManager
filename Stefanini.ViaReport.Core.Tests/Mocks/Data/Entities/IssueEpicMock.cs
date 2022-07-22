using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities
{
    public class IssueEpicMock
    {
        public static IssueEpic Create()
            => new()
            {
                Id = DataMock.INT_ID_1,
                Progress = DataMock.VALUE_DEFAULT_9,
                Quarter = DataMock.TEXT_QUARTER_1_2000,
                IssueId = DataMock.ID_ISSUE,
            };

        public static IssueEpic CreateByDataBase()
            => new()
            {
                Progress = DataMock.VALUE_DEFAULT_50,
                Quarter = DataMock.TEXT_QUARTER_1_2000,
                IssueId = DataMock.INT_ID_3,
                Issue = IssueMock.CreateAllFilledEpic()
            };
    }
}