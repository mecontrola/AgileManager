using MeControla.AgileManager.Data.Entities;
using System;

namespace MeControla.AgileManager.Core.Tests.Mocks.Data.Entities
{
    public class IssueStatusHistoryMock
    {
        public static IssueStatusHistory Create()
            => new()
            {
                DateTime = DataMock.DATETIME_FIRST_DAY_YEAR,
                IssueId = DataMock.ID_ISSUE,
                FromStatusId = DataMock.INT_STATUS_PARA_DESENVOLVIMENTO,
                ToStatusId = DataMock.INT_STATUS_EM_DESENVOLVIMENTO
            };

        public static IssueStatusHistory CreateByDataBase()
            => new()
            {
                DateTime = DataMock.DATETIME_FIRST_DAY_YEAR,
                ToStatusId = DataMock.INT_ID_1,
                ToStatus = StatusMock.CreateDone(),
            };
    }
}