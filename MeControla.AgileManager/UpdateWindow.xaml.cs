using MeControla.AgileManager.Updater.Core.Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Info = MeControla.AgileManager.Helpers.AssemblyInfoHelper;

namespace MeControla.AgileManager
{
    public partial class UpdateWindow : Window
    {
        private const string UPDATER_FILENAME = "updater.exe";
        private const string MESSAGEBOX_UPDATER_NOTFOUND_TITLE = "Error";
        private const string MESSAGEBOX_UPDATER_NOTFOUND_DESCRIPTION = "It is impossible to update at the moment. Please try again later.";

        private readonly CancellationTokenSource cancellationTokenSource;

        private readonly IRemoteVersionHelper remoteVersionHelper;

        public UpdateWindow(IRemoteVersionHelper remoteVersionHelper)
        {
            this.remoteVersionHelper = remoteVersionHelper;

            cancellationTokenSource = new CancellationTokenSource();

            InitializeComponent();
            InitializeData();

            Dispatcher.BeginInvoke(DispatcherPriority.Background, RunCheck);
        }

        private void InitializeData()
        {
            LbCurrent.Content = Info.AssemblyVersion;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(UPDATER_FILENAME))
            {
                MessageBox.Show(MESSAGEBOX_UPDATER_NOTFOUND_DESCRIPTION, MESSAGEBOX_UPDATER_NOTFOUND_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Process.Start(UPDATER_FILENAME);
        }

        private async void RunCheck()
        {
            var version = await remoteVersionHelper.GetVersion(cancellationTokenSource.Token);

            LbAvaliable.Content = version;

            ChangeVisiblePanelWhenUpdateAvailable(IsUpdateAvaliable());
        }

        private bool IsUpdateAvaliable()
        {
            var current = Version.Parse(LbCurrent.Content.ToString());
            var avaliable = Version.Parse(LbAvaliable.Content.ToString());
            return avaliable > current;
        }

        private void ChangeVisiblePanelWhenUpdateAvailable(bool hasUpdate)
        {
            PnLoad.Visibility = Visibility.Hidden;
            PnUpdated.Visibility = !hasUpdate
                                 ? Visibility.Visible
                                 : Visibility.Hidden;
            PnAvaliable.Visibility = hasUpdate
                                 ? Visibility.Visible
                                 : Visibility.Hidden;
        }
    }
}