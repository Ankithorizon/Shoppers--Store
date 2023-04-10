using EF.Core.ShoppersStore.ShoppersStoreDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace EF.Core.ShoppersStore.ShoppersStoreDB
{
    public class ShoppersStoreContext : DbContext
    {
        public ShoppersStoreContext(DbContextOptions<ShoppersStoreContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(a => a.ProductFile)
                .WithOne(b => b.Product)
                .HasForeignKey<ProductFile>(b => b.ProductId);

            modelBuilder.Entity<Product>()
                  .HasMany(c => c.DiscountHistories)
                  .WithOne(e => e.Product);

            modelBuilder.Entity<Product>()
                .HasMany(c => c.ProductSells)
                .WithOne(e => e.Product);

            modelBuilder.Entity<Payment>()
               .HasMany(c => c.ProductSells)
               .WithOne(e => e.Payment);

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFile> ProductFiles { get; set; }
        public DbSet<ProductSell> ProductSells { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<DiscountHistory> DiscountHistories { get; set; }
    }
}
