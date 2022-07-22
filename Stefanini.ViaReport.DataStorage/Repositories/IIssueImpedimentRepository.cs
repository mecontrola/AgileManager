using MeControla.Core.Repositories;
using Stefanini.ViaReport.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.DataStorage.Repositories
{
    public interface IIssueImpedimentRepository : IAsyncRepository<IssueImpediment>
    {
        Task<IssueImpediment> RetrieveByIssueAndStartAsync(long issueId, DateTime impedimentStart, CancellationToken cancellationToken);
        Task<IList<IssueImpediment>> RetrieveByDateRangeAsync(long projectId, DateTime dateInit, DateTime dateEnd, CancellationToken cancellationToken);
    }
}