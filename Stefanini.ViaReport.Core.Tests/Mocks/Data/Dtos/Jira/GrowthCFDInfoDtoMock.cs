using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Enums;
using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira
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
                new CFDInfoDto { Date = new DateTime(2021, 06, 21), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 06, 28), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 07, 12), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 07, 19), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 07, 26), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 08, 09), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 08, 16), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 08, 23), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 08, 30), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 09, 06), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 09, 13), Value = 1M },
                new CFDInfoDto { Date = new DateTime(2021, 09, 20), Value = 2M },
                new CFDInfoDto { Date = new DateTime(2021, 09, 27), Value = 8M },
                new CFDInfoDto { Date = new DateTime(2021, 10, 04), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 10, 11), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 10, 18), Value = 8M },
                new CFDInfoDto { Date = new DateTime(2021, 10, 25), Value = 3M },
                new CFDInfoDto { Date = new DateTime(2021, 11, 01), Value = 1M },
                new CFDInfoDto { Date = new DateTime(2021, 11, 08), Value = 2M },
                new CFDInfoDto { Date = new DateTime(2021, 11, 15), Value = 7M },
                new CFDInfoDto { Date = new DateTime(2021, 11, 22), Value = 1M },
                new CFDInfoDto { Date = new DateTime(2021, 11, 29), Value = 9M },
                new CFDInfoDto { Date = new DateTime(2021, 12, 06), Value = 2M },
                new CFDInfoDto { Date = new DateTime(2021, 12, 13), Value = 2M },
                new CFDInfoDto { Date = new DateTime(2021, 12, 27), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2022, 01, 03), Value = 3M },
                new CFDInfoDto { Date = new DateTime(2022, 01, 10), Value = 5M },
                new CFDInfoDto { Date = new DateTime(2022, 01, 17), Value = 7M },
                new CFDInfoDto { Date = new DateTime(2022, 01, 24), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2022, 01, 31), Value = 3M },
                new CFDInfoDto { Date = new DateTime(2022, 02, 07), Value = 3M },
                new CFDInfoDto { Date = new DateTime(2022, 02, 14), Value = 3M },
                new CFDInfoDto { Date = new DateTime(2022, 02, 21), Value = 11M },
                new CFDInfoDto { Date = new DateTime(2022, 02, 28), Value = 2M }
            };

        private static IList<CFDInfoDto> CreateGrowthInProgress()
            => new List<CFDInfoDto>
            {
                new CFDInfoDto { Date = new DateTime(2021, 06, 21), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 06, 28), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 07, 12), Value = 1M },
                new CFDInfoDto { Date = new DateTime(2021, 07, 19), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 07, 26), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 08, 09), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 08, 16), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 08, 23), Value = 1M },
                new CFDInfoDto { Date = new DateTime(2021, 08, 30), Value = 2M },
                new CFDInfoDto { Date = new DateTime(2021, 09, 06), Value = 5M },
                new CFDInfoDto { Date = new DateTime(2021, 09, 13), Value = 1M },
                new CFDInfoDto { Date = new DateTime(2021, 09, 20), Value = -2M },
                new CFDInfoDto { Date = new DateTime(2021, 09, 27), Value = -8M },
                new CFDInfoDto { Date = new DateTime(2021, 10, 04), Value = 13M },
                new CFDInfoDto { Date = new DateTime(2021, 10, 11), Value = 1M },
                new CFDInfoDto { Date = new DateTime(2021, 10, 18), Value = -6M },
                new CFDInfoDto { Date = new DateTime(2021, 10, 25), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2021, 11, 01), Value = -1M },
                new CFDInfoDto { Date = new DateTime(2021, 11, 08), Value = 4M },
                new CFDInfoDto { Date = new DateTime(2021, 11, 15), Value = -6M },
                new CFDInfoDto { Date = new DateTime(2021, 11, 22), Value = 2M },
                new CFDInfoDto { Date = new DateTime(2021, 11, 29), Value = -7M },
                new CFDInfoDto { Date = new DateTime(2021, 12, 06), Value = -2M },
                new CFDInfoDto { Date = new DateTime(2021, 12, 13), Value = -2M },
                new CFDInfoDto { Date = new DateTime(2021, 12, 27), Value = 10M },
                new CFDInfoDto { Date = new DateTime(2022, 01, 03), Value = -1M },
                new CFDInfoDto { Date = new DateTime(2022, 01, 10), Value = 2M },
                new CFDInfoDto { Date = new DateTime(2022, 01, 17), Value = -3M },
                new CFDInfoDto { Date = new DateTime(2022, 01, 24), Value = 1M },
                new CFDInfoDto { Date = new DateTime(2022, 01, 31), Value = 10M },
                new CFDInfoDto { Date = new DateTime(2022, 02, 07), Value = 1M },
                new CFDInfoDto { Date = new DateTime(2022, 02, 14), Value = 0M },
                new CFDInfoDto { Date = new DateTime(2022, 02, 21), Value = -5M },
                new CFDInfoDto { Date = new DateTime(2022, 02, 28), Value = -1M }
            };

        public static IDictionary<GrowthTypes, IList<CFDInfoDto>> CreateCheckCalculateGrowthToDoInProgress()
        {
            var data = Create();
            data[GrowthTypes.ToDo][0].Value = 2M;
            data[GrowthTypes.ToDo][2].Value = 1M;
            data[GrowthTypes.ToDo][7].Value = 1M;
            data[GrowthTypes.ToDo][9].Value = 1M;
            data[GrowthTypes.ToDo][10].Value = -4M;
            data[GrowthTypes.ToDo][11].Value = 0M;
            data[GrowthTypes.ToDo][12].Value = 0M;
            data[GrowthTypes.ToDo][13].Value = 12M;
            data[GrowthTypes.ToDo][14].Value = -13M;
            data[GrowthTypes.ToDo][15].Value = -1M;
            data[GrowthTypes.ToDo][16].Value = 2M;
            data[GrowthTypes.ToDo][17].Value = -1M;
            data[GrowthTypes.ToDo][18].Value = 1M;
            data[GrowthTypes.ToDo][19].Value = 0M;
            data[GrowthTypes.ToDo][20].Value = 0M;
            data[GrowthTypes.ToDo][21].Value = -3M;
            data[GrowthTypes.ToDo][22].Value = 0M;
            data[GrowthTypes.ToDo][23].Value = 0M;
            data[GrowthTypes.ToDo][24].Value = 1M;
            data[GrowthTypes.ToDo][25].Value = 1M;
            data[GrowthTypes.ToDo][26].Value = 2M;
            data[GrowthTypes.ToDo][27].Value = -4M;
            data[GrowthTypes.ToDo][28].Value = 1M;
            data[GrowthTypes.ToDo][29].Value = 10M;
            data[GrowthTypes.ToDo][30].Value = 2M;
            data[GrowthTypes.ToDo][31].Value = -7M;
            data[GrowthTypes.ToDo][32].Value = -1M;
            data[GrowthTypes.ToDo][33].Value = 1M;

            data[GrowthTypes.InProgress][2].Value = 0M;
            data[GrowthTypes.InProgress][7].Value = 0M;
            data[GrowthTypes.InProgress][9].Value = 4M;
            data[GrowthTypes.InProgress][10].Value = 6M;
            data[GrowthTypes.InProgress][11].Value = 0M;
            data[GrowthTypes.InProgress][12].Value = 0M;
            data[GrowthTypes.InProgress][13].Value = 1M;
            data[GrowthTypes.InProgress][14].Value = 14M;
            data[GrowthTypes.InProgress][15].Value = 3M;
            data[GrowthTypes.InProgress][16].Value = 1M;
            data[GrowthTypes.InProgress][17].Value = 1M;
            data[GrowthTypes.InProgress][18].Value = 5M;
            data[GrowthTypes.InProgress][19].Value = 1M;
            data[GrowthTypes.InProgress][20].Value = 3M;
            data[GrowthTypes.InProgress][21].Value = 5M;
            data[GrowthTypes.InProgress][22].Value = 0M;
            data[GrowthTypes.InProgress][23].Value = 0M;
            data[GrowthTypes.InProgress][24].Value = 9M;
            data[GrowthTypes.InProgress][25].Value = 1M;
            data[GrowthTypes.InProgress][26].Value = 5M;
            data[GrowthTypes.InProgress][27].Value = 8M;
            data[GrowthTypes.InProgress][28].Value = 0M;
            data[GrowthTypes.InProgress][29].Value = 3M;
            data[GrowthTypes.InProgress][30].Value = 2M;
            data[GrowthTypes.InProgress][31].Value = 10M;
            data[GrowthTypes.InProgress][32].Value = 7M;
            data[GrowthTypes.InProgress][33].Value = 0M;

            return data;
        }
    }
}