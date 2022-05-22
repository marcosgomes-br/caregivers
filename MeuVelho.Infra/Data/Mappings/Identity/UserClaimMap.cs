using MeuVelho.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuVelho.Infra.Data.Mappings
{
    public class UserClaimMap : IEntityTypeConfiguration<UserClaimDomain>
    {
        public void Configure(EntityTypeBuilder<UserClaimDomain> builder)
        {
            builder.ToTable("USER_CLAIM", "IDENTITY");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.ClaimType).HasColumnName("CLAIM_TYPE").HasMaxLength(50);
            builder.Property(x => x.ClaimValue).HasColumnName("CLAIM_VALUE").HasMaxLength(50);
            builder.Property(x => x.UserId).HasColumnName("ID_USER");
        }
    }
}