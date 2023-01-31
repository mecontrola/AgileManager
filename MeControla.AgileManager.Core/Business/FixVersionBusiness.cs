using MeControla.AgileManager.Core.Mappers;
using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DtoJira = MeControla.AgileManager.Integrations.Jira.Data.Dtos;

namespace MeControla.AgileManager.Core.Business
{
    public class FixVersionBusiness : IFixVersionBusiness
    {
        private readonly IIssuesNotFixVersionService issuesNotFixVersionService;
        private readonly IJiraIssueDtoToIssueInfoDtoMapper jiraIssueDtoToIssueInfoDtoMapper;
        private readonly IIssueGet issueGet;

        public FixVersionBusiness(IIssuesNotFixVersionService issuesNotFixVersionService,
                                  IJiraIssueDtoToIssueInfoDtoMapper jiraIssueDtoToIssueInfoDtoMapper,
                                  IIssueGet issueGet)
        {
            this.issuesNotFixVersionService = issuesNotFixVersionService;
            this.jiraIssueDtoToIssueInfoDtoMapper = jiraIssueDtoToIssueInfoDtoMapper;
            this.issueGet = issueGet;
        }

        public async Task<IList<IssueDto>> GetListIssuesNoFixVersion(string project, CancellationToken cancellationToken)
        {
            var list = await issuesNotFixVersionService.GetData(project, cancellationToken);
            list = await LoadIssueFields(list, cancellationToken);

            return jiraIssueDtoToIssueInfoDtoMapper.ToMapList(list.Issues);
        }

        private async Task<DtoJira.SearchDto> LoadIssueFields(DtoJira.SearchDto search, CancellationToken cancellationToken)
        {
            var issues = new List<DtoJira.IssueDto>();

            foreach (var issue in search.Issues)
            {
                var data = await issueGet.Execute(issue.Key, cancellationToken);

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