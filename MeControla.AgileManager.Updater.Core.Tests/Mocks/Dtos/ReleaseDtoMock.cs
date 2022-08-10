using MeControla.AgileManager.Updater.Core.Data.Dtos;
using System;

namespace MeControla.AgileManager.Updater.Core.Tests.Mocks.Dtos
{
    public class ReleaseDtoMock
    {
        private const string VERSION_INVALID = "Version 1.0b.9";

        public static ReleaseDto Create()
            => new()
            {
                Url = "https://api.github.com/repos/mecontrola/Stefanini/releases/63922975",
                AssetsUrl = "https://api.github.com/repos/mecontrola/Stefanini/releases/63922975/assets",
                UploadUrl = "https://uploads.github.com/repos/mecontrola/Stefanini/releases/63922975/assets{?name,label}",
                HtmlUrl = "https://github.com/mecontrola/Stefanini/releases/tag/v1.0.0.4",
                Id = 63922975,
                Author = UserDtoMock.Create(),
                NodeId = "RE_kwDOGyl12c4Dz2Mf",
                TagName = "v1.0.0.4",
                TargetCommitish = "ea61e8d2ff07967a0b7df0b18280d472c51bdc00",
                Name = "v1.0.0.4",
                Draft = false,
                Prerelease = false,
                CreatedAt = new DateTime(2022, 4, 7, 21, 41, 3),
                PublishedAt = new DateTime(2022, 4, 7, 21, 42, 26),
                Assets = AssestDtoMock.CreateList(),
                TarballUrl = "https://api.github.com/repos/mecontrola/Stefanini/tarball/v1.0.0.4",
                ZipballUrl = "https://api.github.com/repos/mecontrola/Stefanini/zipball/v1.0.0.4",
                Body = string.Empty
            };

        public static ReleaseDto CreateInvalidVersion()
        {
            var dto = Create();
            dto.Name = VERSION_INVALID;
            dto.TagName = VERSION_INVALID;
            return dto;
        }

        public static ReleaseDto CreateNullVersion()
        {
            var dto = Create();
            dto.Name = null;
            dto.TagName = null;
            return dto;
        }
    }
}