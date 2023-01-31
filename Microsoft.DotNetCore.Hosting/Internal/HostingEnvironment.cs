using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Microsoft.DotNetCore.Hosting
{
    internal sealed class HostingEnvironment : IHostEnvironment
    {
        public string EnvironmentName { get; set; } = Extensions.Hosting.Environments.Production;

#pragma warning disable CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
        public string ApplicationName { get; set; }
#pragma warning restore CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).

        public string AppRootPath { get; set; } = default!;

        public IFileProvider AppRootFileProvider { get; set; } = default!;

        public string ContentRootPath { get; set; } = default!;

        public IFileProvider ContentRootFileProvider { get; set; } = default!;
    }
}