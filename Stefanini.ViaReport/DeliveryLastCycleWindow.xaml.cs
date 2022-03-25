using Microsoft.Win32;
using Stefanini.Core.Extensions;
using Stefanini.ViaReport.Core.Data.Dto;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace Stefanini.ViaReport
{
    public partial class DeliveryLastCycleWindow : Window
    {
        private const string DATETIME_FORMAT = "dd/MM/yyyy";
        private const string DECIMAL_FORMAT = "0.00d";
        private const string DIALOG_FILTER = "JSON File|*.json";
        private const string DIALOG_TITLE = "Save as";
        private const string MESSAGE_BOX_TITLE = "Information";
        private const string MESSAGE_BOX_TEXT = "File saved sucess!";

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
            TxtLeadTimeAverage.Content = Data.LeadTimeAverage.ToString(DECIMAL_FORMAT);

            FillDataGrid(DgInformation, dgInformationDataCollection, Data.Issues);
        }

        private static void FillDataGrid(DataGrid grid, ICollection<DeliveryLastCycleIssueDto> collection, IList<DeliveryLastCycleIssueDto> items)
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
    }
}