using Gestao.Produtos.Domain.Entities;
using Gestao.Produtos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Produtos.Infrastructure.Implementations
{
    public class MarcaRepository : BaseRepository<Marca>, IMarcaRepository
    {
        public MarcaRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<Marca?>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Marcas.ToListAsync();
        }

        public async Task<Marca?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Marcas.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
