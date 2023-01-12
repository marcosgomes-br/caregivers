using Caregivers.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caregivers.Infra.Data.Mappings
{
    public class LoginMap : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.ToTable("LOGIN", "IDENTITY");

            builder.HasNoKey();

            builder.Property(x => x.LoginProvider).HasColumnName("LOGIN_PROVIDER").HasMaxLength(20);
            builder.Property(x => x.ProviderKey).HasColumnName("PROVIDER_KEY").HasMaxLength(100);
            builder.Property(x => x.ProviderDisplayName).HasColumnName("PROVIDER_DISPLAY_NAME").HasMaxLength(20);
            builder.Property(x => x.UserId).HasColumnName("ID_USER");

            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        }
    }
}