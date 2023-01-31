using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public class ClassOfServiceRepository : BaseAsyncRepository<ClassOfService>, IClassOfServiceRepository
    {
        public ClassOfServiceRepository(IDbAppContext context)
            : base(context, context.ClasseOfServices)
        { }

        public async Task<bool> ExistsByKeyAsync(string key, CancellationToken cancellationToken)
            => await ExistsAsync(entity => entity.Key == key, cancellationToken);

        public async Task<IDictionary<string, long>> ToDictionaryAsync(CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .ToDictionaryAsync(entity => entity.Key, entity => entity.Id, cancellationToken);
    }
}