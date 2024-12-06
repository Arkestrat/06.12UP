using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClassLibraryKhasanovUP;

public partial class UpkhasanovContext : DbContext
{
    public UpkhasanovContext()
    {
    }

    public UpkhasanovContext(DbContextOptions<UpkhasanovContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Add> Adds { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=44-3\\MSSQLSERVER01;Database=UPKhasanov;TrustServerCertificate=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Add>(entity =>
        {
            entity.Property(e => e.AddId).HasColumnName("AddID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Category).WithMany(p => p.Adds)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Adds_Categories1");

            entity.HasOne(d => d.User).WithMany(p => p.Adds)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Adds_Users");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsFixedLength();
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.AddId).HasColumnName("AddID");
            entity.Property(e => e.CommentText)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Add).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AddId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Adds");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Users1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.AddId).HasColumnName("AddID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.Add).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AddId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Adds");

            entity.HasOne(d => d.BuyerNavigation).WithMany(p => p.OrderBuyerNavigations)
                .HasForeignKey(d => d.Buyer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Users");

            entity.HasOne(d => d.SallerNavigation).WithMany(p => p.OrderSallerNavigations)
                .HasForeignKey(d => d.Saller)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Users1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
