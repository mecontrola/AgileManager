using Microsoft.Extensions.Hosting;
using System;

namespace Microsoft.DotNetCore.Hosting
{
    /// <summary>
    /// Contains extensions for an <see cref="IHostBuilder"/>.
    /// </summary>
    public static class GenericHostDesktopHostBuilderExtensions
    {
        /// <summary>
        /// Adds and configures an DOTNET Core desktop application.
        /// </summary>
        /// <param name="builder">The <see cref="IHostBuilder"/> to add the <see cref="IDesktopHostBuilder"/> to.</param>
        /// <param name="configure">The delegate that configures the <see cref="IDesktopHostBuilder"/>.</param>
        /// <returns>The <see cref="IHostBuilder"/>.</returns>
        public static IHostBuilder ConfigureDesktopHost(this IHostBuilder builder, Action<IDesktopHostBuilder> configure)
        {
            if (configure is null)
                throw new ArgumentNullException(nameof(configure));

            return builder.ConfigureDesktopHost(configure, _ => { });
        }

        /// <summary>
        /// Adds and configures an DOTNET Core desktop application.
        /// </summary>
        /// <param name="builder">The <see cref="IHostBuilder"/> to add the <see cref="IDesktopHostBuilder"/> to.</param>
        /// <param name="configure">The delegate that configures the <see cref="IDesktopHostBuilder"/>.</param>
        /// <param name="configureDesktopHostBuilder">The delegate that configures the <see cref="DesktopHostBuilderOptions"/>.</param>
        /// <returns>The <see cref="IHostBuilder"/>.</returns>
        public static IHostBuilder ConfigureDesktopHost(this IHostBuilder builder, Action<IDesktopHostBuilder> configure, Action<DesktopHostBuilderOptions> configureDesktopHostBuilder)
        {
            if (configure is null)
                throw new ArgumentNullException(nameof(configure));

            if (configureDesktopHostBuilder is null)
                throw new ArgumentNullException(nameof(configureDesktopHostBuilder));

            var desktopHostBuilderOptions = new DesktopHostBuilderOptions();
            configureDesktopHostBuilder(desktopHostBuilderOptions);
            var desktopHostBuilder = new GenericDesktopHostBuilder(builder, desktopHostBuilderOptions);
            configure(desktopHostBuilder);
            return builder;
        }
    }
}