using System;
using MeuVelho.Domains;
using MeuVelho.Infra.Data.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
// ReSharper disable UnusedAutoPropertyAccessor.Global
#pragma warning disable CS8618

namespace MeuVelho.Infra.Data.Contexts
{
    public class MeuVelhoContext : IdentityDbContext<UserDomain, RoleDomain, Guid, 
                                                     UserClaimDomain, UserRoleDomain, 
                                                     LoginDomain, RoleClaimDomain, 
                                                     UserTokenDomain>
    {
        public MeuVelhoContext(DbContextOptions<MeuVelhoContext> options) : base(options)
        {
        }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConnection = @"Host=localhost;Username=postgres;Pooling=true;Password=meu@Velho22;Database=meu_velho";

            optionsBuilder
                .UseNpgsql(strConnection)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CaregiverMap());
            modelBuilder.ApplyConfiguration(new CountryMap());
            modelBuilder.ApplyConfiguration(new StateMap());
            modelBuilder.ApplyConfiguration(new CityMap());
            modelBuilder.ApplyConfiguration(new ConnectionMap());
            
            //Identity
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleClaimMap());
            modelBuilder.ApplyConfiguration(new LoginMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserClaimMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
            modelBuilder.ApplyConfiguration(new UserTokenMap());
        }
        
        public DbSet<CityDomain> Cities { get; set; }
        public DbSet<CaregiverDomain> Caregivers { get; set; }
        public DbSet<ConnectionDomain> Connections { get; set; }
    }
}
