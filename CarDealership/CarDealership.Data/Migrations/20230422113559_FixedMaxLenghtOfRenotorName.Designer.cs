﻿// <auto-generated />
using System;
using CarDealership.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarDealership.Data.Migrations
{
    [DbContext(typeof(CarDealershipContext))]
    [Migration("20230422113559_FixedMaxLenghtOfRenotorName")]
    partial class FixedMaxLenghtOfRenotorName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarDealership.Data.Models.Mechanic", b =>
                {
                    b.Property<int>("MechanicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MechanicId"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsNewRecruit")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Specialisation")
                        .HasColumnType("int");

                    b.HasKey("MechanicId");

                    b.ToTable("Mechanics");
                });

            modelBuilder.Entity("CarDealership.Data.Models.Rentor", b =>
                {
                    b.Property<int>("RentorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentorId"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DriverLicense")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.HasKey("RentorId");

                    b.ToTable("Rentors");
                });

            modelBuilder.Entity("CarDealership.Data.Models.SalesMan", b =>
                {
                    b.Property<int>("SalesManId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalesManId"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("Ranking")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SalesManId");

                    b.ToTable("SalesMen");
                });

            modelBuilder.Entity("CarDealership.Data.Models.SalesMenVehicles", b =>
                {
                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int>("SalesManId")
                        .HasColumnType("int");

                    b.HasKey("VehicleId", "SalesManId");

                    b.HasIndex("SalesManId");

                    b.ToTable("SalesMenVehicles");
                });

            modelBuilder.Entity("CarDealership.Data.Models.VehicleMechanic", b =>
                {
                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int>("MechanicId")
                        .HasColumnType("int");

                    b.HasKey("VehicleId", "MechanicId");

                    b.HasIndex("MechanicId");

                    b.ToTable("VehiclesMechanics");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"), 1L, 1);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<decimal>("HorsePower")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsRented")
                        .HasColumnType("bit");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Make")
                        .HasColumnType("int");

                    b.Property<decimal>("Mileage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RentedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RentorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("VehicleId");

                    b.HasIndex("RentorId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CarDealership.Data.Models.SalesMenVehicles", b =>
                {
                    b.HasOne("CarDealership.Data.Models.SalesMan", "SalesMan")
                        .WithMany("SalesMenVehicles")
                        .HasForeignKey("SalesManId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vehicle", "Vehicle")
                        .WithMany("SalesMenVehicles")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SalesMan");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("CarDealership.Data.Models.VehicleMechanic", b =>
                {
                    b.HasOne("CarDealership.Data.Models.Mechanic", "Mechanic")
                        .WithMany("VehiclesMechanics")
                        .HasForeignKey("MechanicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vehicle", "Vehicle")
                        .WithMany("VehiclesMechanics")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mechanic");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.HasOne("CarDealership.Data.Models.Rentor", "Rentor")
                        .WithMany("RentedVehicles")
                        .HasForeignKey("RentorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rentor");
                });

            modelBuilder.Entity("CarDealership.Data.Models.Mechanic", b =>
                {
                    b.Navigation("VehiclesMechanics");
                });

            modelBuilder.Entity("CarDealership.Data.Models.Rentor", b =>
                {
                    b.Navigation("RentedVehicles");
                });

            modelBuilder.Entity("CarDealership.Data.Models.SalesMan", b =>
                {
                    b.Navigation("SalesMenVehicles");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.Navigation("SalesMenVehicles");

                    b.Navigation("VehiclesMechanics");
                });
#pragma warning restore 612, 618
        }
    }
}