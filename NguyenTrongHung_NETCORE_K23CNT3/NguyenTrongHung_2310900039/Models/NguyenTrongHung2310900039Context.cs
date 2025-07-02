using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NguyenTrongHung_2310900039.Models;

public partial class NguyenTrongHung2310900039Context : DbContext
{
    public NguyenTrongHung2310900039Context()
    {
    }

    public NguyenTrongHung2310900039Context(DbContextOptions<NguyenTrongHung2310900039Context> options)
        : base(options)
    {
    }

    public virtual DbSet<NthEmployee> NthEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TRONGNHAT\\HUNG;Database=NguyenTrongHung_2310900039;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NthEmployee>(entity =>
        {
            entity.HasKey(e => e.NthEmpId).HasName("PK__NthEmplo__A5E453C6F8ED62CD");

            entity.ToTable("NthEmployee");

            entity.Property(e => e.NthEmpId).HasColumnName("nthEmpId");
            entity.Property(e => e.NthEmpLevel)
                .HasMaxLength(50)
                .HasColumnName("nthEmpLevel");
            entity.Property(e => e.NthEmpName)
                .HasMaxLength(100)
                .HasColumnName("nthEmpName");
            entity.Property(e => e.NthEmpStartDate).HasColumnName("nthEmpStartDate");
            entity.Property(e => e.NthEmpStatus).HasColumnName("nthEmpStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
