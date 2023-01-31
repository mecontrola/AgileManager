using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.DotNetCore.Hosting
{
    internal sealed class DesktopHostOptions
    {
        public DesktopHostOptions(IConfiguration primaryConfiguration, IConfiguration fallbackConfiguration = null, IHostEnvironment environment = null)
        {
            if (primaryConfiguration is null)
                throw new ArgumentNullException(nameof(primaryConfiguration));

            string GetConfig(string key) => primaryConfiguration[key] ?? fallbackConfiguration?[key];

            ApplicationName = environment?.ApplicationName ?? GetConfig(DesktopHostDefaults.ApplicationKey) ?? Assembly.GetEntryAssembly()?.GetName().Name ?? string.Empty;
            StartupAssembly = GetConfig(DesktopHostDefaults.StartupAssemblyKey);
            //DetailedErrors = WebHostUtilities.ParseBool(GetConfig(WebHostDefaults.DetailedErrorsKey));
            CaptureStartupErrors = DesktopHostUtilities.ParseBool(GetConfig(DesktopHostDefaults.CaptureStartupErrorsKey));
            Environment = environment?.EnvironmentName ?? GetConfig(DesktopHostDefaults.EnvironmentKey);
            AppRoot = GetConfig(DesktopHostDefaults.AppRootKey);
            //ContentRootPath = environment?.ContentRootPath ?? GetConfig(WebHostDefaults.ContentRootKey);
            PreventHostingStartup = DesktopHostUtilities.ParseBool(GetConfig(DesktopHostDefaults.PreventHostingStartupKey));
            //SuppressStatusMessages = WebHostUtilities.ParseBool(GetConfig(WebHostDefaults.SuppressStatusMessagesKey));
            //ServerUrls = GetConfig(WebHostDefaults.ServerUrlsKey);
            //PreferHostingUrls = WebHostUtilities.ParseBool(GetConfig(WebHostDefaults.PreferHostingUrlsKey));

            // Search the primary assembly and configured assemblies.
            HostingStartupAssemblies = Split(ApplicationName, GetConfig(DesktopHostDefaults.HostingStartupAssembliesKey));
            HostingStartupExcludeAssemblies = Split(GetConfig(DesktopHostDefaults.HostingStartupExcludeAssembliesKey));
            //
            //var timeout = GetConfig(WebHostDefaults.ShutdownTimeoutKey);
            //if (!string.IsNullOrEmpty(timeout)
            //    && int.TryParse(timeout, NumberStyles.None, CultureInfo.InvariantCulture, out var seconds))
            //    ShutdownTimeout = TimeSpan.FromSeconds(seconds);
        }

        public string ApplicationName { get; }

        public bool PreventHostingStartup { get; }
        //
        //public bool SuppressStatusMessages { get; }

        public IReadOnlyList<string> HostingStartupAssemblies { get; }

        public IReadOnlyList<string> HostingStartupExcludeAssemblies { get; }
        //
        //public bool DetailedErrors { get; }
        //
        public bool CaptureStartupErrors { get; }
        
        public string Environment { get; }

        public string StartupAssembly { get; }
        
        public string AppRoot { get; }
        //
        //public string ContentRootPath { get; }
        //
        //public TimeSpan ShutdownTimeout { get; } = TimeSpan.FromSeconds(5);
        //
        //public string ServerUrls { get; }
        //
        //public bool PreferHostingUrls { get; }

        public IEnumerable<string> GetFinalHostingStartupAssemblies()
            => HostingStartupAssemblies.Except(HostingStartupExcludeAssemblies, StringComparer.OrdinalIgnoreCase);

        private static IReadOnlyList<string> Split(string value)
            => value?.Split(';', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            ?? Array.Empty<string>();

        private static IReadOnlyList<string> Split(string applicationName, string environment)
            => string.IsNullOrWhiteSpace(environment)
             ? new[] { applicationName }
             : Split($"{applicationName};{environment}");
    }
}