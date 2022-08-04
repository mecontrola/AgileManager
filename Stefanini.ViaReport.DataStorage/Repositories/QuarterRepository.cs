using MeControla.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Stefanini.ViaReport.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.DataStorage.Repositories
{
    public class QuarterRepository : BaseAsyncRepository<Quarter>, IQuarterRepository
    {
        public QuarterRepository(IDbAppContext context)
            : base(context, context.Quarters)
        { }

        public async Task<Quarter> RetrieveByNameAsync(string name, CancellationToken cancellationToken)
            => await FindAsync(entity => entity.Name.Equals(name), cancellationToken);

        public async Task<IList<Quarter>> Get5LastListAsync(CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .OrderByDescending(entity => entity.Name.Substring(2))
                          .ThenByDescending(entity => entity.Name.Substring(1, 1))
                          .Take(5)
                          .ToListAsync(cancellationToken);
    }
}