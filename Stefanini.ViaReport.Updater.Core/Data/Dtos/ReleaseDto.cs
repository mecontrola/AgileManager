using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Updater.Core.Data.Dtos
{
    public class ReleaseDto : BaseDto
    {
        public string AssetsUrl { get; set; }
        public string UploadUrl { get; set; }
        public string HtmlUrl { get; set; }
        public UserDto Author { get; set; }
        public string TagName { get; set; }
        public string TargetCommitish { get; set; }
        public string Name { get; set; }
        public bool Draft { get; set; }
        public bool Prerelease { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public string TarballUrl { get; set; }
        public string ZipballUrl { get; set; }
        public string Body { get; set; }
        public IList<AssetDto> Assets { get; set; }
    }
}