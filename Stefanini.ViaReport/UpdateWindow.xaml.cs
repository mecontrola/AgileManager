using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Info = Stefanini.ViaReport.Helpers.AssemblyInfoHelper;

namespace Stefanini.ViaReport
{
    public partial class UpdateWindow : Window
    {
        public UpdateWindow()
        {
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

        }

        private void RunCheck()
        {
            Thread.SpinWait(50000);

            var hasUpdate = true;

            ChangeVisiblePanelWhenUpdateAvailable(hasUpdate);
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