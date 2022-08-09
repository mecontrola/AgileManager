using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MeControla.AgileManager.Helpers
{
    public class AssemblyInfoHelper
    {
        public static string AssemblyTitle
        {
            get
            {
                var title = GetValueFromAssembly<AssemblyTitleAttribute>(itm => itm.Title);
                return string.IsNullOrWhiteSpace(title)
                     ? Path.GetFileNameWithoutExtension(AppContext.BaseDirectory) : title;
            }
        }

        public static string AssemblyVersion { get; }
            = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? string.Empty;

        public static string AssemblyDescription { get; }
            = GetValueFromAssembly<AssemblyDescriptionAttribute>(itm => itm.Description);

        public static string AssemblyProduct { get; }
            = GetValueFromAssembly<AssemblyProductAttribute>(itm => itm.Product);

        public static string AssemblyCopyright { get; }
            = GetValueFromAssembly<AssemblyCopyrightAttribute>(itm => itm.Copyright);

        public static string AssemblyCompany { get; }
            = GetValueFromAssembly<AssemblyCompanyAttribute>(itm => itm.Company);

        private static string GetValueFromAssembly<T>(Func<T, string> predicate)
        {
            var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(T), false);
            return attributes.Any()
                 ? predicate((T)attributes[0])
                 : string.Empty;
        }
    }
}