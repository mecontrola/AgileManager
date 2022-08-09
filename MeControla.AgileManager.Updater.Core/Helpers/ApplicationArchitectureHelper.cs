using System;

namespace MeControla.AgileManager.Updater.Core.Helpers
{
    public class ApplicationArchitectureHelper : IApplicationArchitectureHelper
    {
        public bool Isx64()
            => IntPtr.Size == 8;
    }
}