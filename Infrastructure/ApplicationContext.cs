﻿using Domain.Customers;
using Domain.Drivers;
using Domain.LocationHistorys;
using Domain.Orders;
using Domain.Vehicles;
using Microsoft.EntityFrameworkCore;

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
                .HasKey(n => new { n.OrderId, n.Ubication, n.CreatedDate });

        }

        public DbSet<Customer> Customers { get; set;}
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Order> Orders { get; set;}
        public DbSet<UbicationHistory> UbicationHistories { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

    }
}