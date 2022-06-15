using Stefanini.ViaReport.Data.Dtos;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos
{
    public class QuarterDtoMock
    {
        public static QuarterDto CreateQ12000()
            => new()
            {
                Id = DataMock.INT_ID_1,
                Name = DataMock.TEXT_QUARTER_1_2000
            };

        public static QuarterDto CreateQ22000()
            => new()
            {
                Id = DataMock.INT_ID_2,
                Name = DataMock.TEXT_QUARTER_2_2000
            };

        public static QuarterDto CreateQ32000()
            => new()
            {
                Id = DataMock.INT_ID_3,
                Name = DataMock.TEXT_QUARTER_3_2000
            };

        public static QuarterDto CreateQ42000()
            => new()
            {
                Id = DataMock.INT_ID_4,
                Name = DataMock.TEXT_QUARTER_4_2000
            };

        public static IList<QuarterDto> CreateList()
            => new List<QuarterDto>
            {
                CreateQ42000(),
                CreateQ32000(),
                CreateQ22000(),
                CreateQ12000()
            };
    }
}