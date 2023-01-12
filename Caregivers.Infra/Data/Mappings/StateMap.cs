using Caregivers.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Caregivers.Infra.Data.Mappings
{
    public class StateMap : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("STATE");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(30).IsRequired();
            builder.Property(x => x.IdCountry).HasColumnName("ID_COUNTRY").IsRequired();

            builder.HasOne(x => x.Country).WithMany(x => x.States).HasForeignKey(x => x.IdCountry).OnDelete(DeleteBehavior.Cascade);


            builder.HasData(new[]
            {
                new State(new Guid("00000000-0000-0000-0000-000000000001"), "Minas Gerais", new Guid("00000000-0000-0000-0000-000000000001")),
                new State(new Guid("00000000-0000-0000-0000-000000000002"), "Rio de Janeiro", new Guid("00000000-0000-0000-0000-000000000001")),
                new State(new Guid("00000000-0000-0000-0000-000000000003"), "São Paulo", new Guid("00000000-0000-0000-0000-000000000001")),
            });
        }
    }
}
