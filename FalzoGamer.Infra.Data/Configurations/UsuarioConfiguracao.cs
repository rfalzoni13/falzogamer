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

            builder.Property(u => u.Nome).HasMaxLength(220).IsRequired();

            builder.Property(u => u.Sexo).HasMaxLength(100).IsRequired();

            builder.Property(u => u.Email).HasMaxLength(220).IsRequired();

            builder.Property(u => u.Login).HasMaxLength(100).IsRequired();

            builder.Property(u => u.Senha).HasMaxLength(500).IsRequired();

            builder.Property(u => u.Novo).IsRequired();

            builder.Property(u => u.Created).IsRequired();
        }
    }
}
