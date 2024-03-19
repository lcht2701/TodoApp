using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        T? GetById(Guid id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include);
        Task<T?> GetByIdAsync(Guid id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include);
        IEnumerable<T> GetList(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include);
        IEnumerable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include);
        Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include);
        int Count();
        Task<int> CountAsync();
        void Update(T entity);
        void Remove(T entity);
        void Dispose();
    }
}
