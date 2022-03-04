using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Enums;
using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Dto
{
    public class GrowthCFDInfoDtoMock
    {
        public static IDictionary<GrowthTypes, IList<CFDInfoDto>> Create()
            => new Dictionary<GrowthTypes, IList<CFDInfoDto>>
            {
                { GrowthTypes.ToDo, CreateGrowthToDo() },
                { GrowthTypes.InProgress, CreateGrowthInProgress() }
            };

        private static IList<CFDInfoDto> CreateGrowthToDo()
            => new List<CFDInfoDto>
            {
                new CFDInfoDto { Date = new DateTime(2021, 06, 21), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 06, 28), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 07, 12), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 07, 19), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 07, 26), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 08, 09), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 08, 16), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 08, 23), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 08, 30), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 09, 06), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 09, 13), Value = 1M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 09, 20), Value = 2M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 09, 27), Value = 8M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 10, 04), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 10, 11), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 10, 18), Value = 8M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 10, 25), Value = 3M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 11, 01), Value = 1M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 11, 08), Value = 2M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 11, 15), Value = 7M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 11, 22), Value = 1M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 11, 29), Value = 9M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 12, 06), Value = 2M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 12, 13), Value = 2M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 12, 27), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2022, 01, 03), Value = 3M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2022, 01, 10), Value = 5M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2022, 01, 17), Value = 7M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2022, 01, 24), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2022, 01, 31), Value = 3M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2022, 02, 07), Value = 3M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2022, 02, 14), Value = 3M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2022, 02, 21), Value = 11M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2022, 02, 28), Value = 2M, Issues = null }
            };

        private static IList<CFDInfoDto> CreateGrowthInProgress()
            => new List<CFDInfoDto>
            {
                new CFDInfoDto { Date = new DateTime(2021, 06, 21), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 06, 28), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 07, 12), Value = 1M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 07, 19), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 07, 26), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 08, 09), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 08, 16), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 08, 23), Value = 1M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 08, 30), Value = 2M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 09, 06), Value = 5M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 09, 13), Value = 1M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 09, 20), Value = -2M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 09, 27), Value = -8M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 10, 04), Value = 13M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 10, 11), Value = 1M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 10, 18), Value = -6M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 10, 25), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 11, 01), Value = -1M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 11, 08), Value = 4M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 11, 15), Value = -6M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 11, 22), Value = 2M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 11, 29), Value = -7M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 12, 06), Value = -2M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 12, 13), Value = -2M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2021, 12, 27), Value = 10M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2022, 01, 03), Value = -1M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2022, 01, 10), Value = 2M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2022, 01, 17), Value = -3M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2022, 01, 24), Value = 1M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2022, 01, 31), Value = 10M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2022, 02, 07), Value = 1M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2022, 02, 14), Value = 0M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2022, 02, 21), Value = -5M, Issues = null },
                new CFDInfoDto { Date = new DateTime(2022, 02, 28), Value = -1M, Issues = null }
            };
    }
}