using MeuVelho.Domains;
using MeuVelho.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MeuVelho.Infra.Data.Contexts
{
    public class MeuVelhoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConnection = @"Host=localhost;Username=postgres;Pooling=true;Password=meu@Velho22;Database=meu_velho";

            optionsBuilder
                .UseNpgsql(strConnection)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CaregiverMap());
            modelBuilder.ApplyConfiguration(new CountryMap());
            modelBuilder.ApplyConfiguration(new StateMap());
            modelBuilder.ApplyConfiguration(new CityMap());
            modelBuilder.ApplyConfiguration(new ConnectionMap());
        }

        public DbSet<CountryDomain> Countries { get; set; }
        public DbSet<StateDomain> States { get; set; }
        public DbSet<CityDomain> Cities { get; set; }
        public DbSet<CaregiverDomain> Caregivers { get; set; }
        public DbSet<ConnectionDomain> Connections { get; set; }
    }
}
