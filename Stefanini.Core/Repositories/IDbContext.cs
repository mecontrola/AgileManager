using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace Stefanini.Core.Repositories
{
    public interface IDbContext : IDisposable, IAsyncDisposable, IInfrastructure<IServiceProvider>, IResettableService
    {
        ChangeTracker ChangeTracker { get; }
        DatabaseFacade Database { get; }
        DbContextId ContextId { get; }

        EntityEntry Add(object entity);
        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
    }
}