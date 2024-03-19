using BusinessObject.Entities;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<T> dbSet;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
            entity.CreatedAt = DateTime.Now;
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
            foreach (var entity in entities)
            {
                entity.CreatedAt = DateTime.Now;
            }
            _context.SaveChanges();
        }

        public T? GetById(Guid id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            var query = AddInclude(dbSet, include);
            return query.FirstOrDefault(x => x.Id.Equals(id));
        }

        public async Task<T?> GetByIdAsync(Guid id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            var query = AddInclude(dbSet, include);
            return await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include)
        {
            var query = AddInclude(dbSet, include);
            return query.Where(predicate).ToList();
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include)
        {
            var query = AddInclude(dbSet, include);
            return await Task.Run(() => query.Where(predicate));
        }

        public IEnumerable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include)
        {
            var query = AddInclude(dbSet, include);
            return query.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include)
        {
            var query = AddInclude(dbSet, include);
            return await Task.Run(() => query.ToListAsync());
        }

        public int Count()
        {
            return dbSet.Count();
        }

        public async Task<int> CountAsync()
        {
            return await dbSet.CountAsync();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            entity.ModifiedAt = DateTime.Now;
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            entity.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        private IQueryable<T> AddInclude(IQueryable<T> query, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include)
        {
            if (include != null)
            {
                query = include(query);
            }

            return query;
        }
    }
}
