using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public interface IPreferenceCustomFieldRepository : IAsyncRepository<PreferenceCustomField>
    {
        Task<IList<PreferenceCustomField>> GetAllFieldsAsync(CancellationToken cancellationToken);
    }
}