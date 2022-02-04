using Stefanini.Core.Extensions;
using Stefanini.Core.Settings;
using Stefanini.ViaReport.Core.Helpers;
using System.Threading.Tasks;
using System.Windows;

namespace Stefanini.ViaReport
{
    public partial class AuthenticationWindow : Window
    {
        private readonly ISettingsHelper settingsHelper;

        public AuthenticationWindow(ISettingsHelper settingsHelper)
        {
            this.settingsHelper = settingsHelper;

            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            txtUsername.Text = settingsHelper.Data.Username;
            txtPassword.Password = settingsHelper.Data.Password;
        }

        private async void BtnAuthenticate_Click(object sender, RoutedEventArgs e)
        {
            settingsHelper.Data = new UserSettings
            {
                Username = txtUsername.Text,
                Password = txtPassword.Password

            };
            settingsHelper.Save();

            var parentForm = (MainWindow)GetWindow(Owner);    
            await parentForm.CheckJiraAuth();
        }
    }
}