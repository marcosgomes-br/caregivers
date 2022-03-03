using MeuVelho.Domains;
using MeuVelho.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MeuVelho.Infra.Data.Contexts
{
    public class MeuVelhoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConexao = @"Host=localhost;Username=postgres;Pooling=true;Password=meu@Velho22;Database=meu_velho";

            optionsBuilder
                .UseNpgsql(strConexao)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CuidadorMap());
            modelBuilder.ApplyConfiguration(new PaisMap());
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new CidadeMap());
            modelBuilder.ApplyConfiguration(new ContatoMap());
        }

        public DbSet<PaisDomain> Paises { get; set; }
        public DbSet<EstadoDomain> Estados { get; set; }
        public DbSet<CidadeDomain> Cidades { get; set; }
        public DbSet<CuidadorDomain> Cuidadores { get; set; }
        public DbSet<ContatoDomain> Contatos { get; set; }
    }
}
