using Crud_Core.dbEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Core.dbModels
{
    public class EFContext : DbContext
    {
        //public EFContext()
        //{

        //}
        public EFContext(DbContextOptions<EFContext> options): base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //new ProductMap(modelBuilder.Entity<Product>());
            modelBuilder.Entity<Product>().ToTable("Product");

            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(p => p.Description).HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(p => p.SKU).HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();
        }
        public DbSet<Product> Products { get; set; }
    }
}
