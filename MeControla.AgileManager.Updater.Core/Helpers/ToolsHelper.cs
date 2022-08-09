using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace MeControla.AgileManager.Updater.Core.Helpers
{
    public class ToolsHelper : IToolsHelper
    {
        public IWinProcess FindProcessRunning(string processName)
        {
            var process = Process.GetProcesses()
                                 .FirstOrDefault(p => processName.StartsWith(p.ProcessName));
            return new WinProcess(process);
        }

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