using Gestao.Produtos.Application.Response;

namespace Gestao.Produtos.Application.Services.Interfaces
{
    public interface IMarcaService
    {
        Task<List<MarcaResponse?>> GetAllMarcas(CancellationToken cancellationToken);
    }
}
