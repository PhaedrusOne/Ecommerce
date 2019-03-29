﻿using System.Collections.Generic;
using System.Linq;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<ProductMenu> ProductMenus { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public object Product { get; internal set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {      
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductMenu>()
                .HasKey(c => new { c.ProductID, c.MenuID });

            modelBuilder.Entity<ProductOrder>()
               .HasKey(c => new { c.ProductID, c.OrderID });
        }


        private readonly List<Product> products = new List<Product>();

        public List<Product> FindAll()
        {
            return this.products;
        }

        public Product Find(int id)
        {
            return this.products.SingleOrDefault(c => c.ID.Equals(id));
        }
    }
}
