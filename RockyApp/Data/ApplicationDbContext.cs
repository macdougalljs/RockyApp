﻿using Microsoft.EntityFrameworkCore;
using RockyApp.Models;

namespace RockyApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Category
        {
            get; set;
        }

        public DbSet<ApplicationType> ApplicationType
        {
            get; set;
        }
    }
}
