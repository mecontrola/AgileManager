using System.Windows;
using Info = Stefanini.ViaReport.Helpers.AssemblyInfoHelper;

namespace Stefanini.ViaReport
{
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();

            LbTitle.Content = $"About {Info.AssemblyTitle}";
            LbProductName.Content = Info.AssemblyProduct;
            LbVersion.Content = $"Version {Info.AssemblyVersion}";
            LbCopyright.Content = Info.AssemblyCopyright;
            LbCompany.Content = Info.AssemblyCompany;
            TxtDescription.Text = Info.AssemblyDescription;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
            => Close();
    }
}