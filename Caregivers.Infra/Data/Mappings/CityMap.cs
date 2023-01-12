using Caregivers.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Caregivers.Infra.Data.Mappings
{
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("CITY");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(50).IsRequired();
            builder.Property(x => x.IdState).HasColumnName("ID_STATE");

            builder.HasOne(x => x.State).WithMany(x => x.Cities).HasForeignKey(x => x.IdState).OnDelete(DeleteBehavior.Cascade);


            builder.HasData(new[]
            {
                new City(new Guid("00000000-0000-0000-0000-000000000001"), "Belo Horizonte", new Guid("00000000-0000-0000-0000-000000000001")),
                new City(new Guid("00000000-0000-0000-0000-000000000002"), "Nova Lima", new Guid("00000000-0000-0000-0000-000000000001")),
                new City(new Guid("00000000-0000-0000-0000-000000000003"), "Divinópolis", new Guid("00000000-0000-0000-0000-000000000001")),
                new City(new Guid("00000000-0000-0000-0000-000000000004"), "Rio Acima", new Guid("00000000-0000-0000-0000-000000000001")),
                new City(new Guid("00000000-0000-0000-0000-000000000005"), "Ouro Preto", new Guid("00000000-0000-0000-0000-000000000001")),
                new City(new Guid("00000000-0000-0000-0000-000000000006"), "Itabirito", new Guid("00000000-0000-0000-0000-000000000001")),
            });
        }
    }
}
