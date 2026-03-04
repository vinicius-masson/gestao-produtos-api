using AutoMapper;
using Gestao.Produtos.Application.Request;
using Gestao.Produtos.Application.Response;
using Gestao.Produtos.Domain.Entities;
using Gestao.Produtos.Domain.Enums;

namespace Gestao.Produtos.Application.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<CreateProductRequest, Produto>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => (TipoProdutoEnum)src.Tipo));

            CreateMap<UpdateProductRequest, Produto>();

            CreateMap<Produto, ProductResponse>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo.ToString()))
                .ForMember(dest => dest.Marca, opt => opt.MapFrom(src => src.Marca.Nome))
                .ForMember(dest => dest.DataValidade, opt => opt.MapFrom(src => src.DataValidade.GetValueOrDefault().ToShortDateString()));
        }
    }
}
