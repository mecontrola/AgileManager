using MeControla.AgileManager.Data.Dtos;
using MeControla.Core.Extensions;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        //private const string DIALOG_FILTER = "JSON File|*.json";
        private const string DIALOG_FILTER = "CSV File|*.csv";
        private const string DIALOG_TITLE = "Save as";
        private const string MESSAGE_BOX_TITLE = "Information";
        private const string MESSAGE_BOX_TEXT = "File saved sucess!";

        private readonly ObservableCollection<DeliveryLastCycleEpicDto> dgEpicDataCollection = new();
        private readonly ObservableCollection<DeliveryLastCycleImpedimentDto> dgImpedimentDataCollection = new();
        private readonly ObservableCollection<DeliveryLastCycleIssueDeliveryDto> dgIssueDeliveryDataCollection = new();
        private readonly ObservableCollection<DeliveryLastCycleIssueInProgressDto> dgIssueInProgressDataCollection = new();
        private readonly ObservableCollection<DeliveryLastCycleCycleTimeDto> dgCycleTimeDataCollection = new();

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
            TxtThroughtputStoryPoint.Content = Data.ThroughtputStoryPoints;
            TxtCustomerLeadTimeAverage.Content = Data.CustomerLeadTimeAverage.ToString(DECIMAL_DAYS_FORMAT);
            TxtDiscoveryLeadTimeAverage.Content = Data.DiscoveryLeadTimeAverage.ToString(DECIMAL_DAYS_FORMAT);
            TxtSystemLeadTimeAverage.Content = Data.SystemLeadTimeAverage.ToString(DECIMAL_DAYS_FORMAT);
            TxtTotalFeature.Content = $"{Data.FeaturePercent.ToString(DECIMAL_FORMAT)} ({Data.Feature})";
            TxtTotalDebits.Content = $"{Data.DebitsPercent.ToString(DECIMAL_FORMAT)} ({Data.Debits})";
            TxtTotalStandard.Content = $"{Data.StandardPercent.ToString(DECIMAL_FORMAT)} ({Data.Standard})";
            TxtTotalExpedite.Content = $"{Data.ExpeditePercent.ToString(DECIMAL_FORMAT)} ({Data.Expedite})";
            TxtTotalFixedDate.Content = $"{Data.FixedDatePercent.ToString(DECIMAL_FORMAT)} ({Data.FixedDate})";
            TxtTotalIntangible.Content = $"{Data.IntangiblePercent.ToString(DECIMAL_FORMAT)} ({Data.Intangible})";
            TxtQuarterAveragePercentage.Content = $"{Data.QuarterAveragePercentage}%";

            FillDataGrid(DgEpic, dgEpicDataCollection, Data.Epics);
            FillDataGrid(DgImpediment, dgImpedimentDataCollection, Data.Impediments);
            FillDataGrid(DgIssueDelivery, dgIssueDeliveryDataCollection, Data.IssuesDelivery);
            FillDataGrid(DgIssueInProgress, dgIssueInProgressDataCollection, Data.IssuesInProgress);
            FillDataGrid(DgCycleTime, dgCycleTimeDataCollection, Data.CycleTime);
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


            var data = "Issue;Summary;Environment;Status;Issue Type;Class Of Service;Age;Story Points;Completion Estimate;Impeded;Incident\n";
            data += string.Join("\n", Data.IssuesInProgress.OrderBy(x => x.Key).Select(x => $"{x.Key};{x.Description.Trim()};{x.Labels};{x.Status};{x.IssueType};{x.ClassOfService};{x.Age};{x.StoryPoints};{x.EstimateStr};{(x.Impediment ? "Yes" : "No")};{(x.IsIncident ? "Yes" : "No")}"));
            data += "\nIssue;Summary;System Lead Time\n";
            data += string.Join("\n", Data.IssuesDelivery.OrderBy(x => x.Key).Select(x => $"{x.Key};{x.Description.Trim()};{x.SystemLeadTime}"));

            File.WriteAllText(saveFileDialog1.FileName, data);

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