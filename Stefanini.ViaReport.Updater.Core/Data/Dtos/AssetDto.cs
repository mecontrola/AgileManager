using System;

namespace Stefanini.ViaReport.Updater.Core.Data.Dtos
{
    public class AssetDto : BaseDto
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public UserDto Uploader { get; set; }
        public string ContentType { get; set; }
        public string State { get; set; }
        public int Size { get; set; }
        public int DownloadCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string BrowserDownloadUrl { get; set; }
    }
}