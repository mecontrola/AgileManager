using Microsoft.Win32;
using Stefanini.Core.Extensions;
using Stefanini.Core.Settings;
using Stefanini.ViaReport.Core.Business;
using Stefanini.ViaReport.Core.Data.Configurations;
using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Dto.Settings;
using Stefanini.ViaReport.Core.Exceptions;
using Stefanini.ViaReport.Core.Extensions;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Helpers;
using Stefanini.ViaReport.Updater.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Windows.UI.Notifications;
using Info = Stefanini.ViaReport.Helpers.AssemblyInfoHelper;

namespace Stefanini.ViaReport
{
    public partial class MainWindow : Window
    {
        public const string APP_TITLE = "[Jira] EasyBI AHM";

        private const string PATH_IMAGE_CHECK_OK = "Images/sign_check_icon.png";
        private const string PATH_IMAGE_CHECK_FAIL = "Images/sign_error_icon.png";
        private const string PATH_IMAGE_NEW_RELEASE = "Images/new_release_icon-48.png";
        private const string DEFAULT_COMBOBOX_ITEM_NAME = "Select item";

        private const int DEFAULT_COMBOBOX_ITEM_ID = 0;
        private const int TIME_CHECK_UPDATE_30_MINUTES = 30;

        private readonly CancellationTokenSource cancellationTokenSource;
        private readonly ObservableCollection<AHMInfoDto> dgDataCollection;
        private readonly PeriodicTimer timer = new(TimeSpan.FromMinutes(TIME_CHECK_UPDATE_30_MINUTES));

        private readonly IApplicationConfiguration applicationConfiguration;

        private readonly IDashboardBusiness dashboardBusiness;
        private readonly IFixVersionBusiness fixVersionBusiness;
        private readonly IDownstreamJiraIndicatorsBusiness downstreamJiraIndicatorsBusiness;
        private readonly IUpstreamDownstreamRateBusiness upstreamDownstreamRateBusiness;

        private readonly IJiraAuthService jiraAuthService;
        private readonly IJiraProjectsService jiraProjectsService;

        private readonly ISettingsHelper settingsHelper;
        private readonly IAverageUpstreamDownstreamRateHelper averageUpstreamDownstreamRateHelper;
        private readonly IQuarterGenerateListHelper quarterGenerateListHelper;
        private readonly IDateTimeFromStringHelper dateTimeFromStringHelper;
        private readonly IRemoteVersionHelper remoteVersionHelper;

        private readonly IUpdateToastHelper updateToastHelper;

        private readonly ImageSource imageAuthCheck;
        private readonly ImageSource imageAuthError;

        private DownstreamJiraIndicatorsDto downstreamJiraIndicatorsDto = new();

        public MainWindow(IApplicationConfiguration applicationConfiguration,
                          IDashboardBusiness dashboardBusiness,
                          IFixVersionBusiness fixVersionBusiness,
                          IDownstreamJiraIndicatorsBusiness downstreamJiraIndicatorsBusiness,
                          IUpstreamDownstreamRateBusiness upstreamDownstreamRateBusiness,
                          IJiraAuthService jiraAuthService,
                          IJiraProjectsService jiraProjectsService,
                          ISettingsHelper settingsHelper,
                          IAverageUpstreamDownstreamRateHelper averageUpstreamDownstreamRateHelper,
                          IQuarterGenerateListHelper quarterGenerateListHelper,
                          IDateTimeFromStringHelper dateTimeFromStringHelper,
                          IUpdateToastHelper updateToastHelper,
                          IRemoteVersionHelper remoteVersionHelper)
        {
            this.applicationConfiguration = applicationConfiguration;
            this.dashboardBusiness = dashboardBusiness;
            this.fixVersionBusiness = fixVersionBusiness;
            this.downstreamJiraIndicatorsBusiness = downstreamJiraIndicatorsBusiness;
            this.upstreamDownstreamRateBusiness = upstreamDownstreamRateBusiness;
            this.jiraAuthService = jiraAuthService;
            this.jiraProjectsService = jiraProjectsService;
            this.settingsHelper = settingsHelper;
            this.averageUpstreamDownstreamRateHelper = averageUpstreamDownstreamRateHelper;
            this.quarterGenerateListHelper = quarterGenerateListHelper;
            this.dateTimeFromStringHelper = dateTimeFromStringHelper;
            this.updateToastHelper = updateToastHelper;
            this.remoteVersionHelper = remoteVersionHelper;

            cancellationTokenSource = new CancellationTokenSource();
            dgDataCollection = new ObservableCollection<AHMInfoDto>();

            imageAuthCheck = GetImageSource(PATH_IMAGE_CHECK_OK);
            imageAuthError = GetImageSource(PATH_IMAGE_CHECK_FAIL);

            InitializeComponent();
            _ = InitializeData();

            CheckUpdate();
        }

