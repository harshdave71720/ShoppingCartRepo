﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ShoppingCartLibrary;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ShoppingCartEFDataLayer.DbContexts
{
    public class ShoppingDbContext : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<onetoone>();

            base.OnModelCreating(modelBuilder);
        }
        public ShoppingDbContext()
        {
            Database.SetInitializer<ShoppingDbContext>(new ShoppingDbInitializer());
        }

        public ShoppingDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<ShoppingDbContext>(new ShoppingDbInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
