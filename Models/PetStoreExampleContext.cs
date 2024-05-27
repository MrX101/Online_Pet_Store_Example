using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Online_Pet_Store_Example.Model;

public partial class PetStoreExampleContext : DbContext
{
    public PetStoreExampleContext()
    {
    }

    public PetStoreExampleContext(DbContextOptions<PetStoreExampleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Page> Pages { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PurchaseLog> PurchaseLogs { get; set; }

    public virtual DbSet<RefundLog> RefundLogs { get; set; }

    public virtual DbSet<RefundStatus> RefundStatuses { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=pet_store_example;Username=postgres;Password=pass123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("brand_pk");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customer_pk");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("item_pk");

            entity.HasOne(d => d.Brand).WithMany(p => p.Items)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("item_brands_id_fk");
        });

        modelBuilder.Entity<Page>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pages_pk");

            entity.ToTable("pages", tb => tb.HasComment("reffers to a page of the website, for permission reasons."));
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("permission_pk");
        });

        modelBuilder.Entity<PurchaseLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("purchase_log_pk");

            entity.Property(e => e.Amount).HasDefaultValue(1);

            entity.HasOne(d => d.Customer).WithMany(p => p.PurchaseLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("purchase_log_customer_id_fk");

            entity.HasOne(d => d.Item).WithMany(p => p.PurchaseLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("purchase_log_item_id_fk");
        });

        modelBuilder.Entity<RefundLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("refundlog_pk");

            entity.HasOne(d => d.PurchaseLog).WithMany(p => p.RefundLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("refundlog_purchaselog_id_fk");

            entity.HasOne(d => d.RefundStatus).WithMany(p => p.RefundLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("refundlog_refundstatus_id_fk");
        });

        modelBuilder.Entity<RefundStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("refund_status_pk");

            entity.Property(e => e.Id).HasIdentityOptions(1L, null, -2147483648L, null, null, null);
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.Itemid).HasName("stock_pk");

            entity.Property(e => e.Itemid)
                .ValueGeneratedNever()
                .HasComment("should be same Id as item.");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_account_pk");

            entity.HasOne(d => d.Customer).WithMany(p => p.UserAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_account_customer_id_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
