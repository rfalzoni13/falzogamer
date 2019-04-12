using FalzoGamer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FalzoGamer.Infra.Data.Configurations
{
    public class CidadeConfiguracao : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("Cidade");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.EstadoId).IsRequired();

            builder.Property(c => c.Nome).HasMaxLength(220).IsRequired();

            builder.Property(c => c.Novo).IsRequired();

            builder.Property(c => c.Created).IsRequired();

            builder.HasOne(c => c.Estado).WithMany(e => e.Cidades).HasForeignKey(c => c.EstadoId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
