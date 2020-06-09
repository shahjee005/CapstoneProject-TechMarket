using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechMarket.Model;
using Microsoft.EntityFrameworkCore;

namespace TechMarket.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        
        }
        public DbSet<Customer> Customer { get; set; }       
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Cart> Cart { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedCustomers();        
            modelBuilder.SeedProducts();
            modelBuilder.SeedProductDetails();
        }
    }
}
