using FalzoGamer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FalzoGamer.Infra.Data.Configurations
{
    public class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.AcessoId).IsRequired();

            builder.Property(u => u.Nome).HasMaxLength(220).IsRequired();

            builder.Property(u => u.Sexo).HasMaxLength(100).IsRequired();

            builder.Property(u => u.Email).HasMaxLength(220).IsRequired();

            builder.Property(u => u.Login).HasMaxLength(100).IsRequired();

            builder.Property(u => u.Novo).IsRequired();

            builder.Property(u => u.Created).IsRequired();

            builder.HasOne(u => u.Acesso).WithOne(a => a.Usuario).HasForeignKey<Usuario>(u => u.AcessoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
