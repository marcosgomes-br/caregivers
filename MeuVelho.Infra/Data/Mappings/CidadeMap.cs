using MeuVelho.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MeuVelho.Infra.Data.Mappings
{
    public class CidadeMap : IEntityTypeConfiguration<CidadeDomain>
    {
        public void Configure(EntityTypeBuilder<CidadeDomain> builder)
        {
            builder.ToTable("CIDADE");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Nome).HasColumnName("NOME").HasMaxLength(50).IsRequired();
            builder.Property(x => x.IdEstado).HasColumnName("ID_ESTADO");

            builder.HasOne(x => x.Estado).WithMany(x => x.Cidades).HasForeignKey(x => x.IdEstado).OnDelete(DeleteBehavior.Cascade);


            builder.HasData(new[]
            {
                new CidadeDomain(new Guid("00000000-0000-0000-0000-000000000001"), "Belo Horizonte", new Guid("00000000-0000-0000-0000-000000000001")),
                new CidadeDomain(new Guid("00000000-0000-0000-0000-000000000002"), "Nova Lima", new Guid("00000000-0000-0000-0000-000000000001")),
                new CidadeDomain(new Guid("00000000-0000-0000-0000-000000000003"), "Divinópolis", new Guid("00000000-0000-0000-0000-000000000001")),
                new CidadeDomain(new Guid("00000000-0000-0000-0000-000000000004"), "Rio Acima", new Guid("00000000-0000-0000-0000-000000000001")),
                new CidadeDomain(new Guid("00000000-0000-0000-0000-000000000005"), "Ouro Preto", new Guid("00000000-0000-0000-0000-000000000001")),
                new CidadeDomain(new Guid("00000000-0000-0000-0000-000000000006"), "Itabirito", new Guid("00000000-0000-0000-0000-000000000001")),
            });
        }
    }
}
