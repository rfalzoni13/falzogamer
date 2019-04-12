using FalzoGamer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FalzoGamer.Infra.Data.Configurations
{
    public class AcessoConfiguracao : IEntityTypeConfiguration<Acesso>
    {
        public void Configure(EntityTypeBuilder<Acesso> builder)
        {
            builder.ToTable("Acesso");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();

            builder.Property(c => c.Novo).IsRequired();

            builder.Property(c => c.Created).IsRequired();

        }
    }
}
