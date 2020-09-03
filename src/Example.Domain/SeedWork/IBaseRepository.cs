using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Example.Domain.SeedWork
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> InsertOrUpdateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        IQueryable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> GetByIdAsync(int id, bool noTracking);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);

        Task<IEnumerable<TEntity>> GetAllAsync();

        IQueryable<TEntity> Include<TProperty>(IQueryable<TEntity> query, Expression<Func<TEntity, TProperty>> path);

        Task DeleteAsync(TEntity entity);
    }
}
