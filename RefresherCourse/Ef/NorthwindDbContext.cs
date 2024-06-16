using Microsoft.EntityFrameworkCore;
using RefresherCourse.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefresherCourse.EF
{
    internal class NorthwindDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public NorthwindDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(local)\MSSQLSERVER123;database=northwind;integrated security=sspi;trustservercertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()  //The Category Entity 
                .HasMany(c => c.Products) //Has Many relationship with Products 
                .WithOne(c => c.Category) //with one 
                .HasForeignKey(c => c.CategoryId)
                .IsRequired();
        }
    }
}