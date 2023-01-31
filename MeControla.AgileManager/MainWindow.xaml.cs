using MeControla.AgileManager.Core.Business;
using MeControla.AgileManager.Core.Data.Dto;
using MeControla.AgileManager.Core.Extensions;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.Data.Dtos.Settings;
using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.Extensions;
using MeControla.AgileManager.Helpers;
using MeControla.AgileManager.Integrations.Jira.Exceptions;
using MeControla.AgileManager.Updater.Core.Helpers;
using MeControla.Core.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
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
using Info = MeControla.AgileManager.Helpers.AssemblyInfoHelper;
using Texts = MeControla.AgileManager.Data.AppTextsData;

namespace MeControla.AgileManager
{
    public partial class MainWindow : Window
    {
        private const string PATH_IMAGE_CHECK_OK = "Images/sign_check_icon.png";
        private const string PATH_IMAGE_CHECK_FAIL = "Images/sign_error_icon.png";

        private const int DEFAULT_COMBOBOX_ITEM_ID = 0;
        private const int TIME_CHECK_UPDATE_30_MINUTES = 30;

        private readonly CancellationTokenSource cancellationTokenSource;
        private readonly ObservableCollection<AHMInfoDto> dgDataCollection;
        private readonly PeriodicTimer timer = new(TimeSpan.FromMinutes(TIME_CHECK_UPDATE_30_MINUTES));

        private readonly ILogger<MainWindow> logger;

        private readonly IDashboardBusiness dashboardBusiness;
        private readonly IDeployBusiness deployBusiness;
        private readonly IDownstreamJiraIndicatorsBusiness downstreamJiraIndicatorsBusiness;
        private readonly IFixVersionBusiness fixVersionBusiness;
        private readonly IProjectBusiness projectBusiness;
        private readonly IQuarterBusiness quarterBusiness;
        private readonly ISettingsBusiness settingsBusiness;
        private readonly ISynchronizerBusiness synchronizerBusiness;
        private readonly IUpstreamDownstreamRateBusiness upstreamDownstreamRateBusiness;
        private readonly IJiraAuthService jiraAuthService;

        private readonly IAverageUpstreamDownstreamRateHelper averageUpstreamDownstreamRateHelper;
        private readonly IDateTimeFromStringHelper dateTimeFromStringHelper;
        private readonly IRemoteVersionHelper remoteVersionHelper;

        private readonly IUpdateToastHelper updateToastHelper;

        private readonly ImageSource imageAuthCheck;
        private readonly ImageSource imageAuthError;

        private DownstreamIndicatorDto downstreamJiraIndicatorsDto = new();

        public MainWindow(ILogger<MainWindow> logger,
                          IDashboardBusiness dashboardBusiness,
                          IDeployBusiness deployBusiness,
                          IDownstreamJiraIndicatorsBusiness downstreamJiraIndicatorsBusiness,
                          IFixVersionBusiness fixVersionBusiness,
                          IProjectBusiness projectBusiness,
                          IQuarterBusiness quarterBusiness,
                          ISettingsBusiness settingsBusiness,
                          ISynchronizerBusiness synchronizerBusiness,
                          IUpstreamDownstreamRateBusiness upstreamDownstreamRateBusiness,
                          IJiraAuthService jiraAuthService,
                          IAverageUpstreamDownstreamRateHelper averageUpstreamDownstreamRateHelper,
                          IDateTimeFromStringHelper dateTimeFromStringHelper,
                          IUpdateToastHelper updateToastHelper,
                          IRemoteVersionHelper remoteVersionHelper)
        {
            this.logger = logger;
            this.dashboardBusiness = dashboardBusiness;
            this.deployBusiness = deployBusiness;
            this.downstreamJiraIndicatorsBusiness = downstreamJiraIndicatorsBusiness;
            this.fixVersionBusiness = fixVersionBusiness;
            this.projectBusiness = projectBusiness;
            this.quarterBusiness = quarterBusiness;
            this.settingsBusiness = settingsBusiness;
            this.synchronizerBusiness = synchronizerBusiness;
            this.upstreamDownstreamRateBusiness = upstreamDownstreamRateBusiness;
            this.jiraAuthService = jiraAuthService;
            this.averageUpstreamDownstreamRateHelper = averageUpstreamDownstreamRateHelper;
            this.dateTimeFromStringHelper = dateTimeFromStringHelper;
            this.updateToastHelper = updateToastHelper;
            this.remoteVersionHelper = remoteVersionHelper;

            cancellationTokenSource = new CancellationTokenSource();
            dgDataCollection = new ObservableCollection<AHMInfoDto>();

            imageAuthCheck = GetImageSource(PATH_IMAGE_CHECK_OK);
            imageAuthError = GetImageSource(PATH_IMAGE_CHECK_FAIL);

            InitializeComponent();
            InitializeData();

            RunCheckUpdate();
        }

