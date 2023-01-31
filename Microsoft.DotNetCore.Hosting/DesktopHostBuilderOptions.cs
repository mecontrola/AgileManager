namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// Builder options for use with ConfigureDesktopHost.
    /// </summary>
    public class DesktopHostBuilderOptions
    {
        /// <summary>
        /// Indicates if "DOTNETCORE_" prefixed environment variables should be added to configuration.
        /// They are added by default.
        /// </summary>
        public bool SuppressEnvironmentConfiguration { get; set; }
    }
}