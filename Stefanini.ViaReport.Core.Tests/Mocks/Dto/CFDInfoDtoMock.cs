using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Enums;
using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Dto
{
    public class CFDInfoDtoMock
    {
        public static IDictionary<EasyBIReportColumnName, IList<CFDInfoDto>> CreateCheckFile()
            => new Dictionary<EasyBIReportColumnName, IList<CFDInfoDto>>
            {
                { EasyBIReportColumnName.ToDo, CreateFileToDoData() },
                { EasyBIReportColumnName.InProgress, CreateFileInProgressData() },
                { EasyBIReportColumnName.Done, CreateFileDoneData() },
            };

        private static IList<CFDInfoDto> CreateFileToDoData()
            => new List<CFDInfoDto>
            {
                new CFDInfoDto { Date = new DateTime(2021, 06, 14), Value = 2 },
                new CFDInfoDto { Date = new DateTime(2021, 06, 21), Value = 4 },
                new CFDInfoDto { Date = new DateTime(2021, 06, 28), Value = 4 },
                new CFDInfoDto { Date = new DateTime(2021, 07, 12), Value = 5 },
                new CFDInfoDto { Date = new DateTime(2021, 07, 19), Value = 5 },
                new CFDInfoDto { Date = new DateTime(2021, 07, 26), Value = 5 },
                new CFDInfoDto { Date = new DateTime(2021, 08, 09), Value = 5 },
                new CFDInfoDto { Date = new DateTime(2021, 08, 16), Value = 5 },
                new CFDInfoDto { Date = new DateTime(2021, 08, 23), Value = 6 },
                new CFDInfoDto { Date = new DateTime(2021, 08, 30), Value = 6 },
                new CFDInfoDto { Date = new DateTime(2021, 09, 06), Value = 7 },
                new CFDInfoDto { Date = new DateTime(2021, 09, 13), Value = 3 },
                new CFDInfoDto { Date = new DateTime(2021, 09, 20), Value = 3 },
                new CFDInfoDto { Date = new DateTime(2021, 09, 27), Value = 3 },
                new CFDInfoDto { Date = new DateTime(2021, 10, 04), Value = 15 },
                new CFDInfoDto { Date = new DateTime(2021, 10, 11), Value = 2 },
                new CFDInfoDto { Date = new DateTime(2021, 10, 18), Value = 1 },
                new CFDInfoDto { Date = new DateTime(2021, 10, 25), Value = 3 },
                new CFDInfoDto { Date = new DateTime(2021, 11, 01), Value = 2 },
                new CFDInfoDto { Date = new DateTime(2021, 11, 08), Value = 3 },
                new CFDInfoDto { Date = new DateTime(2021, 11, 15), Value = 3 },
                new CFDInfoDto { Date = new DateTime(2021, 11, 22), Value = 3 },
                new CFDInfoDto { Date = new DateTime(2021, 11, 29), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 12, 06), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 12, 13), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 12, 27), Value = 1 },
                new CFDInfoDto { Date = new DateTime(2022, 01, 03), Value = 2 },
                new CFDInfoDto { Date = new DateTime(2022, 01, 10), Value = 4 },
                new CFDInfoDto { Date = new DateTime(2022, 01, 17), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2022, 01, 24), Value = 1 },
                new CFDInfoDto { Date = new DateTime(2022, 01, 31), Value = 11 },
                new CFDInfoDto { Date = new DateTime(2022, 02, 07), Value = 13 },
                new CFDInfoDto { Date = new DateTime(2022, 02, 14), Value = 6 },
                new CFDInfoDto { Date = new DateTime(2022, 02, 21), Value = 5 },
                new CFDInfoDto { Date = new DateTime(2022, 02, 28), Value = 6 },
            };

        private static IList<CFDInfoDto> CreateFileInProgressData()
            => new List<CFDInfoDto>
            {
                new CFDInfoDto { Date = new DateTime(2021, 06, 14), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 06, 21), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 06, 28), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 07, 12), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 07, 19), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 07, 26), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 08, 09), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 08, 16), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 08, 23), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 08, 30), Value = 2 },
                new CFDInfoDto { Date = new DateTime(2021, 09, 06), Value = 6 },
                new CFDInfoDto { Date = new DateTime(2021, 09, 13), Value = 11 },
                new CFDInfoDto { Date = new DateTime(2021, 09, 20), Value = 9 },
                new CFDInfoDto { Date = new DateTime(2021, 09, 27), Value = 1 },
                new CFDInfoDto { Date = new DateTime(2021, 10, 04), Value = 2 },
                new CFDInfoDto { Date = new DateTime(2021, 10, 11), Value = 16 },
                new CFDInfoDto { Date = new DateTime(2021, 10, 18), Value = 11 },
                new CFDInfoDto { Date = new DateTime(2021, 10, 25), Value = 9 },
                new CFDInfoDto { Date = new DateTime(2021, 11, 01), Value = 9 },
                new CFDInfoDto { Date = new DateTime(2021, 11, 08), Value = 12 },
                new CFDInfoDto { Date = new DateTime(2021, 11, 15), Value = 6 },
                new CFDInfoDto { Date = new DateTime(2021, 11, 22), Value = 8 },
                new CFDInfoDto { Date = new DateTime(2021, 11, 29), Value = 4 },
                new CFDInfoDto { Date = new DateTime(2021, 12, 06), Value = 2 },
                new CFDInfoDto { Date = new DateTime(2021, 12, 13), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 12, 27), Value = 9 },
                new CFDInfoDto { Date = new DateTime(2022, 01, 03), Value = 7 },
                new CFDInfoDto { Date = new DateTime(2022, 01, 10), Value = 7 },
                new CFDInfoDto { Date = new DateTime(2022, 01, 17), Value = 8 },
                new CFDInfoDto { Date = new DateTime(2022, 01, 24), Value = 8 },
                new CFDInfoDto { Date = new DateTime(2022, 01, 31), Value = 8 },
                new CFDInfoDto { Date = new DateTime(2022, 02, 07), Value = 7 },
                new CFDInfoDto { Date = new DateTime(2022, 02, 14), Value = 14 },
                new CFDInfoDto { Date = new DateTime(2022, 02, 21), Value = 10 },
                new CFDInfoDto { Date = new DateTime(2022, 02, 28), Value = 8 },
            };

        private static IList<CFDInfoDto> CreateFileDoneData()
            => new List<CFDInfoDto>
            {
                new CFDInfoDto { Date = new DateTime(2021, 06, 14), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 06, 21), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 06, 28), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 07, 12), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 07, 19), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 07, 26), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 08, 09), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 08, 16), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 08, 23), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 08, 30), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 09, 06), Value = 0 },
                new CFDInfoDto { Date = new DateTime(2021, 09, 13), Value = 1 },
                new CFDInfoDto { Date = new DateTime(2021, 09, 20), Value = 3 },
                new CFDInfoDto { Date = new DateTime(2021, 09, 27), Value = 11 },
                new CFDInfoDto { Date = new DateTime(2021, 10, 04), Value = 11 },
                new CFDInfoDto { Date = new DateTime(2021, 10, 11), Value = 11 },
                new CFDInfoDto { Date = new DateTime(2021, 10, 18), Value = 19 },
                new CFDInfoDto { Date = new DateTime(2021, 10, 25), Value = 22 },
                new CFDInfoDto { Date = new DateTime(2021, 11, 01), Value = 23 },
                new CFDInfoDto { Date = new DateTime(2021, 11, 08), Value = 25 },
                new CFDInfoDto { Date = new DateTime(2021, 11, 15), Value = 32 },
                new CFDInfoDto { Date = new DateTime(2021, 11, 22), Value = 33 },
                new CFDInfoDto { Date = new DateTime(2021, 11, 29), Value = 42 },
                new CFDInfoDto { Date = new DateTime(2021, 12, 06), Value = 44 },
                new CFDInfoDto { Date = new DateTime(2021, 12, 13), Value = 46 },
                new CFDInfoDto { Date = new DateTime(2021, 12, 27), Value = 46 },
                new CFDInfoDto { Date = new DateTime(2022, 01, 03), Value = 49 },
                new CFDInfoDto { Date = new DateTime(2022, 01, 10), Value = 54 },
                new CFDInfoDto { Date = new DateTime(2022, 01, 17), Value = 61 },
                new CFDInfoDto { Date = new DateTime(2022, 01, 24), Value = 61 },
                new CFDInfoDto { Date = new DateTime(2022, 01, 31), Value = 64 },
                new CFDInfoDto { Date = new DateTime(2022, 02, 07), Value = 67 },
                new CFDInfoDto { Date = new DateTime(2022, 02, 14), Value = 70 },
                new CFDInfoDto { Date = new DateTime(2022, 02, 21), Value = 81 },
                new CFDInfoDto { Date = new DateTime(2022, 02, 28), Value = 83 },
            };
    }
}