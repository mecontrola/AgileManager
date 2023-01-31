using Microsoft.DotNetCore.Hosting.Internal;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.DotNetCore.Hosting.Infrastructure
{
    /// <summary>
    /// An interface implemented by IDesktopHostBuilders that handle <see cref="DesktopHostBuilderExtensions.UseStartup(IDesktopHostBuilder, Type)"/>
    /// and <see cref="DesktopHostBuilderExtensions.UseStartup{TStartup}(IDesktopHostBuilder, Func{DesktopHostBuilderContext, TStartup})"/>
    /// directly.
    /// </summary>
    public interface ISupportsStartup
    {
        /// <summary>
        /// Specify the startup method to be used to configure the desktop application.
        /// </summary>
        /// <param name="configure">The delegate that configures the <see cref="IApplicationBuilder"/>.</param>
        /// <returns>The <see cref="IDesktopHostBuilder"/>.</returns>
        IDesktopHostBuilder Configure(Action<IApplicationBuilder> configure);

        /// <summary>
        /// Specify the startup method to be used to configure the desktop application.
        /// </summary>
        /// <param name="configure">The delegate that configures the <see cref="IApplicationBuilder"/>.</param>
        /// <returns>The <see cref="IDesktopHostBuilder"/>.</returns>
        IDesktopHostBuilder Configure(Action<DesktopHostBuilderContext, IApplicationBuilder> configure);

        /// <summary>
        /// Specify the startup type to be used by the desktop host.
        /// </summary>
        /// <param name="startupType">The <see cref="Type"/> to be used.</param>
        /// <returns>The <see cref="IDesktopHostBuilder"/>.</returns>
        IDesktopHostBuilder UseStartup([DynamicallyAccessedMembers(StartupLinkerOptions.Accessibility)] Type startupType);

        /// <summary>
        /// Specify a factory that creates the startup instance to be used by the desktop host.
        /// </summary>
        /// <param name="startupFactory">A delegate that specifies a factory for the startup class.</param>
        /// <returns>The <see cref="IDesktopHostBuilder"/>.</returns>
        /// <remarks>When using the IL linker, all public methods of <typeparamref name="TStartup"/> are preserved. This should match the Startup type directly (and not a base type).</remarks>
        IDesktopHostBuilder UseStartup<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TStartup>(Func<DesktopHostBuilderContext, TStartup> startupFactory);
    }
}