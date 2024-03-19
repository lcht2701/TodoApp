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

        public async Task<T> AddAsync(T entity)
        {
            dbSet.Add(entity);
            entity.CreatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
            foreach (var entity in entities)
            {
                entity.CreatedAt = DateTime.UtcNow;
            }
            await _context.SaveChangesAsync();
            return entities;
        }

        public async Task<T?> GetByIdAsync(Guid id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include)
        {
            var query = AddInclude(dbSet.AsQueryable(), include);
            return await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
        
        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include)
        {
            var query = AddInclude(dbSet.AsQueryable(), include);
            return await query.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetListAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include)
        {
            var query = AddInclude(dbSet.AsQueryable(), include);
            return await query.ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await dbSet.CountAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            entity.ModifiedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            entity.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
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

        #region Non-used
        //public T? GetById(Guid id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include)
        //{
        //    var query = AddInclude(dbSet.AsQueryable(), include);
        //    return query.FirstOrDefault(x => x.Id.Equals(id));
        //}
        //public IEnumerable<T> GetList(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include)
        //{
        //    var query = AddInclude(dbSet.AsQueryable(), include);
        //    return query.Where(predicate).ToList();
        //}
        //public IEnumerable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include)
        //{
        //    var query = AddInclude(dbSet.AsQueryable(), include);
        //    return query.ToList();
        //}
        //public int Count()
        //{
        //    return dbSet.Count();
        //}
        #endregion
    }
}
