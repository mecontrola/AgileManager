using Stefanini.ViaReport.Core.Data.Dto.Settings;

namespace Stefanini.ViaReport.Core.Helpers
{
    public interface ISettingsHelper
    {
        AppSettingsDto Data { get; set; }

        void Save();
    }
}