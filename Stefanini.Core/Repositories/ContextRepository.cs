using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Stefanini.Core.Data.Entities;

namespace Stefanini.Core.Repositories
{
    public abstract class ContextRepository<TEntity>
         where TEntity : class, IEntity
    {
        protected readonly IDbContext context;
        protected readonly DbSet<TEntity> dbSet;

        protected ContextRepository(IDbContext context, DbSet<TEntity> dbSet)
        {
            this.context = context;
            this.dbSet = dbSet;
        }

        public DatabaseFacade Database()
            => context.Database;
    }
}