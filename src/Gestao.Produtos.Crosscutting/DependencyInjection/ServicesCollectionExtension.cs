using Gestao.Produtos.Application.Services;
using Gestao.Produtos.Application.Services.Interfaces;
using Gestao.Produtos.Domain.Interfaces;
using Gestao.Produtos.Infrastructure.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Gestao.Produtos.Crosscutting.DependencyInjection
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddServiceExtension(this IServiceCollection services, IConfiguration _)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IMarcaService, MarcaService>();

            return services;
        }
    }
}
