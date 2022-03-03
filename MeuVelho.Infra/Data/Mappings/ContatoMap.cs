using MeuVelho.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuVelho.Infra.Data.Mappings
{
    public class ContatoMap : IEntityTypeConfiguration<ContatoDomain>
    {
        public void Configure(EntityTypeBuilder<ContatoDomain> builder)
        {
            builder.ToTable("CONTATO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Data).HasColumnName("DATA").IsRequired();
            builder.Property(x => x.IdCuidador).HasColumnName("ID_CUIDADOR");

            builder.HasOne(x => x.Cuidador).WithMany(x => x.Contatos).HasForeignKey(x => x.IdCuidador).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
