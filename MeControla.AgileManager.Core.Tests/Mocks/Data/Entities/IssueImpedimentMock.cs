using MeControla.AgileManager.Data.Entities;
using System;

namespace MeControla.AgileManager.Core.Tests.Mocks.Data.Entities
{
    public class IssueImpedimentMock
    {
        public static IssueImpediment Create()
            => new()
            {
                Start = DataMock.DATETIME_QUARTER_1_2000,
                End = DataMock.DATETIME_QUARTER_2_2000,
                IssueId = DataMock.ID_ISSUE,
            };

        public static IssueImpediment CreateByDataBase()
            => new()
            {
                Start = DateTime.Parse("2021-09-06 16:52:49.375"),
                IssueId = DataMock.INT_ID_1,
            };
    }
}