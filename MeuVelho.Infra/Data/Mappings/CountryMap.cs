using MeuVelho.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MeuVelho.Infra.Data.Mappings
{
    public class CountryMap : IEntityTypeConfiguration<CountryDomain>
    {
        public void Configure(EntityTypeBuilder<CountryDomain> builder)
        {
            builder.ToTable("COUNTRY");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Name).HasMaxLength(20).HasColumnName("NAME");

            builder.HasData(new[]
            {
                new CountryDomain(new Guid("00000000-0000-0000-0000-000000000001"), "Brasil")
            });
        }
    }
}
