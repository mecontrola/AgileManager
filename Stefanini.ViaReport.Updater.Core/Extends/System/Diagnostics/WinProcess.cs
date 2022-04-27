using System.Diagnostics.CodeAnalysis;

namespace System.Diagnostics
{
    public class WinProcess : IWinProcess
    {
        private readonly Process process;

        public WinProcess(Process process)
        {
            this.process = process;
        }

        public bool HasProcess()
            => process != null;

        public void Kill()
            => process.Kill();

        public void WaitForExit()
            => process.WaitForExit();

        [SuppressMessage("Usage", "CA1816:Dispose methods should call SuppressFinalize", Justification = "<Pending>")]
        public void Dispose()
            => process.Dispose();
    }
}