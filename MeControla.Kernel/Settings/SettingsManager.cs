using System.IO;
using System.Text.Json;

namespace MeControla.Kernel.Settings
{
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public class SettingsManager<T> : ISettingsManager<T>
        where T : class, new()
    {
        private readonly string filePath;

        public T Data { get; set; }

        public SettingsManager(string fileName)
        {
            filePath = GetLocalFilePath(fileName);

            if (!File.Exists(filePath))
                CreateFile();

            Data = LoadSettings();
        }

        private static string GetLocalFilePath(string fileName)
        {
            var appData = Directory.GetCurrentDirectory();
            return Path.Combine(appData, fileName);
        }

        public T LoadSettings()
            => JsonSerializer.Deserialize<T>(File.ReadAllText(filePath));

        public void SaveSettings()
            => SaveData(Data);

        private void CreateFile()
            => SaveData(new T());

        private void SaveData(T data)
        {
            var json = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, json);
        }
    }
}