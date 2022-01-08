using Microsoft.EntityFrameworkCore;
using Search4Support.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.Data
{
    public class ServiceDbContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ServiceCategory> Categories { get; set; }
        public DbSet<ProviderService> ProviderServices { get; set; }
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProviderService>()
                .HasKey(p => new { p.ProviderId, p.ServiceId });
        }
    }
}