        private async Task InitializeData()
        {
            await CheckJiraAuth();

            MiTools.IsEnabled = applicationConfiguration.ShowTools;

            FillFilter();
        }

        public async Task CheckJiraAuth()
        {
            FormAuthenticateIsEnabled(false);

            if (string.IsNullOrWhiteSpace(settingsHelper.Data.Username) || string.IsNullOrWhiteSpace(settingsHelper.Data.Password))
            {
                return;
            }

            var isOk = await jiraAuthService.IsAuthenticationOk(settingsHelper.Data.Username,
                                                                settingsHelper.Data.Password,
                                                                cancellationTokenSource.Token);

            FormAuthenticateIsEnabled(isOk);

            if (!isOk)
            {
                MessageBox.Show("Não foi possível se autenticar com o Jira.É necessário informar o login para autenticação.");
                return;
            }

            await LoadCbProjects();

            LoadCbQuarters();
        }

        private void FillFilter()
        {
            if (!settingsHelper.Data.PersistFilter || settingsHelper.Data.FilterData == null)
                return;

            CbProjects.SelectedIndex = ProjectIndexOf(settingsHelper.Data.FilterData.Project);
            CbQuarters.SelectedItem = settingsHelper.Data.FilterData.Quarter;
            TxtInitDate.SelectedDate = settingsHelper.Data.FilterData.StartDate;
            TxtEndDate.SelectedDate = settingsHelper.Data.FilterData.EndDate;
        }

        private int ProjectIndexOf(JiraProjectDto project)
        {
            var list = ((CbProjects.ItemsSource as ListCollectionView)
                           .SourceCollection as IList<JiraProjectDto>);

            if (project == null)
                return -1;

            return list?.Select((value, index) => new { value, index })
                        .First(p => p.value.Category != null
                                 && p.value.Category.Equals(project.Category)
                                 && p.value.Name.Equals(project.Name))
                        .index
                ?? -1;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var filter = FillFilterData();
            if (filter == null)
                return;

            ChangePbStatusAndBtnExecute(false, true);
            try
            {
                var openFileDialog = new OpenFileDialog();

                if (openFileDialog.ShowDialog() == false)
                {
                    ChangePbStatusAndBtnExecute(true, true);
                    return;
                }

                var items = await upstreamDownstreamRateBusiness.GetData(openFileDialog.FileName, cancellationTokenSource.Token);

                dgDataCollection.AddList(items);

                dgData.ItemsSource = dgDataCollection;

                ChangePbStatusAndBtnExecute(true, true);
            }
            catch (JiraException ex)
            {
                MessageBox.Show(ex.Message, "Jira Error", MessageBoxButton.OK);
            }
        }

        private void ButtonAverage_Click(object sender, RoutedEventArgs e)
        {
            var items = dgData.ItemsSource.GetSelectedItems<AHMInfoDto>(itm => itm.IsChecked
                                                                            && itm.UpstreamDownstreamRate.HasValue);

            if (!items.Any())
            {
                MessageBox.Show("É necessário selecionar mais de um item na tabela.");
                return;
            }

            var upstreamDownstreamRate = averageUpstreamDownstreamRateHelper.Calculate(items);

            MessageBox.Show($"Upstream Downstream Rate: {upstreamDownstreamRate:P2}");
        }

        private void DgData_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var gridRow = e.Row;

            if (!typeof(AHMInfoDto).Equals(gridRow.DataContext.GetType()))
                return;

            var strDate = ((AHMInfoDto)gridRow.DataContext).Date;
            var date = dateTimeFromStringHelper.Convert(strDate);

            gridRow.Background = date.Month % 2 == 0
                               ? new SolidColorBrush(Colors.White)
                               : new SolidColorBrush(Colors.LightGray);
        }

