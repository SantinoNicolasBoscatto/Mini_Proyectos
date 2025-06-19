using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeDesignPlus.EFCore.Repository
{
    public interface IRepository
    {
        Task<bool> ChangeStateAsync<TEntity, TKey>(TKey id, EntityState state, CancellationToken cancellation = default) where TEntity : class;
        Task<TEntity> CreateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        Task<List<TEntity>> CreateRangeAsync<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : class;
        Task<bool> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) where TEntity : class;
        Task<bool> DeleteAsync<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : class;
        TContext GetContext<TContext>() where TContext : DbContext;
        DbSet<TEntity> GetEntity<TEntity>() where TEntity : class;
        Task<TResult> TransactionAsync<TResult>(Func<DbContext, Task<TResult>> process, IsolationLevel isolation = IsolationLevel.ReadUncommitted, CancellationToken cancellation = default);
        Task<bool> UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        Task<bool> UpdateRangeAsync<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : class;
    }
}
