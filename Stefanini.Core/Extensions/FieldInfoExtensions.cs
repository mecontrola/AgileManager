using System;
using System.Reflection;

namespace Stefanini.Core.Extensions
{
    public static class FieldInfoExtensions
    {
        public static T GetCustomAttribute<T>(this FieldInfo fieldInfo)
            where T : Attribute
            => (T)fieldInfo.GetCustomAttribute(typeof(T));
    }
}