        private async Task LoadCbProjects()
        {
            if (string.IsNullOrWhiteSpace(settingsHelper.Data.Username) || string.IsNullOrWhiteSpace(settingsHelper.Data.Password))
                return;

            var items = await jiraProjectsService.LoadList(settingsHelper.Data.Username,
                                                           settingsHelper.Data.Password,
                                                           cancellationTokenSource.Token);
            items.Insert(0, new JiraProjectDto { Name = DEFAULT_COMBOBOX_ITEM_NAME });

            var lcv = new ListCollectionView((System.Collections.IList)items);
            lcv.GroupDescriptions.Add(new PropertyGroupDescription("Category"));

            CbProjects.ItemsSource = lcv;
            CbProjects.IsEnabled = true;
        }

        private void LoadCbQuarters()
        {
            var items = quarterGenerateListHelper.Create(DateTime.Now);
            items.Insert(DEFAULT_COMBOBOX_ITEM_ID, DEFAULT_COMBOBOX_ITEM_NAME);

            var lcv = new ListCollectionView((System.Collections.IList)items);

            CbQuarters.ItemsSource = lcv;
            CbQuarters.IsEnabled = true;
        }

        private void ChangePbStatusAndBtnExecute(bool isEnabled)
            => ChangePbStatusAndBtnExecute(isEnabled, false);

        private void ChangePbStatusAndBtnExecute(bool isEnabled, bool isUpstreamAction)
        {
            ChangePbStatus(!isEnabled);

            BtnExecute.IsEnabled = isEnabled;
            BtnDownExecute.IsEnabled = isEnabled;
            BtnAverage.Visibility = isEnabled && isUpstreamAction
                                  ? Visibility.Visible
                                  : Visibility.Hidden;
            BtnBugsCreated.IsEnabled = isEnabled;
            BtnBugsOpened.IsEnabled = isEnabled;
            BtnBugsExisted.IsEnabled = isEnabled;
            BtnBugsResolved.IsEnabled = isEnabled;
            BtnBugsCreatedAndResolved.IsEnabled = isEnabled;
            BtnBugsCancelled.IsEnabled = isEnabled;
            BtnTechnicalDebitCreated.IsEnabled = isEnabled;
            BtnTechnicalDebitOpened.IsEnabled = isEnabled;
            BtnTechnicalDebitExisted.IsEnabled = isEnabled;
            BtnTechnicalDebitResolved.IsEnabled = isEnabled;
            BtnTechnicalDebitCreatedAndResolved.IsEnabled = isEnabled;
            BtnTechnicalDebitCancelled.IsEnabled = isEnabled;
            CbProjects.IsEnabled = isEnabled;
            CbQuarters.IsEnabled = isEnabled;
            TxtInitDate.IsEnabled = isEnabled;
            TxtEndDate.IsEnabled = isEnabled;
        }

        private void ChangePbStatus(bool isEnabled)
        {
            PbStatus.Visibility = isEnabled
                                ? Visibility.Visible
                                : Visibility.Hidden;
            PbStatus.IsIndeterminate = isEnabled;
        }

        private void FormAuthenticateIsEnabled(bool isEnabled)
        {
            AuthStatus.Source = isEnabled
                              ? imageAuthCheck
                              : imageAuthError;
            BtnExecute.IsEnabled = false;
        }

        private static ImageSource GetImageSource(string path)
        {
            var img = new BitmapImage();
            img.BeginInit();
            img.UriSource = CreateIconUri(path);
            img.EndInit();
            return img;
        }

        private static Uri CreateIconUri(string path)
            => new($"pack://application:,,,/{path}");

        private void CbProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => BtnExecute.IsEnabled = true;

        private void BtnAuthenticate_Click(object sender, RoutedEventArgs e)
            => OpenAuthenticationForm();

        private void OpenAuthenticationForm()
            => new AuthenticationWindow(settingsHelper)
            {
                Owner = GetWindow(this)
            }.ShowDialog();

        private void BtnPreferences_Click(object sender, RoutedEventArgs e)
            => OpenPreferencesForm();

        private void OpenPreferencesForm()
            => new PreferencesWindow(settingsHelper)
            {
                Owner = GetWindow(this)
            }.ShowDialog();

        private void BtnAbout_Click(object sender, RoutedEventArgs e)
            => OpenAboutForm();