        private async void InitializeData()
        {
            await CheckJiraAuth();

            await FillFilter();
        }

        public async Task CheckJiraAuth()
        {
            FormAuthenticateIsEnabled(false);

            if (await IsAuthenticationNullOrWhiteSpace())
                return;

            var isOk = false;

            try
            {
                isOk = await jiraAuthService.IsAuthenticationOk(cancellationTokenSource.Token);
            }
            catch (UnknownHostException)
            {
                MessageBox.Show("Não foi possível se autenticar com o Jira.\nÉ necessário informar o login para autenticação.");
            }

            FormAuthenticateIsEnabled(isOk);

            await LoadCbProjects();

            await LoadCbQuarters();
        }

        private async Task<bool> IsAuthenticationNullOrWhiteSpace()
            => !await settingsBusiness.IsAuthenticationDataValidAsync(cancellationTokenSource.Token);

        private async Task FillFilter()
        {
            var settings = await settingsBusiness.LoadDataAsync(cancellationTokenSource.Token);

            if (!settings.PersistFilter || settings.FilterData == null)
                return;

            TxtInitDate.SelectedDate = settings.FilterData.StartDate;
            TxtEndDate.SelectedDate = settings.FilterData.EndDate;

            if (settings.FilterData.Project != null)
                CbProjects.SelectedIndex = ProjectIndexOf(settings.FilterData.Project);

            if (settings.FilterData.Quarter != null)
                CbQuarters.SelectedIndex = QuarterIndexOf(settings.FilterData.Quarter);
        }

        private int ProjectIndexOf(ProjectDto project)
            => CbProjects.GetItemIndexOf<ProjectDto>(p => project != null
                                                       && p.Category != null
                                                       && p.Category.Name.Equals(project.Category.Name)
                                                       && p.Name.Equals(project.Name));

        private int QuarterIndexOf(QuarterDto quarter)
            => quarter == null
             ? 0
             : CbQuarters.GetItemIndexOf<QuarterDto>(p => p.Name.Equals(quarter.Name));

