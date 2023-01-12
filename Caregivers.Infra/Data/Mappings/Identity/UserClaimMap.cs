using Caregivers.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caregivers.Infra.Data.Mappings
{
    public class UserClaimMap : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
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