using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Plugins.DataStore.Sql
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
            //modelBuilder.Entity<Category>().HasData(
            //     new List<Category>
            //{
            //    new Category
            //    {
            //        CategoryID=1,
            //        Name   = "面包",
            //        Description="面包的大类别"
            //    },
            //new Category
            //{
            //    CategoryID = 2,
            //    Name = "蛋糕",
            //    Description = "蛋糕的大类别"
            //},
            //new Category
            //{
            //    CategoryID = 3,
            //    Name = "肉类",
            //    Description = "肉肉的大类别"
            //}
            //}
            //    );
            //modelBuilder.Entity<Product>().HasData(
            //    new List<Product>
            //{
            //    new Product{ProductId=1,CategoryId=1,Name="鸡肉",Quantity=100,Price=1.99},
            //    new Product{ProductId=2,CategoryId=1,Name="牛肉",Quantity=150,Price=3.99},
            //    new Product{ProductId=3,CategoryId=2,Name="土豆",Quantity=200,Price=4.5},
            //    new Product{ProductId=4,CategoryId=3,Name="西兰花",Quantity=3000,Price=1.2},
            //});
        }
    }
}
