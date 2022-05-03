using Stefanini.Core.Data.Entities;

namespace Stefanini.Core.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        TEntity Find(long id);
    }
}
