using Stefanini.Core.Settings;

namespace Stefanini.ViaReport.Core.Helpers
{
    public interface ISettingsHelper
    {
        UserSettings Data { get; set; }

        void Save();
    }
}