using Stefanini.ViaReport.Core.Data.Dto;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Dto
{
    public class AHMInfoDtoMock
    {
        public static IList<AHMInfoDto> Create()
            => new List<AHMInfoDto>
            {
                new AHMInfoDto { Date = "W25, 2021-06-21", GrowthToDo = 0, GrowthInProgress = 0, UpstreamDownstreamRate = 0M, IsChecked = false },
                new AHMInfoDto { Date = "W26, 2021-06-28", GrowthToDo = 0, GrowthInProgress = 0, UpstreamDownstreamRate = 0M, IsChecked = false },
                new AHMInfoDto { Date = "W28, 2021-07-12", GrowthToDo = 0, GrowthInProgress = 0, UpstreamDownstreamRate = null, IsChecked = false },
                new AHMInfoDto { Date = "W29, 2021-07-19", GrowthToDo = 0, GrowthInProgress = 0, UpstreamDownstreamRate = null, IsChecked = false },
                new AHMInfoDto { Date = "W30, 2021-07-26", GrowthToDo = 0, GrowthInProgress = 0, UpstreamDownstreamRate = null, IsChecked = false },
                new AHMInfoDto { Date = "W32, 2021-08-09", GrowthToDo = 0, GrowthInProgress = 0, UpstreamDownstreamRate = null, IsChecked = false },
                new AHMInfoDto { Date = "W33, 2021-08-16", GrowthToDo = 0, GrowthInProgress = 0, UpstreamDownstreamRate = null, IsChecked = false },
                new AHMInfoDto { Date = "W34, 2021-08-23", GrowthToDo = 0, GrowthInProgress = 0, UpstreamDownstreamRate = null, IsChecked = false },
                new AHMInfoDto { Date = "W35, 2021-08-30", GrowthToDo = 0, GrowthInProgress = 0, UpstreamDownstreamRate = null, IsChecked = false },
                new AHMInfoDto { Date = "W36, 2021-09-06", GrowthToDo = 0, GrowthInProgress = 0, UpstreamDownstreamRate = null, IsChecked = false },
                new AHMInfoDto { Date = "W37, 2021-09-13", GrowthToDo = 1, GrowthInProgress = 10, UpstreamDownstreamRate = 0.1M, IsChecked = false },
                new AHMInfoDto { Date = "W38, 2021-09-20", GrowthToDo = 2, GrowthInProgress = -2, UpstreamDownstreamRate = -1, IsChecked = false },
                new AHMInfoDto { Date = "W39, 2021-09-27", GrowthToDo = 8, GrowthInProgress = -8, UpstreamDownstreamRate = -1, IsChecked = false },
                new AHMInfoDto { Date = "W40, 2021-10-04", GrowthToDo = 0, GrowthInProgress = 0, UpstreamDownstreamRate = null, IsChecked = false },
                new AHMInfoDto { Date = "W41, 2021-10-11", GrowthToDo = 0, GrowthInProgress = 0, UpstreamDownstreamRate = null, IsChecked = false },
                new AHMInfoDto { Date = "W42, 2021-10-18", GrowthToDo = 8, GrowthInProgress = 8, UpstreamDownstreamRate = 1, IsChecked = false },
                new AHMInfoDto { Date = "W43, 2021-10-25", GrowthToDo = 0, GrowthInProgress = 0, UpstreamDownstreamRate = null, IsChecked = false },
                new AHMInfoDto { Date = "W44, 2021-11-01", GrowthToDo = 4, GrowthInProgress = -1, UpstreamDownstreamRate = -4, IsChecked = false },
                new AHMInfoDto { Date = "W45, 2021-11-08", GrowthToDo = 2, GrowthInProgress = 4, UpstreamDownstreamRate = 0.5M, IsChecked = false },
                new AHMInfoDto { Date = "W46, 2021-11-15", GrowthToDo = 7, GrowthInProgress = -6, UpstreamDownstreamRate = -1.1666666666666666666666666667M, IsChecked = false },
                new AHMInfoDto { Date = "W47, 2021-11-22", GrowthToDo = 1, GrowthInProgress = 2, UpstreamDownstreamRate = 0.5M, IsChecked = false },
                new AHMInfoDto { Date = "W48, 2021-11-29", GrowthToDo = 9, GrowthInProgress = -7, UpstreamDownstreamRate = -1.2857142857142857142857142857M, IsChecked = false },
                new AHMInfoDto { Date = "W49, 2021-12-06", GrowthToDo = 2, GrowthInProgress = -2, UpstreamDownstreamRate = -1, IsChecked = false },
                new AHMInfoDto { Date = "W50, 2021-12-13", GrowthToDo = 2, GrowthInProgress = -2, UpstreamDownstreamRate = -1, IsChecked = false },
                new AHMInfoDto { Date = "W52, 2021-12-27", GrowthToDo = 0, GrowthInProgress = 0, UpstreamDownstreamRate = null, IsChecked = false },
                new AHMInfoDto { Date = "W1, 2022-01-03", GrowthToDo = 3, GrowthInProgress = 9, UpstreamDownstreamRate = 0.3333333333333333333333333333M, IsChecked = false },
                new AHMInfoDto { Date = "W2, 2022-01-10", GrowthToDo = 5, GrowthInProgress = 2, UpstreamDownstreamRate  = 2.5M, IsChecked = false },
                new AHMInfoDto { Date = "W3, 2022-01-17", GrowthToDo = 7, GrowthInProgress = -3, UpstreamDownstreamRate = -2.3333333333333333333333333333M, IsChecked = false },
                new AHMInfoDto { Date = "W4, 2022-01-24", GrowthToDo = 0, GrowthInProgress = 0, UpstreamDownstreamRate = null , IsChecked = false },
                new AHMInfoDto { Date = "W5, 2022-01-31", GrowthToDo = 3, GrowthInProgress = 11, UpstreamDownstreamRate = 0.2727272727272727272727272727M, IsChecked = false },
                new AHMInfoDto { Date = "W6, 2022-02-07", GrowthToDo = 3, GrowthInProgress = 1, UpstreamDownstreamRate = 3, IsChecked = false },
                new AHMInfoDto { Date = "W7, 2022-02-14", GrowthToDo = 0, GrowthInProgress = 0, UpstreamDownstreamRate = null, IsChecked = false },
                new AHMInfoDto { Date = "W8, 2022-02-21", GrowthToDo = 14,GrowthInProgress = -5, UpstreamDownstreamRate = -2.8M, IsChecked = false },
                new AHMInfoDto { Date = "W9, 2022-02-28", GrowthToDo = 2, GrowthInProgress = -1, UpstreamDownstreamRate = -2 , IsChecked = false }
            };
    }
}