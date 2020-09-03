using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWatch.Data.Entities
{
    public class BookWatchContext : DbContext
    {
        public BookWatchContext(DbContextOptions<BookWatchContext> options):base(options)
        {
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }

        //Seeding Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
                .HasData(new Order() 
                {
                Id =1,
                OrderDate = DateTime.UtcNow,
                OrderNumber = "12345"
                });
        }
    }
}
