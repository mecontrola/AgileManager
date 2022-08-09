using MeControla.AgileManager.Updater.Core.Data.Configurations;
using MeControla.AgileManager.Updater.Core.Services;
using MeControla.AgileManager.Updater.Extensions;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;

namespace MeControla.AgileManager.Updater
{
    public partial class MainWindow : Window
    {
        private readonly CancellationTokenSource cancellationTokenSource = new();

        private readonly IUpdaterConfiguration updaterConfiguration;
        private readonly IManagerUpdateService managerUpdateService;

        public MainWindow(IUpdaterConfiguration updaterConfiguration,
                          IManagerUpdateService managerUpdateService)
        {
            this.updaterConfiguration = updaterConfiguration;
            this.managerUpdateService = managerUpdateService;

            this.HideIcon();

            InitializeComponent();
        }

        private async void Window_ContentRendered(object sender, EventArgs e)
        {
            await managerUpdateService.CheckAndDownloadUpdate(text => UpdateStatus(text),
                                                              (show, percent) => UpdateProgressBar(show, percent),
                                                              cancellationTokenSource.Token);

            if (File.Exists(updaterConfiguration.ApplicationName))
                Process.Start(updaterConfiguration.ApplicationName);

            Close();
        }

        private void UpdateStatus(string text)
            => LbStatus.Content = text;

        private void UpdateProgressBar(bool show, long percent)
        {
            PbProgress.Visibility = show ? Visibility.Visible : Visibility.Hidden;

            if (!show)
                return;

            PbProgress.Value = percent;
        }
    }
}