using MeuVelho.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuVelho.Infra.Data.Mappings
{
    public class CaregiverMap : IEntityTypeConfiguration<CaregiverDomain>
    {
        public void Configure(EntityTypeBuilder<CaregiverDomain> builder)
        {
            builder.ToTable("CUIDADOR");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.FullName).HasMaxLength(150).HasColumnName("NOME").IsRequired();
            builder.Property(x => x.Gender).HasColumnName("SEXO").IsRequired();
            builder.Property(x => x.Photo).HasMaxLength(250).HasColumnName("FOTO").IsRequired();
            builder.Property(x => x.Biography).HasMaxLength(1000).HasColumnName("BIOGRAFIA").IsRequired();
            builder.Property(x => x.Whatsapp).HasMaxLength(30).HasColumnName("WHATSAPP").IsRequired();
            builder.Property(x => x.Active).HasColumnName("ATIVO").IsRequired();
            builder.Property(x => x.RegisterIn).HasColumnName("DATA_CADASTRO").IsRequired();
            builder.Property(x => x.DisabledIn).HasColumnName("DATA_DESATIVACAO").IsRequired(false);

            builder.HasMany(x => x.Cities).WithMany(x => x.Caregivers).UsingEntity<CaregiverCityDomain>(
                x =>
                x.HasOne(y => y.City).WithMany(y => y.CaregiversCities).HasForeignKey(y => y.IdCity),
                x =>
                x.HasOne(y => y.Caregiver).WithMany(y => y.CaregiversCities).HasForeignKey(y => y.IdCaregiver),
                x =>
                {
                    x.ToTable("CUIDADOR_CIDADE");

                    x.Property(y => y.IdCaregiver).HasColumnName("ID_CUIDADOR");
                    x.Property(y => y.IdCity).HasColumnName("ID_CIDADE");
                });
        }
    }
}
