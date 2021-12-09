﻿using Microsoft.EntityFrameworkCore;
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
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        {
        }
    }
}
