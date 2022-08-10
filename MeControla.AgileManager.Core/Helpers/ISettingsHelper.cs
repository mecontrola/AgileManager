using MeControla.AgileManager.Data.Dtos.Settings;

namespace MeControla.AgileManager.Core.Helpers
{
    public interface ISettingsHelper
    {
        AppSettingsDto Data { get; set; }

        void Save();
    }
}