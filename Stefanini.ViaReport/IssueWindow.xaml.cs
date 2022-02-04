using Stefanini.Core.Extensions;
using Stefanini.ViaReport.Core.Data.Dto;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;

namespace Stefanini.ViaReport
{
    public partial class IssueWindow : Window
    {
        private const string PREFIX_TITLE = "Issues: ";

        private readonly ObservableCollection<IssueInfoDto> dgDataCollection;

        public IssueWindow()
        {
            dgDataCollection = new ObservableCollection<IssueInfoDto>();

            InitializeComponent();
        }

        public string DefineTitle(string title)
            => Title = $"{PREFIX_TITLE}{title}";

        public void SetDataColletion(IList<IssueInfoDto> data)
        {
            dgDataCollection.Clear();
            dgDataCollection.AddList(data);

            DgData.ItemsSource = dgDataCollection;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
            => Close();

        private void DgDataColumnLink_Click(object sender, RoutedEventArgs e)
        {
            var link = (Hyperlink)e.OriginalSource;

            var psi = new ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = link.NavigateUri.AbsoluteUri;
            Process.Start(psi);
        }
    }
}