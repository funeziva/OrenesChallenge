using Domain.Customers;
using Domain.Drivers;
using Domain.Orders;
using Domain.UbicationHistories;
using Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasIndex(n => n.Name).IsUnique();
            modelBuilder.Entity<Customer>()
                .HasIndex(n => n.TelephoneNumber).IsUnique();

            modelBuilder.Entity<Driver>()
                .HasIndex(n => n.Name).IsUnique();
            modelBuilder.Entity<Driver>()
                .HasIndex(n => n.TelephoneNumber).IsUnique();

            modelBuilder.Entity<UbicationHistory>()
                .HasKey(n => new { n.VehicleId, n.Ubication, n.CreatedDate });

            modelBuilder.Entity<Order>()
                .Property(n => n.Status)
                .HasConversion(new EnumToStringConverter<OrderStatus>());

        }

        public DbSet<Customer> Customers { get; set;}
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Order> Orders { get; set;}
        public DbSet<UbicationHistory> UbicationHistories { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

    }
}
