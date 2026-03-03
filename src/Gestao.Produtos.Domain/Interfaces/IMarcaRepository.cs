using Gestao.Produtos.Domain.Entities;

namespace Gestao.Produtos.Domain.Interfaces
{
    public interface IMarcaRepository : IBaseRepository<Marca>
    {
        Task<Marca?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Marca?>> GetAllAsync(CancellationToken cancellationToken);
    }
}
