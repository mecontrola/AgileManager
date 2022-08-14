using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public class CustomfieldRepository : BaseAsyncRepository<Customfield>, ICustomfieldRepository
    {
        public CustomfieldRepository(IDbAppContext context)
            : base(context, context.Customfields)
        { }

        public async Task<bool> ExistsByKeyAsync(string key, CancellationToken cancellationToken)
            => await ExistsAsync(entity => entity.Key == key, cancellationToken);

        public async Task<IList<Customfield>> RetrieveActiveListAsync(CancellationToken cancellationToken)
            => await FindAllAsync(entity => entity.Active, cancellationToken);
    }
}