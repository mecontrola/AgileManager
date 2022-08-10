using System;
using System.Reflection;

namespace MeControla.Kernel.Extensions
{
    public static class FieldInfoExtensions
    {
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static T GetCustomAttribute<T>(this FieldInfo fieldInfo)
            where T : Attribute
            => (T)fieldInfo.GetCustomAttribute(typeof(T));
    }
}