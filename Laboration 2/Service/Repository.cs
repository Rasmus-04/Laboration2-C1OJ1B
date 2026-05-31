using Laboration_2.Data;
using Microsoft.EntityFrameworkCore;

namespace Laboration_2.Service
{
    public class Repository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.ChangeTracker.Clear();

            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}