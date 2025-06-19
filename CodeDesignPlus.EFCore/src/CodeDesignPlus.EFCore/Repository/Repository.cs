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
    public abstract class Repository : IRepository
    {
        protected readonly DbContext context;
        public Repository(DbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TContext GetContext<TContext>() where TContext : DbContext => (TContext)this.context;

        public DbSet<TEntity> GetEntity<TEntity>() where TEntity : class // , IEntityBase<TKey, TUserKey>
            => this.context.Set<TEntity>();

        public async Task<TEntity> CreateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await this.context.AddAsync(entity, cancellationToken);
            await this.context.SaveChangesAsync(cancellationToken);
            return entity;
        }
        public async Task<bool> UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            this.context.Set<TEntity>().Update(entity);
            var result = await this.context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }
        public async Task<bool> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            var entity = await this.context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync(cancellationToken);
            if (entity != null)
            {
                this.context.Remove(entity);
                return await this.context.SaveChangesAsync(cancellationToken) > 0;
            }
            return false;
        }

        public async Task<List<TEntity>> CreateRangeAsync<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            if (!entities.Any()) return entities;
            await this.context.Set<TEntity>().AddRangeAsync(entities);
            await this.context.SaveChangesAsync(cancellationToken);
            return entities;
        }

        public async Task<bool> UpdateRangeAsync<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default)
            where TEntity : class
        {
            if (!entities.Any()) return false;
            this.context.Set<TEntity>().UpdateRange(entities);
            return await this.context.SaveChangesAsync(cancellationToken) == entities.Count;
        }

        public async Task<bool> DeleteAsync<TEntity>(List<TEntity> entities, CancellationToken cancellationToken = default)
           where TEntity : class
        {    
            if (!entities.Any()) return false;

            this.context.RemoveRange(entities);
            return await this.context.SaveChangesAsync(cancellationToken) == entities.Count;
        }

        public async Task<bool> ChangeStateAsync<TEntity, TKey>(TKey id, EntityState state, CancellationToken cancellation = default)
            where TEntity : class
        {
            var entity = await this.context.Set<TEntity>().FirstOrDefaultAsync();
            if (entity != null)
            {
                entity.State = state;
                return await this.context.SaveChangesAsync(cancellation) > 0;
            }
            return false;
        }


        public async Task<TResult> TransactionAsync<TResult>(Func<DbContext, Task<TResult>> process, IsolationLevel isolation = IsolationLevel.ReadUncommitted
            , CancellationToken cancellation = default)
        {
            var strategy = this.context.Database.CreateExecutionStrategy();
            return await strategy.ExecuteAsync(async (cancellation) =>
            {
                using var transaction = await this.context.Database.BeginTransactionAsync(cancellation);
                var result = await process(this.context);
                await transaction.CommitAsync();
                return result;
            }, cancellation);
        }
    }
}
