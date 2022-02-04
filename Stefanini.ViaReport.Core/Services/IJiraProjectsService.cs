using Stefanini.ViaReport.Core.Data.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public interface IJiraProjectsService
    {
        Task<IList<JiraProjectDto>> LoadList(string username, string password, CancellationToken cancellationToken);
    }
}