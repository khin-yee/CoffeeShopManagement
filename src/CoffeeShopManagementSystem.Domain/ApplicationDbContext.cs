﻿using CoffeeShopManagementSystem.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopManagementSystem.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // PostgreSQL specific setting
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Order>Order { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
    }
}
