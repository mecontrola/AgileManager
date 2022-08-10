using MeControla.AgileManager.Core.Business;
using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.Extensions;
using MeControla.Kernel.Extensions;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MeControla.AgileManager
{
    public partial class PreferencesWindow : Window
    {
        private static readonly string[] PROPERTY_GROUP_DESCRIPTION_CATEGORY_NAME = new string[] { "Category.Name" };

        private readonly CancellationTokenSource cancellationTokenSource;
        private readonly ObservableCollection<ProjectDto> projectsAvaliableDataCollection;
        private readonly ObservableCollection<ProjectDto> projectsSelectedDataCollection;

        private readonly ISettingsBusiness settingsBusiness;

        private readonly IProjectBusiness projecyBusiness;

        public PreferencesWindow(CancellationTokenSource cancellationTokenSource,
                                 ISettingsBusiness settingsBusiness,
                                 IProjectBusiness projecyBusiness)
        {
            this.cancellationTokenSource = cancellationTokenSource;
            this.projecyBusiness = projecyBusiness;
            this.settingsBusiness = settingsBusiness;

            projectsAvaliableDataCollection = new ObservableCollection<ProjectDto>();
            projectsSelectedDataCollection = new ObservableCollection<ProjectDto>();

            InitializeComponent();
            InitializeData();
        }

        private async void InitializeData()
        {
            await LoadSettingsData();
            await LoadProjectsData();
        }

        private async Task LoadSettingsData()
        {
            var settings = await settingsBusiness.LoadDataAsync(cancellationTokenSource.Token);

            cbPersistFilter.IsChecked = settings.PersistFilter;
            cbSyncAllData.IsChecked = settings.SyncAllData;
            txtCache.Text = settings.Cache.ToString();
        }

        private async Task LoadProjectsData()
        {
            var projects = await projecyBusiness.ListAllWithCategoryAsync(cancellationTokenSource.Token);

            var projectsAvaliable = projects.Where(itm => !itm.Selected);
            var projectsSelected = projects.Where(itm => itm.Selected);

            projectsAvaliableDataCollection.AddList(projectsAvaliable);
            projectsSelectedDataCollection.AddList(projectsSelected);

            LbProjectsAvaliable.Fill(projectsAvaliableDataCollection, PROPERTY_GROUP_DESCRIPTION_CATEGORY_NAME);
            LbProjectsSelected.Fill(projectsSelectedDataCollection, PROPERTY_GROUP_DESCRIPTION_CATEGORY_NAME);
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            await SaveSettingsChange();
            await SaveProjectsChange();

            await ReloadProjectList();

            Close();
        }

        private async Task SaveSettingsChange()
            => await settingsBusiness.SavePreferencesAsync(GetPersistFilterValue(), GetSyncAllDataValue(), GetCacheValue(), cancellationTokenSource.Token);

        private bool GetPersistFilterValue()
            => cbPersistFilter.IsChecked ?? false;

        private bool GetSyncAllDataValue()
            => cbSyncAllData.IsChecked ?? false;

        private int GetCacheValue()
            => int.Parse(txtCache.Text);

        private async Task SaveProjectsChange()
        {
            var projectIds = LbProjectsSelected.ToListData<ProjectDto>()
                                               .Select(itm => itm.Id)
                                               .ToArray();

            await projecyBusiness.SetSelectedByIdAsync(projectIds, cancellationTokenSource.Token);
        }

        private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var parent = (ListBox)sender;

            var data = parent.GetData(e.GetPosition(parent));
            if (data != null)
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            var data = (ProjectDto)e.Data.GetData(typeof(ProjectDto));

            if (projectsAvaliableDataCollection.Contains(data))
            {
                projectsAvaliableDataCollection.Remove(data);
                projectsSelectedDataCollection.Add(data);
            }
            else
            {
                projectsAvaliableDataCollection.Add(data);
                projectsSelectedDataCollection.Remove(data);
            }
        }

        private async Task ReloadProjectList()
        {
            var data = await settingsBusiness.LoadDataAsync(cancellationTokenSource.Token);

            var parentForm = (MainWindow)GetWindow(Owner);
            await parentForm.LoadCbProjects(data.FilterData);
        }

        private void TxtCache_PreviewTextInput(object sender, TextCompositionEventArgs e)
            => e.Handled = IsNumericAllowed(e.Text);

        private static bool IsNumericAllowed(string text)
            => Regex.IsMatch(text, "[^0-9.-]+");
    }
}