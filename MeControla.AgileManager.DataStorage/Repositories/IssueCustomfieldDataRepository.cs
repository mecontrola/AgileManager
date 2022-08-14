using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public class IssueCustomfieldDataRepository : BaseAsyncRepository<IssueCustomfieldData>, IIssueCustomfieldDataRepository
    {
        public IssueCustomfieldDataRepository(IDbAppContext context)
            : base(context, context.IssueCustomfieldDatas)
        { }

        public async Task<IssueCustomfieldData> RetrieveByCustomfieldAndIssueAsync(long customfieldId, long issueId, CancellationToken cancellationToken)
            => await FindAsync(entity => entity.CustomfieldId == customfieldId
                                      && entity.IssueId == issueId, cancellationToken);
    }
}