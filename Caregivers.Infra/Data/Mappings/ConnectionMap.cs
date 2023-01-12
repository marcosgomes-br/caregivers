using Caregivers.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caregivers.Infra.Data.Mappings
{
    public class ConnectionMap : IEntityTypeConfiguration<Connection>
    {
        public void Configure(EntityTypeBuilder<Connection> builder)
        {
            builder.ToTable("CONNECTION");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Date).HasColumnName("DATE").IsRequired();
            builder.Property(x => x.IdCaregiver).HasColumnName("ID_CAREGIVER");

            builder.HasOne(x => x.Caregiver).WithMany(x => x.Connections).HasForeignKey(x => x.IdCaregiver).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
