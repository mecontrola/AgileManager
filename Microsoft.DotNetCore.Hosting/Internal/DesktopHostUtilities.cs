using System;

namespace Microsoft.DotNetCore.Hosting
{
    internal sealed class DesktopHostUtilities
    {
        public static bool ParseBool(string value)
            => string.Equals("true", value, StringComparison.OrdinalIgnoreCase)
            || string.Equals("1", value, StringComparison.OrdinalIgnoreCase);
    }
}