        private void OpenAboutForm()
            => new AboutWindow
            {
                Owner = GetWindow(this)
            }.ShowDialog();

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
            => OpenUpdateForm();

        private void OpenUpdateForm()
            => new UpdateWindow(remoteVersionHelper)
            {
                Owner = GetWindow(this)
            }.ShowDialog();

        private async void CheckUpdate()
        {
            while (await timer.WaitForNextTickAsync())
            {
                var avaliable = await remoteVersionHelper.GetVersion(cancellationTokenSource.Token);
                var current = Version.Parse(Info.AssemblyVersion);

                if (avaliable > current)
                    updateToastHelper.Show(Toast_Activated);
            }
        }

        private void Toast_Activated(ToastNotification sender, object args)
            => Dispatcher.BeginInvoke(DispatcherPriority.Background, OpenUpdateForm);

        private async void BtnDownExecute_Click(object sender, RoutedEventArgs e)
        {
            var filter = FillFilterData();
            if (filter == null)
                return;

            ChangePbStatusAndBtnExecute(false);

            var data = await downstreamJiraIndicatorsBusiness.GetData(settingsHelper.Data.Username,
                                                                      settingsHelper.Data.Password,
                                                                      filter.Project.Name,
                                                                      filter.StartDate.Value,
                                                                      filter.EndDate.Value,
                                                                      cancellationTokenSource.Token);
            TxtCycleBalance.Content = $"{data.CycleBalance}%";
            TxtBugsCreated.Content = data.BugsCreated.Total;
            TxtBugsOpened.Content = data.BugsOpened.Total;
            TxtBugsExisted.Content = data.BugsExisted.Total;
            TxtBugsResolved.Content = data.BugsResolved.Total;
            TxtBugsCreatedAndResolved.Content = data.BugsCreatedAndResolved.Total;
            TxtBugsCancelled.Content = data.BugsCancelled.Total;
            TxtTechnicalDebitCreated.Content = data.TechnicalDebitCreated.Total;
            TxtTechnicalDebitOpened.Content = data.TechnicalDebitOpened.Total;
            TxtTechnicalDebitExisted.Content = data.TechnicalDebitExisted.Total;
            TxtTechnicalDebitResolved.Content = data.TechnicalDebitResolved.Total;
            TxtTechnicalDebitCreatedAndResolved.Content = data.TechnicalDebitCreatedAndResolved.Total;
            TxtTechnicalDebitCancelled.Content = data.TechnicalDebitCancelled.Total;

            downstreamJiraIndicatorsDto = data;

            ChangePbStatusAndBtnExecute(true);
        }

