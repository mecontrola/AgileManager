using Stefanini.ViaReport.Updater.Core.Extends.System.Diagnostics;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Stefanini.ViaReport.Updater.Core.Helpers
{
    public class ToolsHelper : IToolsHelper
    {
        public IWinProcess FindProcessRunning(string processName)
            => (WinProcess)Process.GetProcesses()
                                  .FirstOrDefault(p => p.ProcessName.StartsWith(processName));

        public string GetFileVersion(string path)
            => FileVersionInfo.GetVersionInfo(path)?.FileVersion;

        public void ZipExtractOverride(string sourcePath, string destinationPath)
            => ZipFile.ExtractToDirectory(sourcePath, destinationPath, true);

        public bool FileExists(string path)
            => File.Exists(path);

        public void FileDelete(string path)
            => File.Delete(path);
    }
}