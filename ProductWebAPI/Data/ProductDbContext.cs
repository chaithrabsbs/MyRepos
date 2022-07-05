using System;
using Microsoft.EntityFrameworkCore;
using ProductWebAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProductWebAPI.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Products> products { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>()
                .ToTable("Product");
        }
    }
}
