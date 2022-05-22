using MeuVelho.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuVelho.Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<UserDomain>
    {
        public void Configure(EntityTypeBuilder<UserDomain> builder)
        {
            builder.ToTable("USER", "IDENTITY");

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.UserName).HasColumnName("USER_NAME").HasMaxLength(25).IsRequired();
            builder.Property(x => x.NormalizedUserName).HasColumnName("NORMALIZED_USER_NAME").HasMaxLength(25).IsRequired();
            builder.Property(x => x.Email).HasColumnName("EMAIL").HasMaxLength(200).IsRequired();
            builder.Property(x => x.NormalizedEmail).HasColumnName("NORMALIZED_EMAIL").HasMaxLength(200).IsRequired();
            builder.Property(x => x.EmailConfirmed).HasColumnName("EMAIL_CONFIRMED");
            builder.Property(x => x.PasswordHash).HasColumnName("PASSWORD").HasMaxLength(500).IsRequired();
            builder.Property(x => x.SecurityStamp).HasColumnName("SECURITY_STAMP").HasMaxLength(500).IsRequired();
            builder.Property(x => x.ConcurrencyStamp).HasColumnName("CONCURRENCY_STAMP").HasMaxLength(500).IsRequired();
            builder.Property(x => x.LockoutEnabled).HasColumnName("LOCKOUT_ENABLED");
            builder.Property(x => x.LockoutEnd).HasColumnName("LOCKOUT_END");
            builder.Property(x => x.AccessFailedCount).HasColumnName("ACCESS_FAILED_COUNT");
            builder.Property(x => x.PhoneNumber).HasColumnName("PHONE_NUMBER").HasMaxLength(20).IsRequired();
            builder.Property(x => x.PhoneNumberConfirmed).HasColumnName("PHONE_NUMBER_CONFIRMED");
            builder.Property(x => x.TwoFactorEnabled).HasColumnName("TWO_FACTOR_ENABLED");
        }
    }
}