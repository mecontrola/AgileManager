using Stefanini.ViaReport.Data.Dtos.Settings;

namespace Stefanini.ViaReport.Core.Helpers
{
    public interface ISettingsHelper
    {
        AppSettingsDto Data { get; set; }

        void Save();
    }
}