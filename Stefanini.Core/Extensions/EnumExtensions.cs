using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Stefanini.Core.Extensions
{
    public static class EnumExtensions
    {
        [DebuggerStepThrough]
        public static string GetDescription(this Enum value)
            => value.GetType()
                    .GetField(value.ToString())
                    .GetCustomAttribute<DescriptionAttribute>()?
                    .Description ?? null;
    }
}