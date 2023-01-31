using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.DotNetCore.Hosting.Internal
{
    internal readonly struct UseStartupState
    {
        public UseStartupState([DynamicallyAccessedMembers(StartupLinkerOptions.Accessibility)] Type startupType)
            => StartupType = startupType;

        [DynamicallyAccessedMembers(StartupLinkerOptions.Accessibility)]
        public Type StartupType { get; }
    }
}