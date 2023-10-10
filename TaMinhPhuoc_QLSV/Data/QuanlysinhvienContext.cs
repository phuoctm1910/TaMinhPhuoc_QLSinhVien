using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaMinhPhuoc_QLSV.Data;

public partial class QuanlysinhvienContext : DbContext
{
    public QuanlysinhvienContext()
    {
    }

    public QuanlysinhvienContext(DbContextOptions<QuanlysinhvienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3307;user=root;password=phuoctm1910.;database=quanlysinhvien", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("grade");

            entity.HasIndex(e => e.Masv, "FK_STD_GRADE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Gdtc).HasColumnName("GDTC");
            entity.Property(e => e.Masv)
                .HasMaxLength(50)
                .HasColumnName("MASV");

            entity.HasOne(d => d.MasvNavigation).WithMany(p => p.Grades)
                .HasForeignKey(d => d.Masv)
                .HasConstraintName("FK_STD_GRADE");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Masv).HasName("PRIMARY");

            entity.ToTable("students");

            entity.Property(e => e.Masv)
                .HasMaxLength(50)
                .HasColumnName("MASV");
            entity.Property(e => e.Diachi).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Gioitinh).HasMaxLength(10);
            entity.Property(e => e.Hinh).HasMaxLength(50);
            entity.Property(e => e.Hoten).HasMaxLength(50);
            entity.Property(e => e.SoDt)
                .HasMaxLength(50)
                .HasColumnName("SoDT");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
