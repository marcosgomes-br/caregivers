using MeuVelho.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuVelho.Infra.Data.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<RoleDomain>
    {
        public void Configure(EntityTypeBuilder<RoleDomain> builder)
        {
            builder.ToTable("ROLE", "IDENTITY");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Name).HasColumnName("NAME");
            builder.Property(x => x.NormalizedName).HasColumnName("NORMALIZED_NAME");
            builder.Property(x => x.ConcurrencyStamp).HasColumnName("CONCURRENCY_STAMP");
        }
    }
}