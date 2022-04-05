using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWatcher
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<OrderFromDB> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderFromDB>().HasData(
                new OrderFromDB
                {
                    Id = 1,
                    Fees = 120,
                    OrderStatus = "Submitted"
                },
                new OrderFromDB
                {
                    Id = 2,
                    Fees = 100,
                    OrderStatus = "Pending Provision"
                },
                new OrderFromDB
                {
                    Id = 3,
                    Fees = 80,
                    OrderStatus = "Provision in progress"
                },
                new OrderFromDB
                {
                    Id = 4,
                    Fees = 120,
                    OrderStatus = "Submitted"
                },
                new OrderFromDB
                {
                    Id = 5,
                    CustomerName = "Greg",
                    Fees = 140,
                    OrderStatus = "Completed"
                }
                );
        }
    }
}
