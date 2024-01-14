﻿// <auto-generated />
using System;
using DealerShip.Presistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DealerShip.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240114093307_updateRent")]
    partial class updateRent
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DealerShip.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenseID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DealerShip.Models.Make", b =>
                {
                    b.Property<int>("MakeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MakeID"));

                    b.Property<string>("MakeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MakeID");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("DealerShip.Models.Model", b =>
                {
                    b.Property<int>("ModelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModelID"));

                    b.Property<int>("MakeID")
                        .HasColumnType("int");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModelID");

                    b.HasIndex("MakeID");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("DealerShip.Models.SalesPerson", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LicenseID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("SalesPersons");
                });

            modelBuilder.Entity("DealerShip.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("ModelID")
                        .HasColumnType("int");

                    b.Property<int>("SalesPersonID")
                        .HasColumnType("int");

                    b.Property<decimal>("TransactionAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleID")
                        .HasColumnType("int");

                    b.HasKey("TransactionID");

                    b.ToTable("Transaction");

                    b.HasDiscriminator<string>("TransactionType").HasValue("Transaction");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DealerShip.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleID"));

                    b.Property<int>("VehicleMakeID")
                        .HasColumnType("int");

                    b.Property<decimal>("VehicleMileage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VehicleModelID")
                        .HasColumnType("int");

                    b.Property<DateTime>("VehicleProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("VehicleRentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VehicleSalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VehicleStatusID")
                        .HasColumnType("int");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleID");

                    b.HasIndex("VehicleMakeID");

                    b.HasIndex("VehicleModelID");

                    b.HasIndex("VehicleStatusID");

                    b.ToTable("Vehicles", (string)null);
                });

            modelBuilder.Entity("DealerShip.Models.VehicleImage", b =>
                {
                    b.Property<int>("ImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageID"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleID")
                        .HasColumnType("int");

                    b.HasKey("ImageID");

                    b.HasIndex("VehicleID");

                    b.ToTable("VehicleImages");
                });

            modelBuilder.Entity("DealerShip.Models.VehicleStatus", b =>
                {
                    b.Property<int>("VehicleStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleStatusID"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("VehicleStatusID");

                    b.ToTable("VehicleStatuses", (string)null);
                });

            modelBuilder.Entity("DealerShip.Models.Rent", b =>
                {
                    b.HasBaseType("DealerShip.Models.Transaction");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InsuranceAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ModelID");

                    b.HasIndex("SalesPersonID");

                    b.HasIndex("VehicleID");

                    b.HasDiscriminator().HasValue("Rent");
                });

            modelBuilder.Entity("DealerShip.Models.Sale", b =>
                {
                    b.HasBaseType("DealerShip.Models.Transaction");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ModelID");

                    b.HasIndex("SalesPersonID");

                    b.HasIndex("VehicleID");

                    b.HasDiscriminator().HasValue("Sale");
                });

            modelBuilder.Entity("DealerShip.Models.Model", b =>
                {
                    b.HasOne("DealerShip.Models.Make", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Make");
                });

            modelBuilder.Entity("DealerShip.Models.Vehicle", b =>
                {
                    b.HasOne("DealerShip.Models.Make", "VehicleMake")
                        .WithMany()
                        .HasForeignKey("VehicleMakeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DealerShip.Models.Model", "VehicleModel")
                        .WithMany()
                        .HasForeignKey("VehicleModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DealerShip.Models.VehicleStatus", "VehicleStatus")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleMake");

                    b.Navigation("VehicleModel");

                    b.Navigation("VehicleStatus");
                });

            modelBuilder.Entity("DealerShip.Models.VehicleImage", b =>
                {
                    b.HasOne("DealerShip.Models.Vehicle", "Vehicle")
                        .WithMany("VehicleImages")
                        .HasForeignKey("VehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("DealerShip.Models.Rent", b =>
                {
                    b.HasOne("DealerShip.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DealerShip.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DealerShip.Models.SalesPerson", "SalesPerson")
                        .WithMany()
                        .HasForeignKey("SalesPersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DealerShip.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Model");

                    b.Navigation("SalesPerson");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("DealerShip.Models.Sale", b =>
                {
                    b.HasOne("DealerShip.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DealerShip.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DealerShip.Models.SalesPerson", "SalesPerson")
                        .WithMany()
                        .HasForeignKey("SalesPersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DealerShip.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Model");

                    b.Navigation("SalesPerson");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("DealerShip.Models.Make", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("DealerShip.Models.Vehicle", b =>
                {
                    b.Navigation("VehicleImages");
                });

            modelBuilder.Entity("DealerShip.Models.VehicleStatus", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
