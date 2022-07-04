using Stefanini.ViaReport.Core.Business;
using System.Threading;
using System.Windows;

namespace Stefanini.ViaReport
{
    public partial class AuthenticationWindow : Window
    {
        private readonly CancellationTokenSource cancellationTokenSource;

        private readonly ISettingsBusiness settingsBusiness;

        public AuthenticationWindow(CancellationTokenSource cancellationTokenSource,
                                    ISettingsBusiness settingsBusiness)
        {
            this.cancellationTokenSource = cancellationTokenSource;
            this.settingsBusiness = settingsBusiness;

            InitializeComponent();
            InitializeData();
        }

        private async void InitializeData()
        {
            var settings = await settingsBusiness.LoadDataAsync(cancellationTokenSource.Token);

            txtUsername.Text = settings.Username;
            txtPassword.Password = settings.Password;
        }

        private async void BtnAuthenticate_Click(object sender, RoutedEventArgs e)
        {
            await settingsBusiness.SaveAuthenticationAsync(txtUsername.Text, txtPassword.Password, cancellationTokenSource.Token);

            var parentForm = (MainWindow)GetWindow(Owner);
            await parentForm.CheckJiraAuth();
        }
    }
}