using Stefanini.ViaReport.Core.Data.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public interface IFixVersionBusiness
    {
        Task<IList<IssueInfoDto>> GetListIssuesNoFixVersion(string project, CancellationToken cancellationToken);
    }
}