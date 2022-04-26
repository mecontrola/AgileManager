using System;

namespace Stefanini.ViaReport.Updater.Core.Extends.System.Diagnostics
{
    public interface IWinProcess : IDisposable
    {
        void Kill();
        void WaitForExit();
    }
}