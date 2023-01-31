using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            => await FindAsync(entity => entity.CustomFieldId == customfieldId
                                      && entity.IssueId == issueId, cancellationToken);

        public async Task<IList<IssueCustomfieldData>> FindAllByIssueIdAsync(long issueId, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Include(entity => entity.CustomField)
                          .ThenInclude(entity => entity.Preference)
                          .Where(entity => entity.IssueId == issueId
                                        && (context as IDbAppContext).PreferenceCustomFields.Any(itm => itm.CustomFieldId== entity.CustomFieldId))
                          .ToListAsync(cancellationToken);
    }
}