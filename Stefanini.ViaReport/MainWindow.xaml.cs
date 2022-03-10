using Microsoft.Win32;
using Stefanini.Core.Extensions;
using Stefanini.Core.Settings;
using Stefanini.ViaReport.Core.Business;
using Stefanini.ViaReport.Core.Data.Configurations;
using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Exceptions;
using Stefanini.ViaReport.Core.Extensions;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Stefanini.ViaReport
{
    public partial class MainWindow : Window
    {
        private readonly CancellationTokenSource cancellationTokenSource;
        private readonly ObservableCollection<AHMInfoDto> dgDataCollection;

        private readonly IApplicationConfiguration applicationConfiguration;

        private readonly IDashboardBusiness dashboardBusiness;
        private readonly IFixVersionBusiness fixVersionBusiness;
        private readonly IDownstreamJiraIndicatorsBusiness downstreamJiraIndicatorsBusiness;
        private readonly IUpstreamDownstreamRateBusiness upstreamDownstreamRateBusiness;

        private readonly IJiraAuthService jiraAuthService;
        private readonly IJiraProjectsService jiraProjectsService;

        private readonly ISettingsHelper settingsHelper;
        private readonly IAverageUpstreamDownstreamRateHelper averageUpstreamDownstreamRateHelper;
        private readonly IProjectNameCfdEasyBIExportHelper projectNameCfdEasyBIExportHelper;
        private readonly IDateTimeFromStringHelper dateTimeFromStringHelper;

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
                          IProjectNameCfdEasyBIExportHelper projectNameCfdEasyBIExportHelper,
                          IDateTimeFromStringHelper dateTimeFromStringHelper)
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
            this.projectNameCfdEasyBIExportHelper = projectNameCfdEasyBIExportHelper;
            this.dateTimeFromStringHelper = dateTimeFromStringHelper;

            cancellationTokenSource = new CancellationTokenSource();
            dgDataCollection = new ObservableCollection<AHMInfoDto>();

            imageAuthCheck = GetImageSource("Images/sign_check_icon.png");
            imageAuthError = GetImageSource("Images/sign_error_icon.png");

            InitializeComponent();
            _ = InitializeData();
        }

        private async Task InitializeData()
        {
            await CheckJiraAuth();

            MiTools.IsEnabled = applicationConfiguration.ShowTools;
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
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var project = (JiraProjectDto)CbProjects.SelectedItem;
            var initDate = TxtInitDate.SelectedDate;
            var endDate = TxtEndDate.SelectedDate;

            if (!IsValidFilter(settingsHelper.Data, project.Category, initDate, endDate))
                return;

            ChangePbStatusAndBtnExecute(false, true);

            var projects = projectNameCfdEasyBIExportHelper.Format(project);

            try
            {
                var openFileDialog = new OpenFileDialog();

                if (openFileDialog.ShowDialog() == false)
                {
                    ChangePbStatusAndBtnExecute(true, true);
                    return;
                }

                var items = await upstreamDownstreamRateBusiness.GetData(openFileDialog.FileName, cancellationTokenSource.Token);


//                var items = await upstreamDownstreamRateBusiness.GetData(settingsHelper.Data.Username,
//                                                                         settingsHelper.Data.Password,
//                                                                         project.Name,
//#pragma warning disable CS8629 // Nullable value type may be null.
//                                                                         initDate.Value,
//#pragma warning restore CS8629 // Nullable value type may be null.
//#pragma warning disable CS8629 // Nullable value type may be null.
//                                                                         endDate.Value,
//#pragma warning restore CS8629 // Nullable value type may be null.
//                                                                         cancellationTokenSource.Token);

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
            items.Insert(0, new JiraProjectDto { Name = "Select item" });

            var lcv = new ListCollectionView((System.Collections.IList)items);
            lcv.GroupDescriptions.Add(new PropertyGroupDescription("Category"));

            CbProjects.ItemsSource = lcv;
            CbProjects.IsEnabled = true;
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
            img.UriSource = new Uri($"pack://application:,,,/{path}");
            img.EndInit();
            return img;
        }

        private void CbProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnExecute.IsEnabled = true;
        }

        private void BtnAuthenticate_Click(object sender, RoutedEventArgs e)
            => OpenAuthenticationForm();

        private void OpenAuthenticationForm()
            => new AuthenticationWindow(settingsHelper)
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

        private async void BtnDownExecute_Click(object sender, RoutedEventArgs e)
        {
            var project = (JiraProjectDto)CbProjects.SelectedItem;
            var initDate = TxtInitDate.SelectedDate;
            var endDate = TxtEndDate.SelectedDate;

            if (!IsValidFilter(settingsHelper.Data, project.Category, initDate, endDate))
                return;

            ChangePbStatusAndBtnExecute(false);

            var data = await downstreamJiraIndicatorsBusiness.GetData(settingsHelper.Data.Username,
                                                                      settingsHelper.Data.Password,
                                                                      project.Name,
#pragma warning disable CS8629 // Nullable value type may be null.
                                                                      initDate.Value,
#pragma warning restore CS8629 // Nullable value type may be null.
#pragma warning disable CS8629 // Nullable value type may be null.
                                                                      endDate.Value,
#pragma warning restore CS8629 // Nullable value type may be null.
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

        private static bool IsValidFilter(UserSettings userSettings, string category, DateTime? initDate, DateTime? endDate)
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

            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("É necessário selecionar um projeto para gerar o relatório.");
                return false;
            }

            if (!initDate.HasValue)
            {
                MessageBox.Show("É necessário informar a data inicial do período.");
                return false;
            }

            if (!endDate.HasValue)
            {
                MessageBox.Show("É necessário informar a data final do período.");
                return false;
            }

            if (initDate.Value > endDate.Value)
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
            var project = (JiraProjectDto)CbProjects.SelectedItem;
            var initDate = TxtInitDate.SelectedDate;
            var endDate = TxtEndDate.SelectedDate;

            if (!IsValidFilter(settingsHelper.Data, project.Category, initDate, endDate))
                return;

            var data = await dashboardBusiness.GetData(settingsHelper.Data.Username,
                                                       settingsHelper.Data.Password,
                                                       project.Name,
                                                       cancellationTokenSource.Token);

            var window = new DashboardWindow();
            window.SetDataColletion(data);
            window.ShowDialog();
        }

        private async void BtnNoFixVersion_Click(object sender, RoutedEventArgs e)
        {
            var project = (JiraProjectDto)CbProjects.SelectedItem;
            var initDate = TxtInitDate.SelectedDate;
            var endDate = TxtEndDate.SelectedDate;

            if (!IsValidFilter(settingsHelper.Data, project.Category, initDate, endDate))
                return;

            var data = await fixVersionBusiness.GetListIssuesNoFixVersion(settingsHelper.Data.Username,
                                                                          settingsHelper.Data.Password,
                                                                          project.Name,
                                                                          cancellationTokenSource.Token);

            var window = new IssueWindow();
            window.DefineTitle("Issues not Fix");
            window.SetDataColletion(data);
            window.ShowDialog();
        }

        private async void BtnDeliveryLastCycle_Click(object sender, RoutedEventArgs e)
        {
            var project = (JiraProjectDto)CbProjects.SelectedItem;
            var initDate = TxtInitDate.SelectedDate;
            var endDate = TxtEndDate.SelectedDate;

            if (!IsValidFilter(settingsHelper.Data, project.Category, initDate, endDate))
                return;

            var data = await dashboardBusiness.GetDeliveryLastCycleData(settingsHelper.Data.Username,
                                                                        settingsHelper.Data.Password,
                                                                        project.Name,
                                                                        initDate.Value,
                                                                        endDate.Value,
                                                                        cancellationTokenSource.Token);

            var window = new DeliveryLastCycleWindow();
            window.SetDataColletion(data);
            window.ShowDialog();
        }
    }
}