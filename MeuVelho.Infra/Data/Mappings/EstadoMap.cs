using MeuVelho.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MeuVelho.Infra.Data.Mappings
{
    public class EstadoMap : IEntityTypeConfiguration<EstadoDomain>
    {
        public void Configure(EntityTypeBuilder<EstadoDomain> builder)
        {
            builder.ToTable("ESTADO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Nome).HasColumnName("NOME").HasMaxLength(30).IsRequired();
            builder.Property(x => x.IdPais).HasColumnName("ID_PAIS").IsRequired();

            builder.HasOne(x => x.Pais).WithMany(x => x.Estados).HasForeignKey(x => x.IdPais).OnDelete(DeleteBehavior.Cascade);


            builder.HasData(new[]
            {
                new EstadoDomain(new Guid("00000000-0000-0000-0000-000000000001"), "Minas Gerais", new Guid("00000000-0000-0000-0000-000000000001")),
                new EstadoDomain(new Guid("00000000-0000-0000-0000-000000000002"), "Rio de Janeiro", new Guid("00000000-0000-0000-0000-000000000001")),
                new EstadoDomain(new Guid("00000000-0000-0000-0000-000000000003"), "São Paulo", new Guid("00000000-0000-0000-0000-000000000001")),
            });
        }
    }
}
