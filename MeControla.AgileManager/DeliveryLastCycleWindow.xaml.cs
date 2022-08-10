using MeControla.AgileManager.Data.Dtos;
using MeControla.Kernel.Extensions;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MeControla.AgileManager
{
    public partial class DeliveryLastCycleWindow : Window
    {
        private const string DATETIME_FORMAT = "dd/MM/yyyy";
        private const string DECIMAL_DAYS_FORMAT = "0d";
        private const string DECIMAL_FORMAT = "0.00%";
        private const string DIALOG_FILTER = "JSON File|*.json";
        private const string DIALOG_TITLE = "Save as";
        private const string MESSAGE_BOX_TITLE = "Information";
        private const string MESSAGE_BOX_TEXT = "File saved sucess!";

        private readonly ObservableCollection<DeliveryLastCycleEpicDto> dgEpicDataCollection = new();
        private readonly ObservableCollection<DeliveryLastCycleImpedimentDto> dgImpedimentDataCollection = new();
        private readonly ObservableCollection<DeliveryLastCycleIssueDto> dgInformationDataCollection = new();

        private DeliveryLastCycleDto Data { get; set; }

        public DeliveryLastCycleWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
            => FillWindow();

        public void SetDataColletion(DeliveryLastCycleDto data)
            => Data = data;

        public void FillWindow()
        {
            TxtStartDate.Content = Data.StartDate.ToString(DATETIME_FORMAT);
            TxtEndtDate.Content = Data.EndDate.ToString(DATETIME_FORMAT);
            TxtThroughtput.Content = Data.Throughtput;
            TxtCustomerLeadTimeAverage.Content = Data.CustomerLeadTimeAverage.ToString(DECIMAL_DAYS_FORMAT);
            TxtDiscoveryLeadTimeAverage.Content = Data.DiscoveryLeadTimeAverage.ToString(DECIMAL_DAYS_FORMAT);
            TxtSystemLeadTimeAverage.Content = Data.SystemLeadTimeAverage.ToString(DECIMAL_DAYS_FORMAT);
            TxtTotalFeature.Content = $"{Data.FeaturePercent.ToString(DECIMAL_FORMAT)} ({Data.Feature})";
            TxtTotalDebits.Content = $"{Data.DebitsPercent.ToString(DECIMAL_FORMAT)} ({Data.Debits})";
            TxtQuarterAveragePercentage.Content = $"{Data.QuarterAveragePercentage}%";

            FillDataGrid(DgEpic, dgEpicDataCollection, Data.Epics);
            FillDataGrid(DgImpediment, dgImpedimentDataCollection, Data.Impediments);
            FillDataGrid(DgInformation, dgInformationDataCollection, Data.Issues);
        }

        private static void FillDataGrid<TSource>(DataGrid grid, ICollection<TSource> collection, IList<TSource> items)
        {
            collection.Clear();
            collection.AddList(items);

            grid.ItemsSource = collection;
        }

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = DIALOG_FILTER,
                Title = DIALOG_TITLE
            };
            saveFileDialog1.ShowDialog();

            if (string.IsNullOrWhiteSpace(saveFileDialog1.FileName))
                return;

            var json = JsonSerializer.Serialize(Data);

            File.WriteAllText(saveFileDialog1.FileName, json);

            MessageBox.Show(MESSAGE_BOX_TEXT, MESSAGE_BOX_TITLE, MessageBoxButton.OK, MessageBoxImage.Information);
        }

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