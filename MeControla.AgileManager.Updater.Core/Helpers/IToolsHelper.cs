using System.Diagnostics;

namespace MeControla.AgileManager.Updater.Core.Helpers
{
    public interface IToolsHelper
    {
        void FileDelete(string path);
        bool FileExists(string path);
        IWinProcess FindProcessRunning(string processName);
        string GetFileVersion(string path);
        void ZipExtractOverride(string sourcePath, string destinationPath);
    }
}