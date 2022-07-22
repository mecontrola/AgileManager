using Stefanini.ViaReport.Data.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public interface IFixVersionBusiness
    {
        Task<IList<IssueDto>> GetListIssuesNoFixVersion(string project, CancellationToken cancellationToken);
    }
}