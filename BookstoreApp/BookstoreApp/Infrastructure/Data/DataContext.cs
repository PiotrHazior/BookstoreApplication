using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBook> OrderBooks { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderBook>()
                .HasKey(ob => new { ob.OrderId, ob.BookId });

            modelBuilder.Entity<OrderBook>()
                .HasOne(ob => ob.Order)
                .WithMany(o => o.OrderBooks)
                .HasForeignKey(ob => ob.OrderId);

            modelBuilder.Entity<OrderBook>()
                .HasOne(ob => ob.Book)
                .WithMany(b => b.OrderBooks)
                .HasForeignKey(ob => ob.BookId);

            modelBuilder.Entity<Book>()
                .Property(b => b.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Customer>().ToTable("Customers");
        }
    }
}
