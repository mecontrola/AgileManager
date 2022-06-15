using Stefanini.Core.Extensions;
using Stefanini.ViaReport.Core.Business;
using Stefanini.ViaReport.Data.Dtos;
using Stefanini.ViaReport.Extensions;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Stefanini.ViaReport
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
            => await settingsBusiness.SavePreferencesAsync(GetPersistFilterValue(), cancellationTokenSource.Token);

        private bool GetPersistFilterValue()
            => cbPersistFilter.IsChecked ?? false;

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
            var parentForm = (MainWindow)GetWindow(Owner);
            await parentForm.LoadCbProjects();
        }
    }
}