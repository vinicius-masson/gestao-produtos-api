using Gestao.Produtos.Application.Exceptions;
using Gestao.Produtos.Application.Request;
using Gestao.Produtos.Application.Response;
using Gestao.Produtos.Application.Services.Interfaces;
using Gestao.Produtos.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Gestao.Produtos.API.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost("criar-produto")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
        {
            if (!Enum.IsDefined(typeof(TipoProdutoEnum), request.Tipo))
                throw new ArgumentException($"Valor {request.Tipo} não é válido para TipoProdutoEnum");

            if (request.DataValidade.HasValue)
            {
                if (request.DataValidade.Value <= DateTime.Now)
                    throw new BusinessException($"Valor {request.Tipo} não é válido para TipoProdutoEnum");
            }

            var response = await _produtoService.CreateProduct(request, cancellationToken);

            return Created(string.Empty, response);
        }

        [HttpGet("buscar-produto/{id}")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var response = await _produtoService.GetProduct(id, cancellationToken);

            if (response == null) return BadRequest("Produto não encontrado");
            
            return Ok(response);
        }

        [HttpGet("buscar-produtos")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await _produtoService.GetAllProducts(cancellationToken);

            if (response == null) return BadRequest("Nenhum produto encontrado");

            return Ok(response);
        }

        [HttpPut("editar-produto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] UpdateProductRequest request, CancellationToken cancellationToken)
        {
            if (!Enum.IsDefined(typeof(TipoProdutoEnum), request.Tipo))
                throw new ArgumentException($"Valor {request.Tipo} não é válido para TipoProdutoEnum");

            if (request.DataValidade.HasValue)
            {
                if (request.DataValidade.Value <= DateTime.Now)
                    throw new BusinessException($"Valor {request.Tipo} não é válido para TipoProdutoEnum");
            }

            var response = await _produtoService.UpdateProduct(request, cancellationToken);

            if (response) return Ok("Produto editado com sucesso");

            return BadRequest("Falha ao editar produto");
        }

        [HttpDelete("excluir-produto/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {

            var response = await _produtoService.DeleteProduct(id, cancellationToken);

            if (response) return Ok("Produto excluído com sucesso");

            return BadRequest("Falha ao excluir produto");
        }
    }
}
