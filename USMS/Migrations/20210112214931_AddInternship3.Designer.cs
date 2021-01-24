﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using USMS.Data;

namespace USMS.Migrations
{
    [DbContext(typeof(USMSContext))]
    [Migration("20210112214931_AddInternship3")]
    partial class AddInternship3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("USMS.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("USMS.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("LessonID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int?>("final")
                        .HasColumnType("int");

                    b.Property<string>("grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("midterm")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("LessonID");

                    b.HasIndex("StudentID");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("USMS.Models.Instructor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("USMS.Models.Internship", b =>
                {
                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<string>("PL")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("subject")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StudentID");

                    b.ToTable("Internship");
                });

            modelBuilder.Entity("USMS.Models.Lesson", b =>
                {
                    b.Property<int>("LessonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Credit")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LessonID");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("USMS.Models.LessonAssigment", b =>
                {
                    b.Property<int>("LessonID")
                        .HasColumnType("int");

                    b.Property<int>("InstructorID")
                        .HasColumnType("int");

                    b.HasKey("LessonID", "InstructorID");

                    b.HasIndex("InstructorID");

                    b.ToTable("LessonAssigment");
                });

            modelBuilder.Entity("USMS.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("USMS.Models.Enrollment", b =>
                {
                    b.HasOne("USMS.Models.Lesson", "Lesson")
                        .WithMany("Enrollments")
                        .HasForeignKey("LessonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("USMS.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("USMS.Models.Instructor", b =>
                {
                    b.HasOne("USMS.Models.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("USMS.Models.Internship", b =>
                {
                    b.HasOne("USMS.Models.Student", "Student")
                        .WithOne("Internship")
                        .HasForeignKey("USMS.Models.Internship", "StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("USMS.Models.LessonAssigment", b =>
                {
                    b.HasOne("USMS.Models.Instructor", "Instructor")
                        .WithMany("LessonAssigments")
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("USMS.Models.Lesson", "Lesson")
                        .WithMany("LessonAssigments")
                        .HasForeignKey("LessonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("USMS.Models.Department", b =>
                {
                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("USMS.Models.Instructor", b =>
                {
                    b.Navigation("LessonAssigments");
                });

            modelBuilder.Entity("USMS.Models.Lesson", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("LessonAssigments");
                });

            modelBuilder.Entity("USMS.Models.Student", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("Internship");
                });
#pragma warning restore 612, 618
        }
    }
}
