using Stefanini.Core.Extensions;
using Stefanini.ViaReport.Core.Business;
using Stefanini.ViaReport.Core.Data.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Stefanini.ViaReport
{
    public partial class DashboardWindow : Window
    {
        private readonly ObservableCollection<DashboardInfoItemDto> dgThroughputDataCollection = new();
        private readonly ObservableCollection<DashboardInfoItemDto> dgLeadTimeDataCollection = new();
        private readonly ObservableCollection<DashboardInfoItemDto> dgCycleTimeDataCollection = new();
        private readonly ObservableCollection<DashboardInfoItemDto> dgQuarterEpicsDataCollection = new();

        public DashboardWindow()
        {
            InitializeComponent();
        }

        public void SetDataColletion(DashboardDto data)
        {
            FillDataGrid(DgThroughput, dgThroughputDataCollection, data.Throughput.Items);
            //FillDataGrid(dgLeadTimeDataCollection, data.LeadTime.Items);
            //FillDataGrid(dgCycleTimeDataCollection, data.CycleTime.Items);
            //FillDataGrid(dgQuarterEpicsDataCollection, data.QuarterEpics.Items);

            //dgThroughputDataCollection.Clear();
            //dgThroughputDataCollection.AddList(data.Throughput.Items);
            //
            //DgThroughput.ItemsSource = dgThroughputDataCollection;
            //
            //dgLeadTimeDataCollection.Clear();
            //dgLeadTimeDataCollection.AddList(data.LeadTime.Items);
            //
            //DgLeadTime.ItemsSource = dgLeadTimeDataCollection;
            //
            //dgCycleTimeDataCollection.Clear();
            //dgCycleTimeDataCollection.AddList(data.CycleTime.Items);
            //
            //DgCycleTime.ItemsSource = dgCycleTimeDataCollection;
            //
            //dgQuarterEpicsDataCollection.Clear();
            //dgQuarterEpicsDataCollection.AddList(data.QuarterEpics.Items);
            //
            //DgQuarterEpics.ItemsSource = dgQuarterEpicsDataCollection;
        }

        private static void FillDataGrid(DataGrid grid, ICollection<DashboardInfoItemDto> collection, IList<DashboardInfoItemDto> items)
        {
            collection.Clear();
            collection.AddList(items);

            grid.ItemsSource = collection;
        }

        private void DgDataColumnLink_Click(object sender, RoutedEventArgs e)
        {
            var link = e.OriginalSource as Hyperlink;
            var item = link?.DataContext as DashboardInfoItemDto ?? new DashboardInfoItemDto();
            
            var window = new IssueWindow();
            window.DefineTitle("Detalhes");
            window.SetDataColletion(item.Issues);
            window.ShowDialog();
        }
    }
}