        private async void RunWithExceptionHandling(Func<Task> runAction, Action runBefore, Action runAfter)
        {
            try
            {
                logger.LogInformation("Action Init.");

                runBefore();

                await runAction();
            }
            catch (UnknownHostException ex)
            {
                logger.LogError(ex, "Serviço indisponível, tente novamente mais tarde!");

                MessageBox.Show("Serviço indisponível, tente novamente mais tarde!", "Jira Error", MessageBoxButton.OK);
            }
            //catch (Exception ex)
            //{
            //    logger.LogError(ex, "Jira Error");
            //
            //    MessageBox.Show(ex.Message, "Jira Error", MessageBoxButton.OK);
            //}
            catch (Exception ex)
            {
                logger.LogError(ex, "Error");

                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
            finally
            {
                logger.LogInformation("Action End.");

                runAfter();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var filter = FillFilterData();
            if (filter == null)
                return;

            RunWithExceptionHandling(async () =>
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
            },
            () => ChangePbStatusAndBtnExecute(false, true),
            () => ChangePbStatusAndBtnExecute(true, true));
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

        public async Task LoadCbProjects()
            => await LoadCbProjects(null);

        public async Task LoadCbProjects(AppFilterDto appFilterDto)
        {
            if (await IsAuthenticationNullOrWhiteSpace())
                return;

            var items = await projectBusiness.ListSelectedWithCategoryAsync(cancellationTokenSource.Token);

            items.Insert(DEFAULT_COMBOBOX_ITEM_ID, new ProjectDto { Name = Texts.DEFAULT_COMBOBOX_ITEM_NAME });

            var lcv = new ListCollectionView((System.Collections.IList)items);
            lcv.GroupDescriptions.Add(new PropertyGroupDescription("Category.Name"));

            CbProjects.ItemsSource = lcv;
            CbProjects.IsEnabled = true;

            if (appFilterDto != null)
                CbProjects.SelectedIndex = ProjectIndexOf(appFilterDto.Project);
        }

        private async Task LoadCbQuarters()
        {
            var items = await quarterBusiness.ListAllAsync(cancellationTokenSource.Token);

            items.Insert(DEFAULT_COMBOBOX_ITEM_ID, new QuarterDto { Name = Texts.DEFAULT_COMBOBOX_ITEM_NAME });

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
            => new AuthenticationWindow(cancellationTokenSource, settingsBusiness)
            {
                Owner = GetWindow(this)
            }.ShowDialog();

        private void BtnPreferences_Click(object sender, RoutedEventArgs e)
            => OpenPreferencesForm();

        private void OpenPreferencesForm()
            => new PreferencesWindow(cancellationTokenSource, settingsBusiness, projectBusiness)
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

        private void BtnSyncronizer_Click(object sender, RoutedEventArgs e)
            => RunWithExceptionHandling(async () =>
            {
                await synchronizerBusiness.SynchronizeDataAsync(cancellationTokenSource.Token);

                await LoadCbQuarters();
            },
            () => ChangePbStatusAndBtnExecute(false),
            () => ChangePbStatusAndBtnExecute(true));

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
            => OpenUpdateForm();

        private void OpenUpdateForm()
            => new UpdateWindow(remoteVersionHelper)
            {
                Owner = GetWindow(this)
            }.ShowDialog();

        private async void RunCheckUpdate()
        {
            await CheckUpdate();

            while (await timer.WaitForNextTickAsync())
                await CheckUpdate();
        }

        private async Task CheckUpdate()
        {
            var avaliable = await remoteVersionHelper.GetVersion(cancellationTokenSource.Token);
            var current = Version.Parse(Info.AssemblyVersion);

            if (avaliable > current)
                updateToastHelper.Show(Toast_Activated);
        }

        private void Toast_Activated(ToastNotification sender, object args)
            => Dispatcher.BeginInvoke(DispatcherPriority.Background, OpenUpdateForm);

        private void BtnDownExecute_Click(object sender, RoutedEventArgs e)
        {
            RunWithExceptionHandling(async () =>
            {
                var filter = await FillFilterData();
                if (filter == null)
                    return;

                var data = await downstreamJiraIndicatorsBusiness.GetLocalIndicatorsAsync(filter.Project.Id,
                                                                                         filter.StartDate.Value,
                                                                                         filter.EndDate.Value,
                                                                                         cancellationTokenSource.Token);

                TxtCycleBalance.Content = $"{data.CycleBalance}%";
                TxtBugsCreated.Content = data.Bugs[DownstreamIndicatorTypes.Created].Count;
                TxtBugsOpened.Content = data.Bugs[DownstreamIndicatorTypes.Opened].Count;
                TxtBugsExisted.Content = data.Bugs[DownstreamIndicatorTypes.Existed].Count;
                TxtBugsResolved.Content = data.Bugs[DownstreamIndicatorTypes.Resolved].Count;
                TxtBugsCreatedAndResolved.Content = data.Bugs[DownstreamIndicatorTypes.CreatedAndResolved].Count;
                TxtBugsCancelled.Content = data.Bugs[DownstreamIndicatorTypes.Cancelled].Count;
                TxtTechnicalDebitCreated.Content = data.TechnicalDebit[DownstreamIndicatorTypes.Created].Count;
                TxtTechnicalDebitOpened.Content = data.TechnicalDebit[DownstreamIndicatorTypes.Opened].Count;
                TxtTechnicalDebitExisted.Content = data.TechnicalDebit[DownstreamIndicatorTypes.Existed].Count;
                TxtTechnicalDebitResolved.Content = data.TechnicalDebit[DownstreamIndicatorTypes.Resolved].Count;
                TxtTechnicalDebitCreatedAndResolved.Content = data.TechnicalDebit[DownstreamIndicatorTypes.CreatedAndResolved].Count;
                TxtTechnicalDebitCancelled.Content = data.TechnicalDebit[DownstreamIndicatorTypes.Cancelled].Count;

                downstreamJiraIndicatorsDto = data;
            },
            () => ChangePbStatusAndBtnExecute(false),
            () => ChangePbStatusAndBtnExecute(true));
        }

        private static bool IsValidFilter(AppSettingsDto settings, AppFilterDto data)
        {
            if (string.IsNullOrWhiteSpace(settings.Url))
            {
                MessageBox.Show("É necessário informar a url do Jira para autenticação.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(settings.Username))
            {
                MessageBox.Show("É necessário informar o login para autenticação.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(settings.Password))
            {
                MessageBox.Show("É necessário informar a senha para autenticação.");
                return false;
            }

            if (data.Project == null)
            {
                MessageBox.Show("É necessário selecionar um projeto para gerar o relatório.");
                return false;
            }

            if (data.Project.Category == null)
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
            => OpenIssuesDetail("Bugs - Criados", downstreamJiraIndicatorsDto.Bugs[DownstreamIndicatorTypes.Created]);

        private void BtnBugsOpened_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Bugs - Em Aberto", downstreamJiraIndicatorsDto.Bugs[DownstreamIndicatorTypes.Opened]);

        private void BtnBugsExisted_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Bugs - Quarters Anteriores", downstreamJiraIndicatorsDto.Bugs[DownstreamIndicatorTypes.Existed]);

        private void BtnBugsResolved_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Bugs - Resolvidos", downstreamJiraIndicatorsDto.Bugs[DownstreamIndicatorTypes.Resolved]);

        private void BtnBugsCreatedAndResolved_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Bugs - Criados e Resolvidos", downstreamJiraIndicatorsDto.Bugs[DownstreamIndicatorTypes.CreatedAndResolved]);

        private void BtnBugsCancelled_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Bugs - Cancelados", downstreamJiraIndicatorsDto.Bugs[DownstreamIndicatorTypes.Cancelled]);

        private void BtnTechnicalDebitCreated_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Débitos Técnicos - Criados", downstreamJiraIndicatorsDto.TechnicalDebit[DownstreamIndicatorTypes.Created]);

        private void BtnTechnicalDebitOpened_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Débitos Técnicos - Em Aberto", downstreamJiraIndicatorsDto.TechnicalDebit[DownstreamIndicatorTypes.Opened]);

        private void BtnTechnicalDebitExisted_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Débitos Técnicos - Quarters Anteriores", downstreamJiraIndicatorsDto.TechnicalDebit[DownstreamIndicatorTypes.Existed]);

        private void BtnTechnicalDebitResolved_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Débitos Técnicos - Resolvidos", downstreamJiraIndicatorsDto.TechnicalDebit[DownstreamIndicatorTypes.Resolved]);

        private void BtnTechnicalDebitCreatedAndResolved_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Débitos Técnicos - Criados e Resolvidos", downstreamJiraIndicatorsDto.TechnicalDebit[DownstreamIndicatorTypes.CreatedAndResolved]);

        private void BtnTechnicalDebitCancelled_Click(object sender, RoutedEventArgs e)
            => OpenIssuesDetail("Débitos Técnicos - Cancelados", downstreamJiraIndicatorsDto.TechnicalDebit[DownstreamIndicatorTypes.Cancelled]);

        private static void OpenIssuesDetail(string title, IList<IssueDto> data)
        {
            var window = new IssueWindow();
            window.DefineTitle(title);
            window.SetDataColletion(data);
            window.ShowDialog();
        }

        private async void BtnNoFixVersion_Click(object sender, RoutedEventArgs e)
        {
            var filter = await FillFilterData();
            if (filter == null)
                return;

            ChangePbStatusAndBtnExecute(false);

            var data = await fixVersionBusiness.GetListIssuesNoFixVersion(filter.Project.Name, cancellationTokenSource.Token);

            ChangePbStatusAndBtnExecute(true);

            var window = new IssueWindow();
            window.DefineTitle("Issues not Fix");
            window.SetDataColletion(data);
            window.ShowDialog();
        }

        private async Task<AppFilterDto> FillFilterData()
        {
            var data = ReceivedFilterData();

            var settings = await settingsBusiness.LoadDataAsync(cancellationTokenSource.Token);

            return IsValidFilter(settings, data)
                 ? data
                 : null;
        }

        private async void BtnDeliveryLastCycle_Click(object sender, RoutedEventArgs e)
        {
            var filter = await FillFilterData();
            if (filter == null)
                return;

            ChangePbStatusAndBtnExecute(false);

            var data = await dashboardBusiness.GetDeliveryLastCycleData(filter.Project.Id,
                                                                        filter.Quarter?.Id ?? 0,
                                                                        filter.StartDate.Value,
                                                                        filter.EndDate.Value,
                                                                        cancellationTokenSource.Token);

            ChangePbStatusAndBtnExecute(true);

            var window = new DeliveryLastCycleWindow();
            window.Owner = GetWindow(this);
            window.SetDataColletion(data);
            window.ShowDialog();
        }

        private bool settingsSaved = false;
        private async void Window_Closing(object sender, CancelEventArgs e)
        {
            var settings = await settingsBusiness.LoadDataAsync(cancellationTokenSource.Token);

            if (!settings.PersistFilter || settingsSaved)
                return;

            await settingsBusiness.SaveFilterDataAsync(ReceivedFilterData(), cancellationTokenSource.Token);

            settingsSaved = true;
        }

        private AppFilterDto ReceivedFilterData()
            => new()
            {
                Project = CbProjects.GetSelectedValue<ProjectDto>(),
                Quarter = CbQuarters.GetSelectedValue<QuarterDto>(),
                StartDate = TxtInitDate.SelectedDate,
                EndDate = TxtEndDate.SelectedDate,
            };

        private async void BtnIssuesToDeploy_Click(object sender, RoutedEventArgs e)
        {
            var filter = await FillFilterData();
            if (filter == null)
                return;

            ChangePbStatusAndBtnExecute(false);

            var data = await deployBusiness.GetList(filter.Project.Id, cancellationTokenSource.Token);

            ChangePbStatusAndBtnExecute(true);

            var window = new DeployWindow();
            window.Owner = GetWindow(this);
            window.LoadData = () => deployBusiness.GetList(filter.Project.Id, cancellationTokenSource.Token).GetAwaiter().GetResult();
            window.ButtonSave = async list => await deployBusiness.SaveList(list, cancellationTokenSource.Token);
            window.ShowDialog();
        }
    }
}