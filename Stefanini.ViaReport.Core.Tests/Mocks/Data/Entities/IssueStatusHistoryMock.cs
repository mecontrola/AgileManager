using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities
{
    public class IssueStatusHistoryMock
    {
        public static IssueStatusHistory Create()
            => new()
            {
                DateTime = DataMock.DATETIME_FIRST_DAY_YEAR,
                IssueId = DataMock.ID_ISSUE,
                StatusId = DataMock.INT_STATUS_EM_DESENVOLVIMENTO
            };
    }
}