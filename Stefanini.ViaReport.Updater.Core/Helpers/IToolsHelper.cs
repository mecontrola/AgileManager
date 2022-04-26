using Stefanini.ViaReport.Updater.Core.Extends.System.Diagnostics;

namespace Stefanini.ViaReport.Updater.Core.Helpers
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