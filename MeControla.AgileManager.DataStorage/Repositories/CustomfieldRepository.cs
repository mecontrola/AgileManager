using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Enums;
using MeControla.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public class CustomFieldRepository : BaseAsyncRepository<CustomField>, ICustomFieldRepository
    {
        public CustomFieldRepository(IDbAppContext context)
            : base(context, context.CustomFields)
        { }

        public async Task<bool> ExistsByKeyAsync(string key, CancellationToken cancellationToken)
            => await ExistsAsync(entity => entity.Key == key, cancellationToken);

        public async Task<IList<CustomField>> RetrieveActiveListAsync(CancellationToken cancellationToken)
            => await FindAllAsync(entity => (context as IDbAppContext).PreferenceCustomFields.Any(itm => entity.Id == itm.CustomFieldId), cancellationToken);

        public async Task<CustomField> GetDataByCustomField(CustomFields customField, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Where(entity => entity.Preference.Type == customField)
                          .FirstOrDefaultAsync(cancellationToken);
    }
}