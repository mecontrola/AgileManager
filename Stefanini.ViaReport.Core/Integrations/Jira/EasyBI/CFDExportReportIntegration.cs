using Stefanini.ViaReport.Core.Data.Configurations;
using Stefanini.ViaReport.Core.Data.Dto.EasyBI;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = Stefanini.ViaReport.Core.Integrations.Routes.EasyBIRoute.Export;

namespace Stefanini.ViaReport.Core.Integrations.Jira.EasyBI
{
    public class CFDExportReportIntegration : BaseJiraIntegration, ICFDExportReportIntegration
    {
        public CFDExportReportIntegration(IJiraConfiguration jiraConfiguration)
            : base(jiraConfiguration, new JsonSnakeCaseNamingPolicy())
        { }

        public async Task<ReportResultDto> Execute(string username,
                                                   string password,
                                                   string accountId,
                                                   string reportId,
                                                   string reportFormat,
                                                   string projects,
                                                   string dates,
                                                   CancellationToken cancellationToken)
        {
            URL = CreateUrl(accountId, reportId, reportFormat);
            URL += CreateQueryString(new[] { dates, projects }.Where(itm => !string.IsNullOrWhiteSpace(itm)).ToArray());

            return await GetAsync<ReportResultDto>(username, password, cancellationToken);
        }

        private static string CreateUrl(string accountId, string reportId, string reportFormat)
            => route.GET_ALL
                    .Replace("{accountId}", accountId)
                    .Replace("{reportId}", reportId)
                    .Replace("{reportFormat}", reportFormat);

        private static string CreateQueryString(string[] @params)
            => $"?selected_pages={string.Join(',', @params)}";
    }
}