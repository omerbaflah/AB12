using AB12.Domain.Base.Common;
using AB12.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AB12.Infrastructure.Components.Common
{
    public class BaseRepo<T> where T : AuditableEntity
    {
        private readonly AppDbContext _context;
        public BaseRepo(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetByIdAsync(string id, bool includeSoftDeleted)
        {
            return await _context.Set<T>()
                .Where(x => x.DeletedAt == null)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<List<T>> GetAllAsync(bool includeSoftDeleted)
        {
            return await _context.Set<T>()
                .Where(x => x.DeletedAt == null)
                .ToListAsync();
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> SoftDeleteAsync(T entity)
        {
            entity.DeletedAt = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
