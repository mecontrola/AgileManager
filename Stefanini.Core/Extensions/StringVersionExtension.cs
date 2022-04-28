using System;
using System.Text.RegularExpressions;

namespace Stefanini.Core.Extensions
{
    public static class StringVersionExtension
    {
        private const string REGEX_VERSION_KEY = "version";
        private const string REGEX_VERSION = $@"(?<{REGEX_VERSION_KEY}>[0-9].[0-9].[0-9](.[0-9])?)";

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static Version GetVersion(this string value)
        {
            var regex = Regex.Match(value, REGEX_VERSION);
            return !regex.Success
                 ? null
                 : new(regex.Groups[REGEX_VERSION_KEY].Value);
        }
    }
}