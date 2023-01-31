namespace Microsoft.DotNetCore.Hosting
{
    /// <summary>
    /// Represents platform specific configuration that will be applied to a <see cref="IDesktopHostBuilder"/> when building an <see cref="IDesktopHost"/>.
    /// </summary>
    public interface IHostingStartup
    {
        /// <summary>
        /// Configure the <see cref="IDesktopHostBuilder"/>.
        /// </summary>
        /// <remarks>
        /// Configure is intended to be called before user code, allowing a user to overwrite any changes made.
        /// </remarks>
        /// <param name="builder"></param>
        void Configure(IDesktopHostBuilder builder);
    }
}