using BookingApp.Models;
using Microsoft.EntityFrameworkCore;
namespace BookingApp.Data
{
    internal class Context : DbContext
    {
            public DbSet<Booking> Bookings { get; set; }
            public DbSet<Service> Services { get; set; }
            public DbSet<Customer> Customers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=BookingApp; Trusted_Connection=True;");
        }
    }
}
