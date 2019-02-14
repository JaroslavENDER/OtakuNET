using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OtakuNET.Domain.DataProviders;
using OtakuNET.Domain.Entities;

namespace OtakuNET.Repositories
{
    public abstract class EntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : EntityBase
    {
        protected IDbContext DbContext { get; }
        protected DbSet<TEntity> DbSet { get; }

        protected EntityRepositoryBase(IDbContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<TEntity>();
        }

        public virtual void Save(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.IsNew())
                Add(entity);
            else
                Update(entity);
        }

        public virtual void Save(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Save(entity);
            }
        }

        public virtual async void DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            DbSet.Remove(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public virtual async Task<TEntity> GetByIdAsync(int id, bool throwExceptionIfNotFound = true)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity == null && throwExceptionIfNotFound)
                throw new ArgumentException($"Entity with id '{id}' not found.");

            return entity;
        }

        public virtual async Task<TResult> GetByIdAsync<TResult>(int id, Expression<Func<TEntity, TResult>> selector, bool throwExceptionIfNotFound = true)
        {
            var entityQueryable = GetAll().Where(e => e.Id == id).Select(selector);

            return throwExceptionIfNotFound
                ? await entityQueryable.SingleAsync()
                : await entityQueryable.SingleOrDefaultAsync();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual IQueryable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return GetAll().Select(selector);
        }

        public virtual IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public virtual IQueryable<TResult> GetMany<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
        {
            return GetAll().Where(predicate).Select(selector);
        }

        public virtual async Task<bool> AnyAsync()
        {
            return await GetAll().AnyAsync();
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().AnyAsync(predicate);
        }

        protected virtual void Add(TEntity entity)
        {
            if (!entity.CreatedAt.HasValue)
                entity.CreatedAt = DateTime.UtcNow;

            DbSet.Add(entity);
        }

        protected virtual void Update(TEntity entity)
        {
            var entityState = DbContext.GetEntityState(entity);
            if (entityState == EntityState.Detached)
                throw new InvalidOperationException("Can't update detached entity.");

            if (entityState == EntityState.Modified)
                entity.UpdatedAt = DateTime.UtcNow;
        }
    }
}
