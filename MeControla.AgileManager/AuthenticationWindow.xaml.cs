using MeControla.AgileManager.Core.Business;
using System.Threading;
using System.Windows;

namespace MeControla.AgileManager
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

            txtUrl.Text = settings.Url;
            txtUsername.Text = settings.Username;
            txtPassword.Password = settings.Password;
        }

        private async void BtnAuthenticate_Click(object sender, RoutedEventArgs e)
        {
            await settingsBusiness.SaveAuthenticationAsync(txtUrl.Text, txtUsername.Text, txtPassword.Password, cancellationTokenSource.Token);

            var parentForm = (MainWindow)GetWindow(Owner);
            await parentForm.CheckJiraAuth();
        }
    }
}