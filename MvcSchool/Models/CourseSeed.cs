using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcSchool.Models
{
    public static class CourseSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcSchoolContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcSchoolContext>>()))
            {
                // Look for any movies.
                if (context.Course.Any())
                {
                    return;   // DB has been seeded
                }

                context.Course.AddRange(
                    new Course { CourseId = 10506, CourseName = "Chemistry", CourseCredit = 3 },
                    new Course { CourseId = 40299, CourseName = "Microeconomics", CourseCredit = 3 },
                    new Course { CourseId = 40491, CourseName = "Macroeconomics", CourseCredit = 3 },
                    new Course { CourseId = 10458, CourseName = "Calculus", CourseCredit = 4 },
                    new Course { CourseId = 31415, CourseName = "Trigonometry", CourseCredit = 4 },
                    new Course { CourseId = 20211, CourseName = "Composition", CourseCredit = 3 },
                    new Course { CourseId = 20462, CourseName = "Literature", CourseCredit = 4 }
                    );

                context.Student.AddRange(
                    new Student { StudentId = 201203055, StuGivenName = "Alexander", StuFamilyName = "Smith", EnrollmentDate = DateTime.Parse("2005-09-01") },
                    new Student { StudentId = 201006074, StuGivenName = "Meredith", StuFamilyName = "Alonso", EnrollmentDate = DateTime.Parse("2002-09-01") },
                    new Student { StudentId = 201115162, StuGivenName = "Arturo", StuFamilyName = "Anand", EnrollmentDate = DateTime.Parse("2003-09-01") },
                    new Student { StudentId = 201615126, StuGivenName = "Gytis", StuFamilyName = "Barzdukas", EnrollmentDate = DateTime.Parse("2002-09-01") },
                    new Student { StudentId = 199914369, StuGivenName = "Yan", StuFamilyName = "Li", EnrollmentDate = DateTime.Parse("2002-09-01") },
                    new Student { StudentId = 200623498, StuGivenName = "Peggy", StuFamilyName = "Justice", EnrollmentDate = DateTime.Parse("2001-09-01") },
                    new Student { StudentId = 200361459, StuGivenName = "Laura", StuFamilyName = "Norman", EnrollmentDate = DateTime.Parse("2003-09-01") },
                    new Student { StudentId = 200364955, StuGivenName = "Nino", StuFamilyName = "Olivetto", EnrollmentDate = DateTime.Parse("2005-09-01") }
                    );

                context.Enrollment.AddRange(
                    new Enrollment { StudentId = 201203055, CourseId = 10506, Grade = Grade.A },
                    new Enrollment { StudentId = 201203055, CourseId = 40299, Grade = Grade.C },
                    new Enrollment { StudentId = 201203055, CourseId = 40491, Grade = Grade.B },
                    new Enrollment { StudentId = 201006074, CourseId = 10458, Grade = Grade.B },
                    new Enrollment { StudentId = 201006074, CourseId = 31415, Grade = Grade.F },
                    new Enrollment { StudentId = 201006074, CourseId = 20211, Grade = Grade.F },
                    new Enrollment { StudentId = 201115162, CourseId = 10506 },
                    new Enrollment { StudentId = 201615126, CourseId = 10506 },
                    new Enrollment { StudentId = 201615126, CourseId = 40299, Grade = Grade.F },
                    new Enrollment { StudentId = 201615126, CourseId = 40491, Grade = Grade.C },
                    new Enrollment { StudentId = 201615126, CourseId = 10458 },
                    new Enrollment { StudentId = 201615126, CourseId = 31415, Grade = Grade.A }
                    );

                context.SaveChanges();


                //向数据库中插入语句
                //context.Course.FromSql("SET IDENTITY_INSERT dbo.Course ON").ToList();
                //context.Course.AddRange(

                //    new Course
                //    {
                //        CourseId = 1001,
                //        CourseName = "Introduction to Information Science and Technology",
                //        CourseCredit = 1,
                //        CourseLevel = "Base",
                //        CourseDate = "Monday",
                //        CourseTime = 1
                //    },

                //    new Course
                //    {
                //        CourseId = 1002,
                //        CourseName = "Engineering graphics foundation",
                //        CourseCredit = 2,
                //        CourseLevel = "Base",
                //        CourseDate = "Monday",
                //        CourseTime = 2
                //    },

                //    new Course
                //    {
                //        CourseId =1003,
                //        CourseName = "Circuit principle",
                //        CourseCredit = 2,
                //        CourseLevel = "Base",
                //        CourseDate = "Tuesday",
                //        CourseTime = 1
                //    },

                //    new Course
                //    {
                //        CourseId = 1004,
                //        CourseName = "Data Structures and Algorithms",
                //        CourseCredit = 4,
                //        CourseLevel = "Core",
                //        CourseDate = "Tuesday",
                //        CourseTime = 2
                //    },

                //    new Course
                //    {
                //        CourseId = 1005,
                //        CourseName = "Functional Language Programming",
                //        CourseCredit = 3,
                //        CourseLevel = "Core",
                //        CourseDate = "Thursday",
                //        CourseTime = 1
                //    },

                //    new Course
                //    {
                //        CourseId = 1006,
                //        CourseName = "Digital Media (1): Graphics and Animation",
                //        CourseCredit = 5,
                //        CourseLevel = "Elective",
                //        CourseDate = "Thursday",
                //        CourseTime = 2
                //    },

                //    new Course
                //    {
                //        CourseId = 1007,
                //        CourseName = "Digital Media (2): Multimedia",
                //        CourseCredit = 5,
                //        CourseLevel = "Elective",
                //        CourseDate = "Thursday",
                //        CourseTime = 2
                //    },

                //    new Course
                //    {
                //        CourseId = 1008,
                //        CourseName = "Calculus",
                //        CourseCredit = 5,
                //        CourseLevel = "Math",
                //        CourseDate = "Friday",
                //        CourseTime = 1
                //    }
                //);
                //context.SaveChanges();
                //context.Course.FromSql("set identity_insert Course off").ToList();
            }
        }
    }
}