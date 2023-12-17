using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Labb3Skolan.Models;

public partial class SlotteGymnasietContext : DbContext
{
    public SlotteGymnasietContext()
    {
    }

    public SlotteGymnasietContext(DbContextOptions<SlotteGymnasietContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentCourseGrade> StudentCourseGrades { get; set; }

    public virtual DbSet<TeacherCourse> TeacherCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog=SlotteGymnasiet;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK_Table_1");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CourseName).HasMaxLength(50);
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee", tb => tb.HasTrigger("TR_PersonalNr"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(7);
            entity.Property(e => e.HireDate).HasColumnType("date");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PersonalNr).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Role");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.ToTable("Grade");

            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.GradeName)
                .HasMaxLength(5)
                .HasColumnName("Grade");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student", tb => tb.HasTrigger("TR_StudentPersonalNr"));

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(7);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PersonalNr).HasMaxLength(16);
        });

        modelBuilder.Entity<StudentCourseGrade>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Student_Course_Grade");

            entity.Property(e => e.FkcourseId).HasColumnName("FKCourseID");
            entity.Property(e => e.FkgradeId).HasColumnName("FKGradeID");
            entity.Property(e => e.FkstudentId).HasColumnName("FKStudentID");
            entity.Property(e => e.GradeDate).HasColumnType("date");
            entity.Property(e => e.GradeTeacher).HasMaxLength(50);

            entity.HasOne(d => d.Fkcourse).WithMany()
                .HasForeignKey(d => d.FkcourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Course_Grade_Course");

            entity.HasOne(d => d.Fkgrade).WithMany()
                .HasForeignKey(d => d.FkgradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Course_Grade_Grade");

            entity.HasOne(d => d.Fkstudent).WithMany()
                .HasForeignKey(d => d.FkstudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Course_Grade_Student");
        });

        modelBuilder.Entity<TeacherCourse>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Teacher_Course");

            entity.Property(e => e.FkcourseId).HasColumnName("FKCourseID");
            entity.Property(e => e.FkteacherId).HasColumnName("FKTeacherID");

            entity.HasOne(d => d.Fkcourse).WithMany()
                .HasForeignKey(d => d.FkcourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teacher_Course_Course");

            entity.HasOne(d => d.Fkteacher).WithMany()
                .HasForeignKey(d => d.FkteacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Role_Course_Employee");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
