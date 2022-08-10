using MeControla.AgileManager.Updater.Core.Data.Dtos;
using System;
using System.Collections.Generic;

namespace MeControla.AgileManager.Updater.Core.Tests.Mocks.Dtos
{
    public class AssestDtoMock
    {
        public static AssetDto Createx86()
            => new()
            {
                Url = "https://api.github.com/repos/mecontrola/Stefanini/releases/assets/61881500",
                Id = 61881500,
                NodeId = "RA_kwDOGyl12c4DsDyc",
                Name = "AHM.Report-v1.0.0.4_x64.zip",
                Label = string.Empty,
                Uploader = UserDtoMock.Create(),
                ContentType = "application/octet-stream",
                State = "uploaded",
                Size = 62777288,
                DownloadCount = 0,
                CreatedAt = new DateTime(2022, 4, 7, 21, 45, 37),
                UpdatedAt = new DateTime(2022, 4, 7, 21, 45, 39),
                BrowserDownloadUrl = "https://github.com/mecontrola/Stefanini/releases/download/v1.0.0.4/AHM.Report-v1.0.0.4_x64.zip"
            };

        public static AssetDto Createx64()
            => new()
            {
                Url = "https://api.github.com/repos/mecontrola/Stefanini/releases/assets/61881545",
                Id = 61881545,
                NodeId = "RA_kwDOGyl12c4DsDzJ",
                Name = "AHM.Report-v1.0.0.4_x86.zip",
                Label = string.Empty,
                Uploader = UserDtoMock.Create(),
                ContentType = "application/octet-stream",
                State = "uploaded",
                Size = 57243554,
                DownloadCount = 0,
                CreatedAt = new DateTime(2022, 4, 7, 21, 46, 40),
                UpdatedAt = new DateTime(2022, 4, 7, 21, 46, 43),
                BrowserDownloadUrl = "https://github.com/mecontrola/Stefanini/releases/download/v1.0.0.4/AHM.Report-v1.0.0.4_x86.zip"
            };

        public static IList<AssetDto> CreateList()
            => new List<AssetDto>
            {
                Createx86(),
                Createx64()
            };
    }
}