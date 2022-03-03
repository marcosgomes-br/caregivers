using MeuVelho.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MeuVelho.Infra.Data.Mappings
{
    public class PaisMap : IEntityTypeConfiguration<PaisDomain>
    {
        public void Configure(EntityTypeBuilder<PaisDomain> builder)
        {
            builder.ToTable("PAIS");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Nome).HasMaxLength(20).HasColumnName("NOME");

            builder.HasData(new[]
            {
                new PaisDomain(new Guid("00000000-0000-0000-0000-000000000001"), "Brasil")
            });
        }
    }
}
