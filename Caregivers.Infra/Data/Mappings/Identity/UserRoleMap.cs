using Caregivers.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caregivers.Infra.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRoleDomain>
    {
        public void Configure(EntityTypeBuilder<UserRoleDomain> builder)
        {
            builder.ToTable("USER_ROLE", "IDENTITY");

            builder.HasNoKey();
            builder.Property(x => x.RoleId).HasColumnName("ID_ROLE");
            builder.Property(x => x.UserId).HasColumnName("ID_USER");

            builder.HasOne(x => x.Role).WithMany().HasForeignKey(x => x.RoleId);
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        }
    }
}