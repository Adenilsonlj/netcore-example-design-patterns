using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Example.Domain.SeedWork;

namespace Example.Infra.Data.Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            await _unitOfWork.Context.Set<TEntity>().AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _unitOfWork.Context.Set<TEntity>().Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<TEntity> GetAll() => _unitOfWork.Context.Set<TEntity>().AsQueryable();

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression) => await GetAll().Where(expression).ToListAsync();

        public async Task<TEntity> GetByIdAsync(int id, bool noTracking) => await _unitOfWork.Context.Set<TEntity>().FindAsync(id);

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression) => GetAll().Where(expression);

        public virtual IQueryable<TEntity> Include<TProperty>(IQueryable<TEntity> query, Expression<Func<TEntity, TProperty>> path) => query.Include(path);
        
        public async Task DeleteAsync(TEntity entity)
        {
            _unitOfWork.Context.Set<TEntity>().Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await GetAll().ToListAsync();
    }
}
