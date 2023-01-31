using MeControla.AgileManager.Data.Dtos.Settings;
using System.IO;

namespace MeControla.AgileManager.Core.Helpers
{
    public interface ISettingsHelper
    {
        AppSettingsDto Data { get; set; }

        void Save();
        FileSystemWatcher CreateWatcher();
    }
}