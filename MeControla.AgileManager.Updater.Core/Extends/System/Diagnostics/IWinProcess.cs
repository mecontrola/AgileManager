namespace System.Diagnostics
{
    public interface IWinProcess : IDisposable
    {
        bool HasProcess();
        void Kill();
        void WaitForExit();
    }
}