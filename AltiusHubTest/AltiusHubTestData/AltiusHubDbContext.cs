using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AltiusHubTestData;

public partial class AltiusHubDbContext : DbContext
{
    public AltiusHubDbContext()
    {
    }

    public AltiusHubDbContext(DbContextOptions<AltiusHubDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InvoiceBillsSundry> InvoiceBillsSundries { get; set; }

    public virtual DbSet<InvoiceHeader> InvoiceHeaders { get; set; }

    public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AltiusHubDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InvoiceBillsSundry>(entity =>
        {
            entity.ToTable("InvoiceBillsSundry");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.InvoiceHeader).WithMany(p => p.InvoiceBillsSundries)
                .HasForeignKey(d => d.InvoiceHeaderId)
                .HasConstraintName("FK_InvoiceBillsSundry_InvoiceHeader");
        });

        modelBuilder.Entity<InvoiceHeader>(entity =>
        {
            entity.ToTable("InvoiceHeader");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BillingAddress).HasMaxLength(500);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Gstin)
                .HasMaxLength(500)
                .HasColumnName("GSTIN");
            entity.Property(e => e.ShippingAddress).HasMaxLength(500);
        });

        modelBuilder.Entity<InvoiceItem>(entity =>
        {
            entity.HasIndex(e => e.InvoiceHeaderId, "IX_InvoiceItems");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ItemName)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.InvoiceHeader).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.InvoiceHeaderId)
                .HasConstraintName("FK_InvoiceItems_InvoiceHeader");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
