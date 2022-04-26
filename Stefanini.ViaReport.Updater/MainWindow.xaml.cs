using Stefanini.ViaReport.Updater.Core.Data;
using Stefanini.ViaReport.Updater.Core.Data.Configurations;
using Stefanini.ViaReport.Updater.Core.Services;
using Stefanini.ViaReport.Updater.Extensions;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace Stefanini.ViaReport.Updater
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