using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SE4_group_A_backend.Entities;

public partial class StudentManagementSystemContext : DbContext
{
    public StudentManagementSystemContext()
    {
    }

    public StudentManagementSystemContext(DbContextOptions<StudentManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.AchievementId).HasName("PRIMARY");

            entity.ToTable("achievements");

            entity.HasIndex(e => e.StudentId, "FK_Student");

            entity.Property(e => e.AchievementId)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("achievement_id");
            entity.Property(e => e.AchievementDate)
                .HasColumnType("date")
                .HasColumnName("achievement_date");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.StudentId)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("student_id");

            entity.HasOne(d => d.Student).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Student");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PRIMARY");

            entity.ToTable("students");

            entity.Property(e => e.StudentId)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("student_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.AdmissionDate)
                .HasColumnType("date")
                .HasColumnName("admission_date");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("contact_number");
            entity.Property(e => e.CurrentGrade)
                .HasMaxLength(10)
                .HasColumnName("current_grade");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("dob");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.GraduationDate)
                .HasColumnType("date")
                .HasColumnName("graduation_date");
            entity.Property(e => e.GuardianContact)
                .HasMaxLength(255)
                .HasColumnName("guardian_contact");
            entity.Property(e => e.GuardianName)
                .HasMaxLength(255)
                .HasColumnName("guardian_name");
            entity.Property(e => e.StudentName)
                .HasMaxLength(255)
                .HasColumnName("student_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Username).HasColumnName("username");
            entity.Property(e => e.LastLoggedIn)
                .HasColumnType("datetime")
                .HasColumnName("lastLoggedIn");
            entity.Property(e => e.Pasword)
                .HasMaxLength(255)
                .HasColumnName("pasword");
            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .HasColumnName("token");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
