using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using USMS.Models;

namespace USMS.Data
{
    public class USMSContext : DbContext
    {
        public USMSContext(DbContextOptions<USMSContext> options)
            : base(options)
        {
        }

        public DbSet<USMS.Models.Student> Student { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<LessonAssigment> LessonAssigments { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Internship> Internships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<Lesson>().ToTable("Lesson");
            modelBuilder.Entity<LessonAssigment>().ToTable("LessonAssigment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Internship>().ToTable("Internship");

            modelBuilder.Entity<LessonAssigment>()
                .HasKey(l => new { l.LessonID, l.InstructorID });

        }
    }
}
