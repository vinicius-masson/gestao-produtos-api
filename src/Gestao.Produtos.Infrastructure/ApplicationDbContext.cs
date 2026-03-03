using Gestao.Produtos.Domain.Entities;
using Gestao.Produtos.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Produtos.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new MarcaMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
    }
}
