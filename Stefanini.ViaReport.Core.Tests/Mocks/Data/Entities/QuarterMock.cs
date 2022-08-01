using Stefanini.ViaReport.Data.Entities;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities
{
    public class QuarterMock
    {
        public static Quarter CreateQ12000()
            => new()
            {
                Id = DataMock.INT_ID_1,
                Name = DataMock.TEXT_QUARTER_1_2000
            };

        public static Quarter CreateQ22000()
            => new()
            {
                Id = DataMock.INT_ID_2,
                Name = DataMock.TEXT_QUARTER_2_2000
            };

        public static Quarter CreateQ32000()
            => new()
            {
                Id = DataMock.INT_ID_3,
                Name = DataMock.TEXT_QUARTER_3_2000
            };

        public static Quarter CreateQ42000()
            => new()
            {
                Id = DataMock.INT_ID_4,
                Name = DataMock.TEXT_QUARTER_4_2000
            };

        public static IList<Quarter> CreateList()
            => new List<Quarter>
            {
                CreateQ42000(),
                CreateQ32000(),
                CreateQ22000(),
                CreateQ12000()
            };
    }
}