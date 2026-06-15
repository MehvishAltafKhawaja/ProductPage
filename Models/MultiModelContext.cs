using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public partial class MultiModelContext : DbContext
{
    public MultiModelContext()
    {
    }

    public MultiModelContext(DbContextOptions<MultiModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("pk_courseId");

            entity.ToTable("course");

            entity.Property(e => e.CourseId).HasColumnName("Course_id");
            entity.Property(e => e.CourseDuration)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Coursefee).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudId).HasName("pk_stud_id");

            entity.ToTable("Student");

            entity.Property(e => e.CourseId).HasColumnName("Course_Id");
            entity.Property(e => e.StudGen)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StudName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StudPhon)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Students)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("fk_courseid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