        private static bool IsValidFilter(UserSettings userSettings, AppFilterDto data)
        {
            if (string.IsNullOrWhiteSpace(userSettings.Username))
            {
                MessageBox.Show("É necessário informar o login para autenticação.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(userSettings.Password))
            {
                MessageBox.Show("É necessário informar a senha para autenticação.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(data.Project.Category))
            {
                MessageBox.Show("É necessário selecionar um projeto para gerar o relatório.");
                return false;
            }

            if (!data.StartDate.HasValue)
            {
                MessageBox.Show("É necessário informar a data inicial do período.");
                return false;
            }

            if (!data.EndDate.HasValue)
            {
                MessageBox.Show("É necessário informar a data final do período.");
                return false;
            }

            if (data.StartDate.Value > data.EndDate.Value)
            {
                MessageBox.Show("A data final do período não pode ser maior que a data inicial.");
                return false;
            }

            return true;
        }

        private void BtnBugsCreated_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Bugs - Criados", downstreamJiraIndicatorsDto.BugsCreated.Data);

        private void BtnBugsOpened_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Bugs - Em Aberto", downstreamJiraIndicatorsDto.BugsOpened.Data);

        private void BtnBugsExisted_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Bugs - Quarters Anteriores", downstreamJiraIndicatorsDto.BugsExisted.Data);

        private void BtnBugsResolved_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Bugs - Resolvidos", downstreamJiraIndicatorsDto.BugsResolved.Data);

        private void BtnBugsCreatedAndResolved_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Bugs - Criados e Resolvidos", downstreamJiraIndicatorsDto.BugsCreatedAndResolved.Data);

        private void BtnBugsCancelled_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Bugs - Cancelados", downstreamJiraIndicatorsDto.BugsCancelled.Data);

        private void BtnTechnicalDebitCreated_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Débitos Técnicos - Criados", downstreamJiraIndicatorsDto.TechnicalDebitCreated.Data);

        private void BtnTechnicalDebitOpened_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Débitos Técnicos - Em Aberto", downstreamJiraIndicatorsDto.TechnicalDebitOpened.Data);

        private void BtnTechnicalDebitExisted_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Débitos Técnicos - Quarters Anteriores", downstreamJiraIndicatorsDto.TechnicalDebitExisted.Data);

        private void BtnTechnicalDebitResolved_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Débitos Técnicos - Resolvidos", downstreamJiraIndicatorsDto.TechnicalDebitResolved.Data);

        private void BtnTechnicalDebitCreatedAndResolved_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Débitos Técnicos - Criados e Resolvidos", downstreamJiraIndicatorsDto.TechnicalDebitCreatedAndResolved.Data);

        private void BtnTechnicalDebitCancelled_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Débitos Técnicos - Cancelados", downstreamJiraIndicatorsDto.TechnicalDebitCancelled.Data);

        private static void OpenIssuesDetail(string title, IList<IssueInfoDto> data)
        {
            var window = new IssueWindow();
            window.DefineTitle(title);
            window.SetDataColletion(data);
            window.ShowDialog();
        }

        private async void BtnDashboard_Click(object sender, RoutedEventArgs e)
        {
            var filter = FillFilterData();
            if (filter == null)
                return;

            ChangePbStatusAndBtnExecute(false);

            var data = await dashboardBusiness.GetData(settingsHelper.Data.Username,
                                                       settingsHelper.Data.Password,
                                                       filter.Project.Name,
                                                       filter.Quarter,
                                                       cancellationTokenSource.Token);

            ChangePbStatusAndBtnExecute(true);

            var window = new DashboardWindow();
            window.SetDataColletion(data);
            window.ShowDialog();
        }

        private async void BtnNoFixVersion_Click(object sender, RoutedEventArgs e)
        {
            var filter = FillFilterData();
            if (filter == null)
                return;

            ChangePbStatusAndBtnExecute(false);

            var data = await fixVersionBusiness.GetListIssuesNoFixVersion(settingsHelper.Data.Username,
                                                                          settingsHelper.Data.Password,
                                                                          filter.Project.Name,
                                                                          cancellationTokenSource.Token);

            ChangePbStatusAndBtnExecute(true);

            var window = new IssueWindow();
            window.DefineTitle("Issues not Fix");
            window.SetDataColletion(data);
            window.ShowDialog();
        }

        private AppFilterDto FillFilterData()
        {
            var data = new AppFilterDto
            {
                Project = (JiraProjectDto)CbProjects.SelectedItem,
                Quarter = (string)CbQuarters.SelectedItem,
                StartDate = TxtInitDate.SelectedDate,
                EndDate = TxtEndDate.SelectedDate,
            };

            return IsValidFilter(settingsHelper.Data, data)
                 ? data
                 : null;
        }

        private async void BtnDeliveryLastCycle_Click(object sender, RoutedEventArgs e)
        {
            var filter = FillFilterData();
            if (filter == null)
                return;

            ChangePbStatusAndBtnExecute(false);

            var data = await dashboardBusiness.GetDeliveryLastCycleData(settingsHelper.Data.Username,
                                                                        settingsHelper.Data.Password,
                                                                        filter.Project.Name,
                                                                        filter.StartDate.Value,
                                                                        filter.EndDate.Value,
                                                                        cancellationTokenSource.Token);

            ChangePbStatusAndBtnExecute(true);

            var window = new DeliveryLastCycleWindow();
            window.SetDataColletion(data);
            window.ShowDialog();
        }

        private bool settingsSaved = false;
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!settingsHelper.Data.PersistFilter || settingsSaved)
                return;

            settingsHelper.Data.FilterData = new AppFilterDto
            {
                Project = (JiraProjectDto)CbProjects.SelectedItem,
                Quarter = (string)CbQuarters.SelectedItem,
                StartDate = TxtInitDate.SelectedDate,
                EndDate = TxtEndDate.SelectedDate,
            };
            settingsHelper.Save();

            settingsSaved = true;
        }
    }
}