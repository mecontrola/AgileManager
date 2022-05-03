using Microsoft.EntityFrameworkCore;
using Stefanini.Core.Data.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Stefanini.Core.Repositories
{
    public abstract class BaseRepository<TEntity> : ContextRepository<TEntity>, IRepository<TEntity>
         where TEntity : class, IEntity
    {
        protected BaseRepository(IDbContext context, DbSet<TEntity> dbSet)
            : base(context, dbSet)
        { }

        public virtual TEntity Find(long id)
            => Find(itm => itm.Id.Equals(id));

        public virtual TEntity Find(Guid uuid)
            => Find(itm => itm.Uuid.Equals(uuid));

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
            => dbSet.AsNoTracking().Where(predicate).FirstOrDefault();
    }
}