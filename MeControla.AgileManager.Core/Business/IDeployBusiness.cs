using MeControla.AgileManager.Data.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Business
{
    public interface IDeployBusiness
    {
        Task<IList<IssueDeployDto>> GetList(long projectId, CancellationToken cancellationToken);
        Task SaveList(IList<IssueDeployDto> list, CancellationToken cancellationToken);
    }
}