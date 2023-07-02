using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodSaleApiService.Entities;
using Microsoft.EntityFrameworkCore;
using FoodSaleApiService.Repositories;
using FoodSaleApiService.Repositories.Interfaces;

namespace FoodSaleApiService.Repositories
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<FoodSale> FoodSale { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // customer address must initialize before customer to make include works
            modelBuilder.Entity<FoodSale>()
                .ToTable("FoodSale")
                .HasKey(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
