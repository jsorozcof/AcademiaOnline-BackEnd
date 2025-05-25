using AcademiaOnline.Application.Common.Interfaces;
using AcademiaOnline.Infrastructure.Academia;
using Microsoft.EntityFrameworkCore;

namespace AcademiaOnline.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AcademiaOnlineBDContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AcademiaOnlineBDContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
