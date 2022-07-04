using MeControla.Core.Repositories;
using Stefanini.ViaReport.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.DataStorage.Repositories
{
    public class IssueTypeRepository : BaseAsyncRepository<IssueType>, IIssueTypeRepository
    {
        public IssueTypeRepository(IDbAppContext context)
            : base(context, context.IssueTypes)
        { }

        public async Task<IssueType> FindByKeyAsync(long key, CancellationToken cancellationToken)
            => await FindAsync(entity => entity.Key == key, cancellationToken);

        public async Task<bool> ExistsByKeyAsync(long key, CancellationToken cancellationToken)
            => await ExistsAsync(entity => entity.Key == key, cancellationToken);
    }
}