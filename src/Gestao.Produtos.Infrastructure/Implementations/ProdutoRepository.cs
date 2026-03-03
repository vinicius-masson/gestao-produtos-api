using Gestao.Produtos.Domain.Entities;
using Gestao.Produtos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Produtos.Infrastructure.Implementations
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext context) : base(context) { }

        public async Task<List<Produto?>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Produtos.Include(p => p.Marca).ToListAsync();
        }

        public async Task<Produto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context
                .Produtos
                .Include(p => p.Marca)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
