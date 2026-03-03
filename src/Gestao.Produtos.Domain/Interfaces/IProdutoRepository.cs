using Gestao.Produtos.Domain.Entities;

namespace Gestao.Produtos.Domain.Interfaces
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<Produto?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Produto?>> GetAllAsync(CancellationToken cancellationToken);
    }
}