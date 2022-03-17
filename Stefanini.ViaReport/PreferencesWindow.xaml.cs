using Stefanini.ViaReport.Core.Data.Dto.Settings;
using Stefanini.ViaReport.Core.Helpers;
using System.Windows;

namespace Stefanini.ViaReport
{
    public partial class PreferencesWindow : Window
    {
        private readonly ISettingsHelper settingsHelper;

        public PreferencesWindow(ISettingsHelper settingsHelper)
        {
            this.settingsHelper = settingsHelper;

            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            cbPersistFilter.IsChecked = settingsHelper.Data.PersistFilter;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            settingsHelper.Data = new AppSettingsDto
            {
                Username = settingsHelper.Data.Username,
                Password = settingsHelper.Data.Password,
                PersistFilter = cbPersistFilter.IsChecked ?? false
            };
            settingsHelper.Save();
        }
    }
}