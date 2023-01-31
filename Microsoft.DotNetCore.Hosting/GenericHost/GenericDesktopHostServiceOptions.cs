using System;

namespace Microsoft.DotNetCore.Hosting
{
    internal sealed class GenericDesktopHostServiceOptions
    {
        public Action<IApplicationBuilder> ConfigureApplication { get; set; }

        public DesktopHostOptions WebHostOptions { get; set; } = default!; // Always set when options resolved by DI

        public AggregateException HostingStartupExceptions { get; set; }
    }
}