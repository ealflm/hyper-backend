﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TourismSmartTransportation.Data.Models;

#nullable disable

namespace TourismSmartTransportation.Data.Context
{
    public partial class tourismsmarttransportationContext : DbContext
    {
        public tourismsmarttransportationContext()
        {
        }

        public tourismsmarttransportationContext(DbContextOptions<tourismsmarttransportationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BasePriceOfBusService> BasePriceOfBusServices { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerTrip> CustomerTrips { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<FeedbackForDriver> FeedbackForDrivers { get; set; }
        public virtual DbSet<FeedbackForVehicle> FeedbackForVehicles { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetailOfBookingService> OrderDetailOfBookingServices { get; set; }
        public virtual DbSet<OrderDetailOfBusService> OrderDetailOfBusServices { get; set; }
        public virtual DbSet<OrderDetailOfPackage> OrderDetailOfPackages { get; set; }
        public virtual DbSet<OrderDetailOfRentingService> OrderDetailOfRentingServices { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PackageItem> PackageItems { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<PartnerServiceType> PartnerServiceTypes { get; set; }
        public virtual DbSet<PriceOfBookingService> PriceOfBookingServices { get; set; }
        public virtual DbSet<PriceOfBusService> PriceOfBusServices { get; set; }
        public virtual DbSet<PriceOfRentingService> PriceOfRentingServices { get; set; }
        public virtual DbSet<PublishYear> PublishYears { get; set; }
        public virtual DbSet<RentStation> RentStations { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<RoutePriceBusing> RoutePriceBusings { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<StationRoute> StationRoutes { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsFixedLength(true);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoUrl).IsUnicode(false);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsFixedLength(true);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BasePriceOfBusService>(entity =>
            {
                entity.ToTable("BasePriceOfBusService");

                entity.Property(e => e.BasePriceOfBusServiceId).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 7)");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("Card");

                entity.Property(e => e.CardId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Card__CustomerId__1BC821DD");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.Phone, "UC_Phone_Customer")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoUrl).IsUnicode(false);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<CustomerTrip>(entity =>
            {
                entity.ToTable("CustomerTrip");

                entity.Property(e => e.CustomerTripId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Coordinates).HasMaxLength(1);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Distance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RentDeadline).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(case when [RentDeadline]>(getdate() AT TIME ZONE 'SE Asia Standard Time') then '1' else '2' end)", false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerTrips)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerT__Custo__245D67DE");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.CustomerTrips)
                    .HasForeignKey(d => d.RouteId)
                    .HasConstraintName("FK_CustomerTrip_Route");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.CustomerTrips)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK__CustomerT__Vehic__2645B050");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discount");

                entity.Property(e => e.DiscountId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.PhotoUrl).IsUnicode(false);

                entity.Property(e => e.TimeEnd).HasColumnType("datetime");

                entity.Property(e => e.TimeStart).HasColumnType("datetime");

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ServiceType)
                    .WithMany(p => p.Discounts)
                    .HasForeignKey(d => d.ServiceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Discount_ServiceType");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("Driver");

                entity.Property(e => e.DriverId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoUrl).IsUnicode(false);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.Drivers)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK__Driver__PartnerI__2FCF1A8A");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Drivers)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK_Driver_Vehicle");
            });

            modelBuilder.Entity<FeedbackForDriver>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.DriverId });

                entity.ToTable("FeedbackForDriver");

