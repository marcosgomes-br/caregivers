using MeuVelho.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuVelho.Infra.Data.Mappings
{
    public class UserTokenMap : IEntityTypeConfiguration<UserTokenDomain>
    {
        public void Configure(EntityTypeBuilder<UserTokenDomain> builder)
        {
            builder.ToTable("USER_TOKEN", "IDENTITY");
            builder.HasNoKey();
            builder.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(50);
            builder.Property(x => x.Value).HasColumnName("VALUE").HasMaxLength(150);
            builder.Property(x => x.LoginProvider).HasColumnName("LOGIN_PROVIDER").HasMaxLength(20);
            builder.Property(x => x.UserId).HasColumnName("ID_USER");

            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        }
    }
}