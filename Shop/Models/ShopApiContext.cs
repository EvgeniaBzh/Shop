using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Shop.Models;

public partial class ShopApiContext : DbContext
{
    public ShopApiContext()
    {
    }

    public ShopApiContext(DbContextOptions<ShopApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Courier> Couriers { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationType> NotificationTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Representative> Representatives { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-DHK8L7H\\SQLEXPRESS;Database=ShopAPI;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.Property(e => e.ApartmentNumber).HasMaxLength(10);
            entity.Property(e => e.HouseNumber).HasMaxLength(10);
            entity.Property(e => e.Settlement).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.StoreId).HasColumnName("StoreID");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admins_Couriers");

            entity.HasOne(d => d.Id1).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admins_Stores");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Courier>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.Password).HasMaxLength(50);

            entity.HasOne(d => d.Notification).WithMany(p => p.Customers)
                .HasForeignKey(d => d.NotificationId)
                .HasConstraintName("FK_Customers_Notifications");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.Property(e => e.DiscountCode).HasMaxLength(50);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Feedback)
                .HasForeignKey<Feedback>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedbacks_Customers");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Notification)
                .HasForeignKey<Notification>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notifications_NotificationTypes");
        });

        modelBuilder.Entity<NotificationType>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_Orders_CustomerId");

            entity.HasIndex(e => e.ShippingAddressId, "IX_Orders_ShippingAddressId");

            entity.Property(e => e.LastEditted).HasColumnType("datetime");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ShippingDate).HasColumnType("datetime");

            entity.HasOne(d => d.Courier).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CourierId)
                .HasConstraintName("FK_Orders_Couriers");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.Discount).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DiscountId)
                .HasConstraintName("FK_Orders_Discounts");

            entity.HasOne(d => d.Payment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK_Orders_Payments");

            entity.HasOne(d => d.ShippingAddress).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShippingAddressId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId });

            entity.HasIndex(e => e.ProductId, "IX_OrderProducts_ProductId");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderProducts).HasForeignKey(d => d.OrderId);

            entity.HasOne(d => d.Product).WithMany(p => p.OrderProducts).HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.BrandId, "IX_Products_BrandId");

            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.LastEditted).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK_Products_Brands");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.Feedback).WithMany(p => p.Products)
                .HasForeignKey(d => d.FeedbackId)
                .HasConstraintName("FK_Products_Feedbacks");

            entity.HasOne(d => d.Representative).WithMany(p => p.Products)
                .HasForeignKey(d => d.RepresentativeId)
                .HasConstraintName("FK_Products_Representatives");
        });

        modelBuilder.Entity<Representative>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Representative).WithMany(p => p.Stores)
                .HasForeignKey(d => d.RepresentativeId)
                .HasConstraintName("FK_Stores_Representatives");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
