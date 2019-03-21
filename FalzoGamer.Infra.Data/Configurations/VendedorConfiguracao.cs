using FalzoGamer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FalzoGamer.Infra.Data.Configurations
{
    public class VendedorConfiguracao : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            builder.ToTable("Vendedor");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Cpf).IsRequired();

            builder.Property(v => v.Celular).IsRequired();

            builder.Property(v => v.Novo).IsRequired();

            builder.Property(v => v.Created).IsRequired();

            builder.HasOne(v => v.Usuario).WithOne(u => u.Vendedor).HasForeignKey<Vendedor>(v => v.UsuarioId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