                entity.Property(e => e.Content).IsRequired();

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.FeedbackForDrivers)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FeedbackForDriver_Driver");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.FeedbackForDrivers)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FeedbackForDriver_Order");
            });

            modelBuilder.Entity<FeedbackForVehicle>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.VehicelId });

                entity.ToTable("FeedbackForVehicle");

                entity.Property(e => e.Content).IsRequired();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.FeedbackForVehicles)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FeedbackForVehicle_Order");

                entity.HasOne(d => d.Vehicel)
                    .WithMany(p => p.FeedbackForVehicles)
                    .HasForeignKey(d => d.VehicelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FeedbackForVehicle_Vehicle");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK_Order_Discount");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK_Order_Partner");

                entity.HasOne(d => d.ServiceType)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ServiceTypeId)
                    .HasConstraintName("FK_Order_ServiceType");
            });

            modelBuilder.Entity<OrderDetailOfBookingService>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.PriceOfBookingServiceId });

                entity.ToTable("OrderDetailOfBookingService");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 7)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetailOfBookingServices)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetailOfBookingService_Order");

                entity.HasOne(d => d.PriceOfBookingService)
                    .WithMany(p => p.OrderDetailOfBookingServices)
                    .HasForeignKey(d => d.PriceOfBookingServiceId)
                    .HasConstraintName("FK_OrderDetailOfBookingService_PriceOfBookingService");
            });

            modelBuilder.Entity<OrderDetailOfBusService>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.PriceOfBusServiceId });

                entity.ToTable("OrderDetailOfBusService");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 7)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetailOfBusServices)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetailOfBusService_Order");

                entity.HasOne(d => d.PriceOfBusService)
                    .WithMany(p => p.OrderDetailOfBusServices)
                    .HasForeignKey(d => d.PriceOfBusServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetailOfBusService_PriceOfBusService");
            });

            modelBuilder.Entity<OrderDetailOfPackage>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.PackageId })
                    .HasName("PK_OrderDetailOfTier");

                entity.ToTable("OrderDetailOfPackage");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 7)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetailOfPackages)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetailOfTier_Order");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.OrderDetailOfPackages)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetailOfTier_Tier");
            });

            modelBuilder.Entity<OrderDetailOfRentingService>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.PriceOfRentingService });

                entity.ToTable("OrderDetailOfRentingService");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 7)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetailOfRentingServices)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetailOfRentingService_Order");

                entity.HasOne(d => d.PriceOfRentingServiceNavigation)
                    .WithMany(p => p.OrderDetailOfRentingServices)
                    .HasForeignKey(d => d.PriceOfRentingService)
                    .HasConstraintName("FK_OrderDetailOfRentingService_PriceOfRentingService");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.ToTable("Package");

                entity.Property(e => e.PackageId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PhotoUrl).IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PromotedTitle)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<PackageItem>(entity =>
            {
                entity.HasKey(e => new { e.PackageId, e.ServiceTypeId })
                    .HasName("PK_Package");

                entity.ToTable("PackageItem");

                entity.Property(e => e.Limit).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Value).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PackageItems)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Package__TierId__2CF2ADDF");

                entity.HasOne(d => d.ServiceType)
                    .WithMany(p => p.PackageItems)
                    .HasForeignKey(d => d.ServiceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Package__Service__2DE6D218");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.ToTable("Partner");

                entity.HasIndex(e => e.Username, "UC_Username_Partner")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__Partner__536C85E4C0324D60")
                    .IsUnique();

                entity.Property(e => e.PartnerId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoUrl).IsUnicode(false);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsFixedLength(true);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PartnerServiceType>(entity =>
            {
                entity.HasKey(e => new { e.PartnerId, e.ServiceTypeId });

                entity.ToTable("PartnerServiceType");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.PartnerServiceTypes)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK__PartnerSe__Partn__3F115E1A");

                entity.HasOne(d => d.ServiceType)
                    .WithMany(p => p.PartnerServiceTypes)
                    .HasForeignKey(d => d.ServiceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PartnerSe__Servi__40058253");
            });

            modelBuilder.Entity<PriceOfBookingService>(entity =>
            {
                entity.ToTable("PriceOfBookingService");

                entity.Property(e => e.PriceOfBookingServiceId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FixedDistance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FixedPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PricePerKilometer).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.PriceOfBookingServices)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .HasConstraintName("FK_PriceOfBookingService_VehicleType");
            });

            modelBuilder.Entity<PriceOfBusService>(entity =>
            {
                entity.ToTable("PriceOfBusService");

                entity.Property(e => e.PriceOfBusServiceId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.MaxDistance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MaxStation).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MinDistance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MinStation).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Mode)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.BasePrice)
                    .WithMany(p => p.PriceOfBusServices)
                    .HasForeignKey(d => d.BasePriceId)
                    .HasConstraintName("FK_PriceOfBusService_BasePriceOfBusService");
            });

            modelBuilder.Entity<PriceOfRentingService>(entity =>
            {
                entity.ToTable("PriceOfRentingService");

                entity.Property(e => e.PriceOfRentingServiceId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FixedPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.HolidayPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MaxTime).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MinTime).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PricePerHour).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WeekendPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PriceOfRentingServices)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_PriceOfRentingService_Category");

                entity.HasOne(d => d.PublishYear)
                    .WithMany(p => p.PriceOfRentingServices)
                    .HasForeignKey(d => d.PublishYearId)
                    .HasConstraintName("FK_PriceOfRentingService_PublishYear");
            });

            modelBuilder.Entity<PublishYear>(entity =>
            {
                entity.ToTable("PublishYear");

                entity.Property(e => e.PublishYearId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<RentStation>(entity =>
            {
                entity.ToTable("RentStation");

                entity.Property(e => e.RentStationId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 15)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 14)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.RentStations)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK__RentStati__Partn__40F9A68C");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("Route");

                entity.Property(e => e.RouteId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Distance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK__Route__PartnerId__339FAB6E");
            });

            modelBuilder.Entity<RoutePriceBusing>(entity =>
            {
                entity.HasKey(e => new { e.RouteId, e.PriceBusingId })
                    .HasName("PK_RoutePriceBusing_1");

                entity.ToTable("RoutePriceBusing");

                entity.HasOne(d => d.PriceBusing)
                    .WithMany(p => p.RoutePriceBusings)
                    .HasForeignKey(d => d.PriceBusingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoutePriceBusing_PriceBusing");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.RoutePriceBusings)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoutePriceBusing_Route");
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.ToTable("ServiceType");

                entity.Property(e => e.ServiceTypeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.ToTable("Station");

                entity.Property(e => e.StationId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 15)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 14)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<StationRoute>(entity =>
            {
                entity.HasKey(e => new { e.StationId, e.RouteId });

                entity.ToTable("StationRoute");

                entity.Property(e => e.Distance).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.StationRoutes)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StationRoute_Route");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.StationRoutes)
                    .HasForeignKey(d => d.StationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StationRo__Stati__31B762FC");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.TransactionId).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Uid).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Payment__OrderId__1F98B2C1");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.WalletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Wallet");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("Trip");

                entity.Property(e => e.TripId).ValueGeneratedNever();

                entity.Property(e => e.TimeEnd)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStart)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TripName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trip__DriverId__3493CFA7");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trip_Route");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trip_Vehicle");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.Property(e => e.VehicleId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.IsRunning).HasColumnName("isRunning");

                entity.Property(e => e.LicensePlates)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK__Vehicle__Partner__3B40CD36");

                entity.HasOne(d => d.PriceRenting)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.PriceRentingId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Vehicle_PriceRenting");

                entity.HasOne(d => d.ServiceType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.ServiceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vehicle__Service__3864608B");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .HasConstraintName("FK__Vehicle__Vehicle__395884C4");
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.ToTable("VehicleType");

                entity.Property(e => e.VehicleTypeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Fuel)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.ToTable("Wallet");

                entity.Property(e => e.WalletId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountBalance).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Wallets)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Wallet__Customer__1CBC4616");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
