using CarDealership.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Data
{
    public class CarDealershipContext : DbContext
    {
        public CarDealershipContext()
        {

        }

        public CarDealershipContext(DbContextOptions options)
        : base(options)
        {

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<SalesMan> SalesMen { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Rentor> Rentors { get; set; }
        public DbSet<VehicleMechanic> VehiclesMechanics { get; set; }
        public DbSet<SalesMenVehicles> SalesMenVehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMechanic>()
                .HasKey(e => 
                new { e.VehicleId, e.MechanicId });

            modelBuilder.Entity<SalesMenVehicles>()
                .HasKey(e =>
                new { e.VehicleId, e.SalesManId });
        }

    }
}
