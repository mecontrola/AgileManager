using Stefanini.ViaReport.Core.Integrations.Jira.V2.Issues;
using Stefanini.ViaReport.Core.Mappers;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Data.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DtoJira = Stefanini.ViaReport.Data.Dtos.Jira;

namespace Stefanini.ViaReport.Core.Business
{
    public class FixVersionBusiness : IFixVersionBusiness
    {
        private readonly ISettingsService settingsService;
        private readonly IIssuesNotFixVersionService issuesNotFixVersionService;
        private readonly IJiraIssueDtoToIssueInfoDtoMapper jiraIssueDtoToIssueInfoDtoMapper;
        private readonly IIssueGet issueGet;

        public FixVersionBusiness(ISettingsService settingsService,
                                  IIssuesNotFixVersionService issuesNotFixVersionService,
                                  IJiraIssueDtoToIssueInfoDtoMapper jiraIssueDtoToIssueInfoDtoMapper,
                                  IIssueGet issueGet)
        {
            this.settingsService = settingsService;
            this.issuesNotFixVersionService = issuesNotFixVersionService;
            this.jiraIssueDtoToIssueInfoDtoMapper = jiraIssueDtoToIssueInfoDtoMapper;
            this.issueGet = issueGet;
        }

        public async Task<IList<IssueDto>> GetListIssuesNoFixVersion(string project, CancellationToken cancellationToken)
        {
            var settings = await settingsService.LoadDataAsync(cancellationToken);
            var list = await issuesNotFixVersionService.GetData(settings.Username, settings.Password, project, cancellationToken);
            list = await LoadIssueFields(settings.Username, settings.Password, list, cancellationToken);

            return jiraIssueDtoToIssueInfoDtoMapper.ToMapList(list.Issues);
        }

        private async Task<DtoJira.SearchDto> LoadIssueFields(string username, string password, DtoJira.SearchDto search, CancellationToken cancellationToken)
        {
            var issues = new List<DtoJira.IssueDto>();

            foreach (var issue in search.Issues)
            {
                var data = await issueGet.Execute(username, password, issue.Key, cancellationToken);

                issues.Add(data);
            }

            return new DtoJira.SearchDto
            {
                MaxResults = search.MaxResults,
                StartAt = search.StartAt,
                Total = search.Total,
                Issues = issues
            };
        }
    }
}