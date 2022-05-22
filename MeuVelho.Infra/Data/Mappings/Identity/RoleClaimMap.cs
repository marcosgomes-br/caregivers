using MeuVelho.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuVelho.Infra.Data.Mappings
{
    public class RoleClaimMap : IEntityTypeConfiguration<RoleClaimDomain>
    {
        public void Configure(EntityTypeBuilder<RoleClaimDomain> builder)
        {
            builder.ToTable("ROLE_CLAIM", "IDENTITY");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");

            builder.Property(x => x.ClaimType).HasColumnName("CLAIM_TYPE").HasMaxLength(50);
            builder.Property(x => x.ClaimValue).HasColumnName("CLAIM_VALUE").HasMaxLength(50);
            builder.Property(x => x.RoleId).HasColumnName("ID_ROLE");
            builder.HasOne(x => x.Role).WithMany().HasForeignKey(x => x.RoleId);
        }
    }
}