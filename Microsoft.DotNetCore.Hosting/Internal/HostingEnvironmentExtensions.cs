using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace Microsoft.DotNetCore.Hosting
{
    internal static class HostingEnvironmentExtensions
    {
        internal static void Initialize(this IHostEnvironment hostingEnvironment, string contentRootPath, DesktopHostOptions options, IHostEnvironment baseEnvironment = null)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            if (string.IsNullOrEmpty(contentRootPath))
            {
                throw new ArgumentException("A valid non-empty content root must be provided.", nameof(contentRootPath));
            }
            if (!Directory.Exists(contentRootPath))
            {
                throw new ArgumentException($"The content root '{contentRootPath}' does not exist.", nameof(contentRootPath));
            }

            hostingEnvironment.ApplicationName = baseEnvironment?.ApplicationName ?? options.ApplicationName;
            hostingEnvironment.ContentRootPath = contentRootPath;
            hostingEnvironment.ContentRootFileProvider = baseEnvironment?.ContentRootFileProvider ?? new PhysicalFileProvider(hostingEnvironment.ContentRootPath);

            //var appRoot = options.AppRoot;
            //if (appRoot == null)
            //{
            //    // Default to /wwwroot if it exists.
            //    var wwwroot = Path.Combine(hostingEnvironment.ContentRootPath, ".");
            //    if (Directory.Exists(wwwroot))
            //    {
            //        hostingEnvironment.AppRootPath = wwwroot;
            //    }
            //}
            //else
            //{
            //    hostingEnvironment.AppRootPath = Path.Combine(hostingEnvironment.ContentRootPath, appRoot);
            //}
            //
            //if (!string.IsNullOrEmpty(hostingEnvironment.AppRootPath))
            //{
            //    hostingEnvironment.AppRootPath = Path.GetFullPath(hostingEnvironment.AppRootPath);
            //    if (!Directory.Exists(hostingEnvironment.AppRootPath))
            //    {
            //        Directory.CreateDirectory(hostingEnvironment.AppRootPath);
            //    }
            //    hostingEnvironment.AppRootFileProvider = new PhysicalFileProvider(hostingEnvironment.AppRootPath);
            //}
            //else
            //{
            //    hostingEnvironment.AppRootFileProvider = new NullFileProvider();
            //}

            hostingEnvironment.EnvironmentName = baseEnvironment?.EnvironmentName ?? options.Environment ?? hostingEnvironment.EnvironmentName;
        }
    }
}