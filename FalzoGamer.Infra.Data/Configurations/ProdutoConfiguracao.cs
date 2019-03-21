using FalzoGamer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FalzoGamer.Infra.Data.Configurations
{
    public class ProdutoConfiguracao : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CategoriaId).IsRequired();

            builder.Property(p => p.Nome).HasMaxLength(220).IsRequired();

            builder.Property(p => p.Marca).HasMaxLength(100).IsRequired();

            builder.Property(p => p.Preco).IsRequired();

            builder.Property(p => p.Tipo).HasMaxLength(100).IsRequired();

            builder.Property(p => p.Descricao).HasColumnType("text");

            builder.Property(p => p.Novo).IsRequired();

            builder.Property(p => p.Created).IsRequired();

            builder.HasOne(p => p.Categoria).WithMany(c => c.Produtos).HasForeignKey(p => p.CategoriaId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
