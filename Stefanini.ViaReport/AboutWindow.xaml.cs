using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Stefanini.ViaReport
{
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();

            LbTitle.Content = $"Sobre {AssemblyTitle}";
            LbProductName.Content = AssemblyProduct;
            LbVersion.Content = $"Versão {AssemblyVersion}";
            LbCopyright.Content = AssemblyCopyright;
            LbCompany.Content = AssemblyCompany;
            TxtDescription.Text = AssemblyDescription;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
            => Close();

        private static string AssemblyTitle
        {
            get
            {
                var title = GetValueFromAssembly<AssemblyTitleAttribute>(itm => itm.Title);
                return string.IsNullOrWhiteSpace(title)
                     ? Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location) : title;
            }
        }

        private static string AssemblyVersion { get; }
            = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? string.Empty;

        private static string AssemblyDescription { get; }
            = GetValueFromAssembly<AssemblyDescriptionAttribute>(itm => itm.Description);

        private static string AssemblyProduct { get; }
            = GetValueFromAssembly<AssemblyProductAttribute>(itm => itm.Product);

        private static string AssemblyCopyright { get; }
            = GetValueFromAssembly<AssemblyCopyrightAttribute>(itm => itm.Copyright);

        private static string AssemblyCompany { get; }
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