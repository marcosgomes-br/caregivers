using MeuVelho.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuVelho.Infra.Data.Mappings
{
    public class CuidadorMap : IEntityTypeConfiguration<CuidadorDomain>
    {
        public void Configure(EntityTypeBuilder<CuidadorDomain> builder)
        {
            builder.ToTable("CUIDADOR");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Nome).HasMaxLength(150).HasColumnName("NOME").IsRequired();
            builder.Property(x => x.Sexo).HasColumnName("SEXO").IsRequired();
            builder.Property(x => x.Foto).HasMaxLength(250).HasColumnName("FOTO").IsRequired();
            builder.Property(x => x.Biografia).HasMaxLength(1000).HasColumnName("BIOGRAFIA").IsRequired();
            builder.Property(x => x.Whatsapp).HasMaxLength(30).HasColumnName("WHATSAPP").IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ATIVO").IsRequired();
            builder.Property(x => x.DataCadastro).HasColumnName("DATA_CADASTRO").IsRequired();
            builder.Property(x => x.DataDesativacao).HasColumnName("DATA_DESATIVACAO").IsRequired(false);

            builder.HasMany(x => x.Cidades).WithMany(x => x.Cuidadores).UsingEntity<CuidadorCidadeDomain>(
                x =>
                x.HasOne(y => y.Cidade).WithMany(y => y.CuidadoresCidade).HasForeignKey(y => y.IdCidade),
                x =>
                x.HasOne(y => y.Cuidador).WithMany(y => y.CuidadoresCidade).HasForeignKey(y => y.IdCuidador),
                x =>
                {
                    x.ToTable("CUIDADOR_CIDADE");

                    x.Property(y => y.IdCuidador).HasColumnName("ID_CUIDADOR");
                    x.Property(y => y.IdCidade).HasColumnName("ID_CIDADE");
                });
        }
    }
}
