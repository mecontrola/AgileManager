using Microsoft.DotNetCore;
using Microsoft.DotNetCore.Hosting;
using System;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// Extension methods for configuring the <see cref="IHostBuilder" />.
    /// </summary>
    public static class GenericHostBuilderExtensions
    {
        /// <summary>
        /// Configures a <see cref="IHostBuilder" /> with defaults for hosting a web app. This should be called
        /// before application specific configuration to avoid it overwriting provided services, configuration sources,
        /// environments, content root, etc.
        /// </summary>
        /// <param name="builder">The <see cref="IHostBuilder" /> instance to configure.</param>
        /// <param name="configure">The configure callback</param>
        /// <returns>A reference to the <paramref name="builder"/> after the operation has completed.</returns>
        public static IHostBuilder ConfigureDesktopHostDefaults(this IHostBuilder builder, Action<IDesktopHostBuilder> configure)
        {
            if (configure is null)
                throw new ArgumentNullException(nameof(configure));

            return builder.ConfigureDesktopHost(desktopHostBuilder =>
            {
                DesktopHost.ConfigureDesktopDefaults(desktopHostBuilder);

                configure(desktopHostBuilder);
            });
        }
    }
}