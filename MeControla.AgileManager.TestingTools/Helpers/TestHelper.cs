using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MeControla.AgileManager.TestingTools.Helpers
{
    public sealed class TestHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethodName()
            => new StackTrace().GetFrame(1)
                               .GetMethod()
                               .Name;
    }
}