using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Microsoft.DotNetCore.Hosting.Internal
{
    internal sealed class StartupLoader
    {
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "We're warning at the entry point. This is an implementation detail.")]
        public static Type FindStartupType(string startupAssemblyName, string environmentName)
        {
            if (string.IsNullOrEmpty(startupAssemblyName))
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "A startup method, startup type or startup assembly is required. If specifying an assembly, '{0}' cannot be null or empty.", nameof(startupAssemblyName)), nameof(startupAssemblyName));

            var assembly = Assembly.Load(new AssemblyName(startupAssemblyName));
            if (assembly == null)
                throw new InvalidOperationException($"The assembly '{startupAssemblyName}' failed to load.");

            var startupNameWithEnv = "Startup" + environmentName;
            var startupNameWithoutEnv = "Startup";

            // Check the most likely places first
            var type = assembly.GetType(startupNameWithEnv) ??
                       assembly.GetType(startupAssemblyName + "." + startupNameWithEnv) ??
                       assembly.GetType(startupNameWithoutEnv) ??
                       assembly.GetType(startupAssemblyName + "." + startupNameWithoutEnv);

            if (type == null)
            {
                // Full scan
                var definedTypes = assembly.DefinedTypes.ToList();

                var startupType1 = definedTypes.Where(info => info.Name.Equals(startupNameWithEnv, StringComparison.OrdinalIgnoreCase));
                var startupType2 = definedTypes.Where(info => info.Name.Equals(startupNameWithoutEnv, StringComparison.OrdinalIgnoreCase));

                var typeInfo = startupType1.Concat(startupType2).FirstOrDefault();
                if (typeInfo != null)
                    type = typeInfo.AsType();
            }

            if (type == null)
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "A type named '{0}' or '{1}' could not be found in assembly '{2}'.", startupNameWithEnv, startupNameWithoutEnv, startupAssemblyName));

            return type;
        }

        internal static ConfigureBuilder FindConfigureDelegate([DynamicallyAccessedMembers(StartupLinkerOptions.Accessibility)] Type startupType, string environmentName)
        {
            var configureMethod = FindMethod(startupType, "Configure{0}", environmentName, typeof(void), required: true)!;
            return new ConfigureBuilder(configureMethod);
        }

        internal static ConfigureContainerBuilder FindConfigureContainerDelegate([DynamicallyAccessedMembers(StartupLinkerOptions.Accessibility)] Type startupType, string environmentName)
        {
            var configureMethod = FindMethod(startupType, "Configure{0}Container", environmentName, typeof(void), required: false);
            return new ConfigureContainerBuilder(configureMethod);
        }

        internal static bool HasConfigureServicesIServiceProviderDelegate([DynamicallyAccessedMembers(StartupLinkerOptions.Accessibility)] Type startupType, string environmentName)
            => null != FindMethod(startupType, "Configure{0}Services", environmentName, typeof(IServiceProvider), required: false);

        internal static ConfigureServicesBuilder FindConfigureServicesDelegate([DynamicallyAccessedMembers(StartupLinkerOptions.Accessibility)] Type startupType, string environmentName)
        {
            var servicesMethod = FindMethod(startupType, "Configure{0}Services", environmentName, typeof(IServiceProvider), required: false)
                              ?? FindMethod(startupType, "Configure{0}Services", environmentName, typeof(void), required: false);
            return new ConfigureServicesBuilder(servicesMethod);
        }

        private static MethodInfo FindMethod([DynamicallyAccessedMembers(StartupLinkerOptions.Accessibility)] Type startupType, string methodName, string environmentName, Type returnType = null, bool required = true)
        {
            var methodNameWithEnv = string.Format(CultureInfo.InvariantCulture, methodName, environmentName);
            var methodNameWithNoEnv = string.Format(CultureInfo.InvariantCulture, methodName, string.Empty);

            var methods = startupType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            var selectedMethods = methods.Where(method => method.Name.Equals(methodNameWithEnv, StringComparison.OrdinalIgnoreCase)).ToList();
            if (selectedMethods.Count > 1)
                throw new InvalidOperationException($"Having multiple overloads of method '{methodNameWithEnv}' is not supported.");

            if (selectedMethods.Count == 0)
            {
                selectedMethods = methods.Where(method => method.Name.Equals(methodNameWithNoEnv, StringComparison.OrdinalIgnoreCase)).ToList();
                if (selectedMethods.Count > 1)
                    throw new InvalidOperationException($"Having multiple overloads of method '{methodNameWithNoEnv}' is not supported.");
            }

            var methodInfo = selectedMethods.FirstOrDefault();
            if (methodInfo == null)
            {
                if (required)
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "A public method named '{0}' or '{1}' could not be found in the '{2}' type.", methodNameWithEnv, methodNameWithNoEnv, startupType.FullName));

                return null;
            }

            if (returnType != null && methodInfo.ReturnType != returnType)
            {
                if (required)
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "The '{0}' method in the type '{1}' must have a return type of '{2}'.", methodInfo.Name, startupType.FullName, returnType.Name));

                return null;
            }

            return methodInfo;
        }
    }
}