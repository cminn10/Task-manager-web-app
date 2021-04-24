using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IAsyncRepository<T> where T: class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdWithIncludeAsync(Expression<Func<T, bool>> where, Expression<Func<T, object>> include);
        Task<IEnumerable<T>> ListAllWithFilterAsync(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity, params Expression<Func<T, object>>[] includeProperties);
        Task DeleteAsync(T entity);
    }
}