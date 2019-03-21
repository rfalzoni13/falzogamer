using FalzoGamer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FalzoGamer.Infra.Data.Configurations
{
    public class EstadoConfiguracao : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("Estado");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome).HasMaxLength(220).IsRequired();

            builder.Property(e => e.Sigla).IsRequired();

            builder.Property(e => e.Novo).IsRequired();

            builder.Property(e => e.Created).IsRequired();
        }
    }
}
