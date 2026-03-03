using AutoMapper;
using Gestao.Produtos.Application.Exceptions;
using Gestao.Produtos.Application.Request;
using Gestao.Produtos.Application.Response;
using Gestao.Produtos.Application.Services.Interfaces;
using Gestao.Produtos.Domain.Entities;
using Gestao.Produtos.Domain.Enums;
using Gestao.Produtos.Domain.Interfaces;

namespace Gestao.Produtos.Application.Services
{
    public class ProdutoService(IProdutoRepository produtoRepository, IMapper mapper) : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository = produtoRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<int> CreateProduct(CreateProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var produto = new Produto(request.Nome, request.MarcaId, (TipoProdutoEnum)request.Tipo, request.DataValidade);

                var produtoEntity = await _produtoRepository.CreateAsync(produto);

                return produtoEntity.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductResponse> GetProduct(int id, CancellationToken cancellationToken)
        {
            try
            {
                ProductResponse response = new ProductResponse();
                var produto = await _produtoRepository.GetByIdAsync(id, cancellationToken);

                if (produto != null)
                {
                    response.DataInclusao = produto.DataInclusaoRegistro.ToShortDateString();
                    response.Nome = produto.Nome;
                    response.Tipo = produto.Tipo.ToString();
                    response.Marca = produto?.Marca?.Nome;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductResponse>> GetAllProducts(CancellationToken cancellationToken)
        {
            try
            {
                List<ProductResponse> response = new List<ProductResponse>();
                var produtos = await _produtoRepository.GetAllAsync(cancellationToken);

                if (produtos != null)
                {
                    foreach (var produto in produtos)
                    {
                        response.Add(new ProductResponse()
                        {
                            DataInclusao = produto.DataInclusaoRegistro.ToShortDateString(),
                            Nome = produto.Nome,
                            Tipo = produto.Tipo.ToString(),
                            Marca = produto.Marca.Nome,
                        });
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateProduct(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var produtoExistente = await _produtoRepository.GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new NotFoundException("Produto não encontrado");

                _mapper.Map(request, produtoExistente);

                return await _produtoRepository.UpdateAsync(produtoExistente, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            try
            {
                var produto = await _produtoRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException("Produto não encontrado");


                return await _produtoRepository.DeleteAsync(id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
