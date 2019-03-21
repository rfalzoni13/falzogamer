using FalzoGamer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FalzoGamer.Infra.Data.Configurations
{
    public class EnderecoConfiguracao : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Rua).HasMaxLength(440).IsRequired();

            builder.Property(e => e.Numero).IsRequired();

            builder.Property(e => e.Complemento).HasMaxLength(220).IsRequired();

            builder.Property(e => e.Bairro).HasMaxLength(110).IsRequired();

            builder.Property(e => e.Novo).IsRequired();

            builder.Property(e => e.Created).IsRequired();

            builder.HasOne(e => e.Usuario).WithOne(u => u.Endereco).HasForeignKey<Endereco>(e => e.UsuarioId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
