using AutoMapper;
using Gestao.Produtos.Application.Response;
using Gestao.Produtos.Application.Services.Interfaces;
using Gestao.Produtos.Domain.Interfaces;

namespace Gestao.Produtos.Application.Services
{
    public class MarcaService(IMarcaRepository marcaRepository, IMapper mapper) : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository = marcaRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<MarcaResponse?>> GetAllMarcas(CancellationToken cancellationToken)
        {
            try
            {
                List<MarcaResponse> response = new List<MarcaResponse>();
                var marcas = await _marcaRepository.GetAllAsync(cancellationToken);

                if (marcas != null)
                {
                    foreach (var marca in marcas)
                    {
                        response.Add(new MarcaResponse()
                        {
                            Id = marca.Id,
                            DataInclusao = marca.DataInclusaoRegistro.ToShortDateString(),
                            Nome = marca.Nome
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
    }
}
