namespace Stefanini.ViaReport.Updater.Core.Tests.Data.Utils
{
    public interface IActionUpdate
    {
        void UpdateStatus(string text);
        void UpdateProgress(bool show, long value);
    }
}