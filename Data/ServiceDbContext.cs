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
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }

/*        public DbSet<Location> Locations { get; set; }*/
        public DbSet<ServiceTag> ServiceTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        {
        }
        //called on initial app startup and customize model config using modelbuilder instance
        //specifies that ServiceTag entity should have a compound key of the pair ServiceId and TagId
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceTag>().HasKey(st => new { st.ServiceId, st.TagId });

            base.OnModelCreating(modelBuilder);
        }


    }
}
