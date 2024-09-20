using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class Actividad1dbContext : DbContext
{
    public Actividad1dbContext()
    {
    }

    public Actividad1dbContext(DbContextOptions<Actividad1dbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductComment> ProductComments { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<StoreComment> StoreComments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CUSTOMER__3214EC27C86AE2F1");

            entity.ToTable("CUSTOMER");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Lastname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PHONE");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCT__3214EC27E4ED2BAB");

            entity.ToTable("PRODUCT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.IdStore).HasColumnName("ID_STORE");
            entity.Property(e => e.Images)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("IMAGES");
            entity.Property(e => e.IsPromotional).HasColumnName("IS_PROMOTIONAL");
            entity.Property(e => e.Likes).HasColumnName("LIKES");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("PRICE");
            entity.Property(e => e.Score)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("SCORE");

            entity.HasOne(d => d.IdStoreNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdStore)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRODUCT__ID_STOR__398D8EEE");
        });

        modelBuilder.Entity<ProductComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCT___3214EC277005BADF");

            entity.ToTable("PRODUCT_COMMENT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Comment)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("COMMENT");
            entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");
            entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");
            entity.Property(e => e.Score)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("SCORE");

            entity.HasOne(d => d.Customer).WithMany(p => p.ProductComments)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRODUCT_C__CUSTO__44FF419A");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductComments)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRODUCT_C__PRODU__45F365D3");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__STORE__3214EC279784DE98");

            entity.ToTable("STORE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Category).HasColumnName("CATEGORY");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Image)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("IMAGE");
            entity.Property(e => e.Likes).HasColumnName("LIKES");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PHONE");
            entity.Property(e => e.Score)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("SCORE");
        });

        modelBuilder.Entity<StoreComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__STORE_CO__3214EC277D4048EE");

            entity.ToTable("STORE_COMMENT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Comment)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("COMMENT");
            entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");
            entity.Property(e => e.Score)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("SCORE");
            entity.Property(e => e.StoreId).HasColumnName("STORE_ID");

            entity.HasOne(d => d.Customer).WithMany(p => p.StoreComments)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__STORE_COM__CUSTO__412EB0B6");

            entity.HasOne(d => d.Store).WithMany(p => p.StoreComments)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__STORE_COM__STORE__4222D4EF");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USER__3214EC27938994B6");

            entity.ToTable("USER");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.IdStore).HasColumnName("ID_STORE");
            entity.Property(e => e.Lastname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PHONE");

            entity.HasOne(d => d.IdStoreNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdStore)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USER__ID_STORE__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
