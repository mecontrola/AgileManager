using Stefanini.ViaReport.Data.Parameters;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services.Synchronizers.ExtraIssueData
{
    public interface IIssueDataSynchronizerService
    {
        Task Save(IssueSynchronizerParam parameters, CancellationToken cancellationToken);
    }
}