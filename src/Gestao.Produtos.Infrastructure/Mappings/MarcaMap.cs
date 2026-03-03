using Gestao.Produtos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestao.Produtos.Infrastructure.Mappings
{
    public class MarcaMap : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.ToTable("Marcas");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
