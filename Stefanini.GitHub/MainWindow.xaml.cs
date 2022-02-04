using Stefanini.Core.Extensions;
using Stefanini.Core.Settings;
using Stefanini.GitHub.Core.Data.Dto;
using Stefanini.GitHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stefanini.GitHub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string SETTINGS_FILENAME = "usersettings.json";

        private readonly CancellationTokenSource cancellationTokenSource;
        private readonly SettingsManager<UserSettings> settingsManager;
        private readonly ObservableCollection<IssueDto> dgDataCollection;

        private readonly IFindGitHubPullRequestsOpenService findGitHubPullRequestsOpenService;

        public MainWindow(IFindGitHubPullRequestsOpenService findGitHubPullRequestsOpenService)
        {
            this.findGitHubPullRequestsOpenService = findGitHubPullRequestsOpenService;

            cancellationTokenSource = new CancellationTokenSource();
            settingsManager = new SettingsManager<UserSettings>(SETTINGS_FILENAME);
            dgDataCollection = new ObservableCollection<IssueDto>();

            InitializeComponent();
            _ = InitializeData();
        }

        private async Task InitializeData()
        {
            TxtUsername.Text = settingsManager.Data.Username;
            TxtPassword.Password = settingsManager.Data.Password.Base64Decode();
        }

        private bool savedFile = false;
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!savedFile)
            {
                settingsManager.Data.Username = TxtUsername.Text;
                settingsManager.Data.Password = TxtPassword.Password.Base64Encode();
                settingsManager.SaveSettings();
                savedFile = true;
            }

            base.OnClosed(e);
        }

        private async void BtnExecute_Click(object sender, RoutedEventArgs e)
        {
            var querys = new Dictionary<string,string>
            {
                { "Android", "repo:viavarejo-internal/vv-viaunica-android+is:pr+state:open+in:title SEA" },
                { "iOS", "repo:viavarejo-internal/vv-viaunica-ios+is:pr+state:open+in:title SEA" }
            };
            var items = new List<IssueDto>();

            foreach (var query in querys)
            {
                var data = await findGitHubPullRequestsOpenService.Execute(TxtUsername.Text, TxtPassword.Password, query.Value, cancellationTokenSource.Token);
                data = data.Select(x =>
                {
                    x.Stack = query.Key;
                    return x;
                }).ToList();

                items.AddRange(data);
            }
            dgDataCollection.AddList(items);

            dgData.ItemsSource = dgDataCollection;
        }

        private void DgDataHyperlink_Click(object sender, RoutedEventArgs e)
        {
            var link = (Hyperlink)e.OriginalSource;
            Process.Start(link.NavigateUri.AbsoluteUri);
        }
    }
}