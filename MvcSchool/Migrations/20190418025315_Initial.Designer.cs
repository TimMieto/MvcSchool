﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcSchool.Models;

namespace MvcSchool.Migrations
{
    [DbContext(typeof(MvcSchoolContext))]
    [Migration("20190418025315_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvcSchool.Models.Course", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<double>("CourseCredit");

                    b.Property<string>("CourseDate");

                    b.Property<string>("CourseLevel");

                    b.Property<string>("CourseName");

                    b.Property<int>("CourseTime");

                    b.HasKey("CourseId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("MvcSchool.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<int?>("Grade");

                    b.Property<int>("StudentId");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("MvcSchool.Models.Major", b =>
                {
                    b.Property<int>("MajorId");

                    b.Property<string>("MajorName");

                    b.HasKey("MajorId");

                    b.ToTable("Major");
                });

            modelBuilder.Entity("MvcSchool.Models.Student", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<int>("StuAge");

                    b.Property<double>("StuCredit");

                    b.Property<string>("StuFamilyName");

                    b.Property<string>("StuGender");

                    b.Property<string>("StuGivenName");

                    b.Property<string>("StuMajor");

                    b.HasKey("StudentId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("MvcSchool.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId");

                    b.Property<int>("TeacherName");

                    b.HasKey("TeacherId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("MvcSchool.Models.Enrollment", b =>
                {
                    b.HasOne("MvcSchool.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MvcSchool.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
