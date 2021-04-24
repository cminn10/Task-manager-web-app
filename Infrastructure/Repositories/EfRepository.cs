using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EfRepository<T>: IAsyncRepository<T> where T: class
    {
        protected readonly TaskManagerDbContext _dbContext;

        public EfRepository(TaskManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetByIdWithIncludeAsync(Expression<Func<T, bool>> where, Expression<Func<T, object>> include)
        {
            return await _dbContext.Set<T>().Include(include).FirstOrDefaultAsync(where);
        }
        
        public virtual async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> ListAllWithFilterAsync(Expression<Func<T, bool>> where)
        {
            return await _dbContext.Set<T>().Where(where).ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity, params Expression<Func<T, object>>[] includeProperties)
        {
            var dbEntry = _dbContext.Entry(entity);
            foreach (var includeProperty in includeProperties)
            {
                dbEntry.Property(includeProperty).IsModified = true;
            }
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}