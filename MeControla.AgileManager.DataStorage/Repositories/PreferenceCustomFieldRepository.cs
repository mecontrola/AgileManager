using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public class PreferenceCustomFieldRepository : BaseAsyncRepository<PreferenceCustomField>, IPreferenceCustomFieldRepository
    {
        public PreferenceCustomFieldRepository(IDbAppContext context)
            : base(context, context.PreferenceCustomFields)
        { }

        public async Task<IList<PreferenceCustomField>> GetAllFieldsAsync(CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Include(entity => entity.CustomField)
                          .ToListAsync(cancellationToken);
    }
}