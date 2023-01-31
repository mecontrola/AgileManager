using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace MeControla.AgileManager
{
    public partial class DeployFormWindow : Window
    {
        private readonly ObservableCollection<IssueDeployDto> deployDataCollection = new();

        public event EventHandler ButtonSave;

        private IList<IssueDeployDto> Data { get; set; }
        public Action<IList<IssueDeployDto>> SetButtonSave { get; set; }

        public DeployFormWindow()
            => InitializeComponent();

        public void SetDataColletion(IList<IssueDeployDto> data)
            => Data = data;

        private void Window_Loaded(object sender, RoutedEventArgs e)
            => FillWindow();

        public void FillWindow()
            => DgIssueDeploy.Fill(deployDataCollection, Data);

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var items = DgIssueDeploy.ItemsSource
                                     .Cast<IssueDeployDto>()
                                     .Select(x => FillDataToSave(x, DpDeployedIn.SelectedDate))
                                     .ToList();

            SetButtonSave?.Invoke(items);

            Close();
        }

        private IssueDeployDto FillDataToSave(IssueDeployDto x, DateTime? selectedDate)
        {
            x.DeployedIn = selectedDate;

            return x;
        }
    }
}