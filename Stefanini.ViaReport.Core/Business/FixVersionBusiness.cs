using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Mappers;
using Stefanini.ViaReport.Core.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public class FixVersionBusiness : IFixVersionBusiness
    {
        private readonly IIssuesNotFixVersionService issuesNotFixVersionService;
        private readonly IIssueDtoToIssueInfoDtoMapper issueDtoToIssueInfoDtoMapper;

        public FixVersionBusiness(IIssuesNotFixVersionService issuesNotFixVersionService,
                                  IIssueDtoToIssueInfoDtoMapper issueDtoToIssueInfoDtoMapper)
        {
            this.issuesNotFixVersionService = issuesNotFixVersionService;
            this.issueDtoToIssueInfoDtoMapper = issueDtoToIssueInfoDtoMapper;
        }

        public async Task<IList<IssueInfoDto>> GetListIssuesNoFixVersion(string username, string password, string project, CancellationToken cancellationToken)
        {
            var list = await issuesNotFixVersionService.GetData(username, password, project, cancellationToken);

            return issueDtoToIssueInfoDtoMapper.ToMapList(list.Issues);
        }
    }
}