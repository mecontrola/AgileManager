using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Microsoft.DotNetCore.Hosting
{
    /// <summary>
    /// Context containing the common services on the <see cref="IDesktopHost" />. Some properties may be null until set by the <see cref="IDesktopHost" />.
    /// </summary>
    public class DesktopHostBuilderContext
    {
        /// <summary>
        /// The <see cref="IHostEnvironment" /> initialized by the <see cref="IDesktopHost" />.
        /// </summary>
        public IHostEnvironment HostingEnvironment { get; set; } = default!;

        /// <summary>
        /// The <see cref="IConfiguration" /> containing the merged configuration of the application and the <see cref="IDesktopHost" />.
        /// </summary>
        public IConfiguration Configuration { get; set; } = default!;
    }
}
