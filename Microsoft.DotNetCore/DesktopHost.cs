using Microsoft.DotNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Microsoft.DotNetCore
{
    /// <summary>
    /// Provides convenience methods for creating instances of <see cref="IDesktopHost"/> and <see cref="IDesktopHostBuilder"/> with pre-configured defaults.
    /// </summary>
    public static class DesktopHost
    {
        internal static void ConfigureDesktopDefaults(IDesktopHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((ctx, config) =>
            {
                config.AddJsonFile("usersettings.json", optional: true, reloadOnChange: true);
            });
        }
    }
}