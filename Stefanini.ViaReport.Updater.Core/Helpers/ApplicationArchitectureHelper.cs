using System;

namespace Stefanini.ViaReport.Updater.Core.Helpers
{
    public class ApplicationArchitectureHelper : IApplicationArchitectureHelper
    {
        public bool Isx64()
            => IntPtr.Size == 8;
    }
}