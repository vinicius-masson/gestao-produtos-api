using Gestao.Produtos.Application.Request;
using Gestao.Produtos.Application.Response;

namespace Gestao.Produtos.Application.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<int> CreateProduct(CreateProductRequest request, CancellationToken cancellationToken);
        Task<ProductResponse> GetProduct(int id, CancellationToken cancellationToken);
        Task<List<ProductResponse?>> GetAllProducts(CancellationToken cancellationToken);
        Task<bool> UpdateProduct(UpdateProductRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteProduct(int id, CancellationToken cancellationToken);

    }
}
