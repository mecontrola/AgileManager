using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Issues;
using Stefanini.ViaReport.Core.Mappers;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public class FixVersionBusiness : IFixVersionBusiness
    {
        private readonly ISettingsService settingsService;
        private readonly IIssuesNotFixVersionService issuesNotFixVersionService;
        private readonly IIssueDtoToIssueInfoDtoMapper issueDtoToIssueInfoDtoMapper;
        private readonly IIssueGet issueGet;

        public FixVersionBusiness(ISettingsService settingsService,
                                  IIssuesNotFixVersionService issuesNotFixVersionService,
                                  IIssueDtoToIssueInfoDtoMapper issueDtoToIssueInfoDtoMapper,
                                  IIssueGet issueGet)
        {
            this.settingsService = settingsService;
            this.issuesNotFixVersionService = issuesNotFixVersionService;
            this.issueDtoToIssueInfoDtoMapper = issueDtoToIssueInfoDtoMapper;
            this.issueGet = issueGet;
        }

        public async Task<IList<IssueInfoDto>> GetListIssuesNoFixVersion(string project, CancellationToken cancellationToken)
        {
            var settings = await settingsService.LoadDataAsync(cancellationToken);
            var list = await issuesNotFixVersionService.GetData(settings.Username, settings.Password, project, cancellationToken);
            list = await LoadIssueFields(settings.Username, settings.Password, list, cancellationToken);

            return issueDtoToIssueInfoDtoMapper.ToMapList(list.Issues);
        }

        private async Task<SearchDto> LoadIssueFields(string username, string password, SearchDto search, CancellationToken cancellationToken)
        {
            var issues = new List<IssueDto>();

            foreach (var issue in search.Issues)
            {
                var data = await issueGet.Execute(username, password, issue.Key, cancellationToken);

                issues.Add(data);
            }

            return new SearchDto
            {
                MaxResults = search.MaxResults,
                StartAt = search.StartAt,
                Total = search.Total,
                Issues = issues
            };
        }
    }
}