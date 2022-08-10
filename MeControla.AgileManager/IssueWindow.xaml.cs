using MeControla.Kernel.Extensions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;

namespace MeControla.AgileManager
{
    public partial class IssueWindow : Window
    {
        private const string PREFIX_TITLE = "Issues: ";

        private readonly ObservableCollection<Data.Dtos.IssueDto> dgDataCollection;

        public IssueWindow()
        {
            dgDataCollection = new ObservableCollection<Data.Dtos.IssueDto>();

            InitializeComponent();
        }

        public string DefineTitle(string title)
            => Title = $"{PREFIX_TITLE}{title}";

        public void SetDataColletion(IList<Data.Dtos.IssueDto> data)
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

            var psi = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = link.NavigateUri.AbsoluteUri
            };
            Process.Start(psi);
        }
    }
}