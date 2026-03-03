using Gestao.Produtos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Produtos.Infrastructure.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            var entry = _context.Entry<T>(entity);
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await GetById(id);
            if (entity == null)
                return false;

            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        private async Task<T> GetById(int id)
        {
            return await _context.FindAsync<T>(id);
        }
    }
}
