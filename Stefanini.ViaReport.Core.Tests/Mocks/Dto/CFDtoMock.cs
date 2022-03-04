using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Enums;
using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Dto
{
    public class CFDtoMock
    {
        public static IDictionary<EasyBIReportColumnName, IList<CFDInfoDto>> Create()
            => new Dictionary<EasyBIReportColumnName, IList<CFDInfoDto>>
            {
                { EasyBIReportColumnName.ToDo, CreateToDoData() },
                { EasyBIReportColumnName.InProgress, CreateInProgressData() },
                { EasyBIReportColumnName.Done, CreateDoneData() },
            };

        private static IList<CFDInfoDto> CreateToDoData()
            => new List<CFDInfoDto>
            {
                new CFDInfoDto { Date = new DateTime(2021, 06, 14), Value = 2, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 06, 21), Value = 4, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 06, 28), Value = 4, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 07, 12), Value = 5, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 07, 19), Value = 5, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 07, 26), Value = 5, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 08, 09), Value = 5, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 08, 16), Value = 5, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 08, 23), Value = 6, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 08, 30), Value = 6, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 09, 06), Value = 7, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 09, 13), Value = 3, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 09, 20), Value = 3, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 09, 27), Value = 3, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 10, 04), Value = 15, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 10, 11), Value = 2, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 10, 18), Value = 1, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 10, 25), Value = 3, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 11, 01), Value = 2, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 11, 08), Value = 3, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 11, 15), Value = 3, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 11, 22), Value = 3, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 11, 29), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 12, 06), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 12, 13), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 12, 27), Value = 1, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2022, 01, 03), Value = 2, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2022, 01, 10), Value = 4, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2022, 01, 17), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2022, 01, 24), Value = 1, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2022, 01, 31), Value = 12, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2022, 02, 07), Value = 12, Issues = Array.Empty<string>() },
            };

        private static IList<CFDInfoDto> CreateInProgressData()
            => new List<CFDInfoDto>
            {
                new CFDInfoDto { Date = new DateTime(2021, 06, 14), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 06, 21), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 06, 28), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 07, 12), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 07, 19), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 07, 26), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 08, 09), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 08, 16), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 08, 23), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 08, 30), Value = 2, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 09, 06), Value = 6, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 09, 13), Value = 11, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 09, 20), Value = 9, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 09, 27), Value = 1, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 10, 04), Value = 2, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 10, 11), Value = 16, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 10, 18), Value = 11, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 10, 25), Value = 9, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 11, 01), Value = 9, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 11, 08), Value = 12, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 11, 15), Value = 6, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 11, 22), Value = 8, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 11, 29), Value = 4, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 12, 06), Value = 2, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 12, 13), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 12, 27), Value = 9, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2022, 01, 03), Value = 7, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2022, 01, 10), Value = 7, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2022, 01, 17), Value = 8, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2022, 01, 24), Value = 8, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2022, 01, 31), Value = 8, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2022, 02, 07), Value = 8, Issues = Array.Empty<string>() },
            };

        private static IList<CFDInfoDto> CreateDoneData()
            => new List<CFDInfoDto>
            {
                new CFDInfoDto { Date = new DateTime(2021, 06, 14), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 06, 21), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 06, 28), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 07, 12), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 07, 19), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 07, 26), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 08, 09), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 08, 16), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 08, 23), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 08, 30), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 09, 06), Value = 0, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 09, 13), Value = 1, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 09, 20), Value = 3, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 09, 27), Value = 11, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 10, 04), Value = 11, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 10, 11), Value = 11, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 10, 18), Value = 19, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 10, 25), Value = 22, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 11, 01), Value = 23, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 11, 08), Value = 25, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 11, 15), Value = 32, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 11, 22), Value = 33, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 11, 29), Value = 42, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 12, 06), Value = 44, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 12, 13), Value = 46, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2021, 12, 27), Value = 46, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2022, 01, 03), Value = 49, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2022, 01, 10), Value = 54, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2022, 01, 17), Value = 61, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2022, 01, 24), Value = 61, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2022, 01, 31), Value = 64, Issues = Array.Empty<string>() },
                new CFDInfoDto { Date = new DateTime(2022, 02, 07), Value = 64, Issues = Array.Empty<string>() },
            };
    }
}