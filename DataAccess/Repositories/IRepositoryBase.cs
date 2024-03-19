using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        T? GetById(int id);
        Task<T?> GetByIdAsync(int id);
        T? Get(Expression<Func<T, bool>> predicate);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetList(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        int Count();
        Task<int> CountAsync();
        void Update(T entity);
        void Remove(T entity);
        void Dispose();
    }
}
