using MeuVelho.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuVelho.Infra.Data.Mappings
{
    public class ConnectionMap : IEntityTypeConfiguration<ConnectionDomain>
    {
        public void Configure(EntityTypeBuilder<ConnectionDomain> builder)
        {
            builder.ToTable("CONTATO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Date).HasColumnName("DATA").IsRequired();
            builder.Property(x => x.IdCaregiver).HasColumnName("ID_CUIDADOR");

            builder.HasOne(x => x.Caregiver).WithMany(x => x.Connections).HasForeignKey(x => x.IdCaregiver).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
