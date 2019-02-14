using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OtakuNET.Domain.Entities;

namespace OtakuNET.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : IEntity
    {
        void Save(TEntity entity);
        void Save(IEnumerable<TEntity> entities);
        void DeleteAsync(int id);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
        Task<TEntity> GetByIdAsync(int id, bool throwExceptionIfNotFound = true);
        Task<TResult> GetByIdAsync<TResult>(int id, Expression<Func<TEntity, TResult>> selector, bool throwExceptionIfNotFound = true);
        IQueryable<TEntity> GetAll();
        IQueryable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector);
        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TResult> GetMany<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector);
        Task<bool> AnyAsync();
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
