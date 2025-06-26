using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace nthLesson10.Models;

public partial class NthK23cnt3Lesson10dbContext : DbContext
{
    public NthK23cnt3Lesson10dbContext()
    {
    }

    public NthK23cnt3Lesson10dbContext(DbContextOptions<NthK23cnt3Lesson10dbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NthPost> NthPosts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TRONGNHAT\\HUNG;Database=NthK23CNT3_Lesson10db;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NthPost>(entity =>
        {
            entity.HasKey(e => e.NthId);

            entity.ToTable("NthPost");

            entity.Property(e => e.NthId).HasColumnName("nthId");
            entity.Property(e => e.NthContent)
                .HasColumnType("ntext")
                .HasColumnName("nthContent");
            entity.Property(e => e.NthImage)
                .HasMaxLength(250)
                .HasColumnName("nthImage");
            entity.Property(e => e.NthStatus).HasColumnName("nthStatus");
            entity.Property(e => e.NthTitle)
                .HasMaxLength(50)
                .HasColumnName("nthTitle");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
