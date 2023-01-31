using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.Extensions;
using MeControla.Core.Extensions;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MeControla.AgileManager
{
    public partial class DeployWindow : Window
    {
        private const string DIALOG_FILTER = "CSV File|*.csv";
        private const string DIALOG_TITLE = "Save as";
        private const string MESSAGE_BOX_TITLE = "Information";
        private const string MESSAGE_BOX_TEXT = "File saved sucess!";

        private readonly ObservableCollection<DataCheck<IssueDeployDto>> deployDataCollection = new();

        private ICollectionView deployDataView;
        private bool isFilterByCheck = false;

        private IList<IssueDeployDto> Data { get; set; }

        public DeployWindow()
            => InitializeComponent();

        private void Window_Loaded(object sender, RoutedEventArgs e)
            => FillWindow();

        public void FillWindow()
        {
            Data = LoadData();

            var list = Data.Select(x =>
            {
                x.Environment = FormatEnvironmentExport(x.Environment);
                return new DataCheck<IssueDeployDto>
                {
                    Value = x,
                    IsEnabled = !x.DeployedIn.HasValue
                };
            }).ToList();

            DgIssueDeploy.Fill(deployDataCollection, list);

            deployDataView = CollectionViewSource.GetDefaultView(deployDataCollection);
            deployDataView.Filter = o => isFilterByCheck
                                       ? !((DataCheck<IssueDeployDto>)o).Value.DeployedIn.HasValue
                                       : true;
        }

        private void ButtonDeploy_Click(object sender, RoutedEventArgs e)
        {
            var items = DgIssueDeploy.ItemsSource
                                     .Cast<DataCheck<IssueDeployDto>>()
                                     .Where(x => x.IsChecked)
                                     .Select(x => x.Value)
                                     .ToList();

            var item = DgIssueDeploy.SelectedItem as DataCheck<IssueDeployDto>;
            if (item != null && !items.Any(x => x.Key == item.Value.Key))
            {
                items.Add(item.Value);

                items = items.OrderByDescending(x => int.Parse(x.Key.OnlyNumbers())).ToList();
            }

            var window = new DeployFormWindow();
            window.Owner = GetWindow(this);
            window.SetDataColletion(items);
            window.SetButtonSave = ButtonSave;
            window.Closed += WindowDeployForm_Closed;
            window.ShowDialog();
        }

        private void WindowDeployForm_Closed(object sender, EventArgs e)
            => FillWindow();

        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = DIALOG_FILTER,
                Title = DIALOG_TITLE
            };
            saveFileDialog.ShowDialog();

            if (string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                return;

            var data = "Key;Summary;Finished In;Services;Deployed In;Environment\n";
            data += string.Join("\n", Data.Select(x => FormatExport(x)));

            File.WriteAllText(saveFileDialog.FileName, data, Encoding.UTF8);

            MessageBox.Show(MESSAGE_BOX_TEXT, MESSAGE_BOX_TITLE, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private static string FormatExport(IssueDeployDto value)
            => string.Join(";", new string[]
            {
                value.Key,
                FormatSummaryExport(value.Summary),
                FormatDateTimeExport(value.FinishedIn),
                value.Services,
                FormatDateTimeExport(value.DeployedIn),
                FormatEnvironmentExport(value.Environment)
            });

        private static string FormatSummaryExport(string value)
            => value.Trim();

        private static string FormatDateTimeExport(DateTime? value)
            => value.HasValue ? FormatDateTimeExport(value) : "TBD";

        private static string FormatDateTimeExport(DateTime value)
            => $"{value:dd/MM/yyyy}";

        private static string FormatEnvironmentExport(string value)
            => value.Contains("bug", StringComparison.InvariantCultureIgnoreCase)
             ? string.Join("|", value.Split("|").Where(x => !x.Contains("Bug")))
             : value;

        private void ButtonOnlyNoDeployed_Click(object sender, RoutedEventArgs e)
        {
            isFilterByCheck = (sender as CheckBox).IsChecked ?? false;

            deployDataView.Refresh();
        }

        public Action<IList<IssueDeployDto>> ButtonSave { get; set; }
        public Func<IList<IssueDeployDto>> LoadData { get; set; }
    }

    internal class DataCheck<T>
        where T : class
    {
        public bool IsChecked { get; set; } = false;
        public bool IsEnabled { get; set; } = true;
        public T Value { get; set; }
    }
}