using Gestao.Produtos.Application.Response;
using Gestao.Produtos.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gestao.Produtos.API.Controllers
{
    [ApiController]
    [Route("api/marcas")]
    public class MarcaController : Controller
    {
        private readonly IMarcaService _marcaService;
        public MarcaController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        [HttpGet("buscar-marcas")]
        [ProducesResponseType(typeof(MarcaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await _marcaService.GetAllMarcas(cancellationToken);

            if (response == null) return BadRequest("Nenhuma marca encontrada");

            return Ok(response);
        }
    }
}
