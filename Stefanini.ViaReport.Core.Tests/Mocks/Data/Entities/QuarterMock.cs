using Stefanini.ViaReport.Data.Entities;
using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities
{
    public class QuarterMock
    {
        public static Quarter CreateQ41999()
            => new()
            {
                Id = DataMock.INT_ID_2,
                Uuid = Guid.Parse("AFE641A1-5447-45CF-9B21-09402E301037"),
                Name = DataMock.TEXT_QUARTER_4_1999
            };

        public static Quarter CreateQ12000()
            => new()
            {
                Id = DataMock.INT_ID_3,
                Uuid = Guid.Parse("C9AC28DB-1B89-4D7C-BEAB-12A39C3304A3"),
                Name = DataMock.TEXT_QUARTER_1_2000
            };

        public static Quarter CreateQ22000()
            => new()
            {
                Id = DataMock.INT_ID_4,
                Uuid = Guid.Parse("C6E9B8F7-3137-4B6A-8DDE-A431D5B3A3EE"),
                Name = DataMock.TEXT_QUARTER_2_2000
            };

        public static Quarter CreateQ32000()
            => new()
            {
                Id = DataMock.INT_ID_5,
                Uuid = Guid.Parse("CB71694D-B23D-4A95-B9A1-89BA454E2820"),
                Name = DataMock.TEXT_QUARTER_3_2000
            };

        public static Quarter CreateQ42000()
            => new()
            {
                Id = DataMock.INT_ID_6,
                Uuid = Guid.Parse("C48AD8A0-3F4E-4292-96C1-A7920E8A9821"),
                Name = DataMock.TEXT_QUARTER_4_2000
            };

        public static IList<Quarter> CreateList()
            => new List<Quarter>
            {
                CreateQ42000(),
                CreateQ32000(),
                CreateQ22000(),
                CreateQ12000(),
                CreateQ41999(),
            };
    }
}