namespace MeControla.Kernel.Settings
{
    public interface ISettingsManager<T>
        where T : class, new()
    {
        T Data { get; set; }

        T LoadSettings();
        void SaveSettings();
    }
}