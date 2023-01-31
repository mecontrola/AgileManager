using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Enums;
using MeControla.Core.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public interface ICustomFieldRepository : IAsyncRepository<CustomField>
    {
        Task<bool> ExistsByKeyAsync(string key, CancellationToken cancellationToken);
        Task<IList<CustomField>> RetrieveActiveListAsync(CancellationToken cancellationToken);
        Task<CustomField> GetDataByCustomField(CustomFields customField, CancellationToken cancellationToken);
    }
}