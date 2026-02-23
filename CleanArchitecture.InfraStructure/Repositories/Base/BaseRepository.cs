using CleanArchitecture.Domain.Repositories.Interfaces;
using CleanArchitecture.InfraStructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.InfraStructure.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly CleanArchitectureContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(CleanArchitectureContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task Add(T entity)
        {            
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task ToUpdate(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(long id)
        {
            var entidade = await GetById(id);
            if (entidade != null)
            {
                _dbSet.Remove(entidade);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<T> GetById(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
