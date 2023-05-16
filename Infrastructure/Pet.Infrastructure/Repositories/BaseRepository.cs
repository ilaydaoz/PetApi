using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pet.Infrastructure.Context;
using Shared.Pet.Entity;
using Shared.Pet.Repositories;
using System.Linq.Expressions;

namespace Pet.Infrastructure.Repositories
{
    public class BaseRepository<T, IContext> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly EfDbContext _context;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(EfDbContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        public bool Delete(T entity)
        {
            EntityEntry<T> entityEntry = _context.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }
        public bool DeleteRange(List<T> entity)
        {
            _context.RemoveRange(entity);
            return true;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IEnumerable<T> GetByFilter(Func<T, bool> filter)
        {
            return _context.Set<T>().Where(filter).ToList();
        }

        public async Task<Guid> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity.Id;
        }

        public async Task<T> InsertAsync(T entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>().ToListAsync();
        }
    }
}
