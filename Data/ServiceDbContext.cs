using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Search4Support.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.Data
{
    public class ServiceDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Service> Services { get; set; }
/*        public DbSet<Provider> Providers { get; set; }*/
/*        public DbSet<Category> Categories { get; set; }*/
        public DbSet<ServiceCategory> Categories { get; set; }
/*        public DbSet<Location> Locations { get; set; }
        public DbSet<Tag> Tags { get; set; }*/
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<EventTag>().HasKey(et => new { et.EventId, et.TagId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
