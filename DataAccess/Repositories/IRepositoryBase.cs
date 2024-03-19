using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<T?> GetByIdAsync(Guid id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<IEnumerable<T>> GetListAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<int> CountAsync();
        Task<T> UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        void Dispose();
        #region Non-used
        //T? GetById(Guid id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        //IEnumerable<T> GetList(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        //IEnumerable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        //int Count(); 
        #endregion
    }
}
