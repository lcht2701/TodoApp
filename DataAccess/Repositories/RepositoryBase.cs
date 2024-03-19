using BusinessObject.Entities;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
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

        public T? GetById(int id)
        {
            return dbSet.Find(id);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() => dbSet.Where(predicate));
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(() => dbSet.ToListAsync());
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
    }
}
