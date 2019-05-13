using System;
using System.Linq;

namespace MvcSchool.Models
{
    public static class DbInitializer
    {
        public static void Initialize(MvcSchoolContext context)
        {
            // context.Database.EnsureCreated();

            // Look for any students.
            if (context.Student.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{//StudentId=33,
                StuGivenName ="Alexander",StuFamilyName="Smith",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{//StudentId=56,
                StuGivenName ="Meredith",StuFamilyName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{//StudentId=22,
                StuGivenName ="Arturo",StuFamilyName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{//StudentId=55,
                StuGivenName ="Gytis",StuFamilyName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{//StudentId=66,
                StuGivenName ="Yan",StuFamilyName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{//StudentId=67,
                StuGivenName ="Peggy",StuFamilyName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{//StudentId=44,
                StuGivenName ="Laura",StuFamilyName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{//StudentId=24,
                StuGivenName ="Nino",StuFamilyName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
            new Course{//CourseId=144,
                CourseName ="Chemistry",CourseCredit=3},
            new Course{//CourseId=133,
                CourseName ="Microeconomics",CourseCredit=3},
            new Course{//CourseId=122,
                CourseName ="Macroeconomics",CourseCredit=3},
            new Course{//CourseId=111,
                CourseName ="Calculus",CourseCredit=4},
            new Course{//CourseId=145,
                CourseName ="Trigonometry",CourseCredit=4},
            new Course{//CourseId=134,
                CourseName ="Composition",CourseCredit=3},
            new Course{//CourseId=112,
                CourseName ="Literature",CourseCredit=4}
            };
            foreach (Course c in courses)
            {
                context.Course.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{StudentId=1,CourseId=3,Grade=Grade.A},
            new Enrollment{StudentId=2,CourseId=4,Grade=Grade.C},
            new Enrollment{StudentId=3,CourseId=5,Grade=Grade.B},
            new Enrollment{StudentId=4,CourseId=6,Grade=Grade.B},
            new Enrollment{StudentId=5,CourseId=7,Grade=Grade.F},
            new Enrollment{StudentId=6,CourseId=1,Grade=Grade.F},
            new Enrollment{StudentId=7,CourseId=2},
            new Enrollment{StudentId=6,CourseId=3},
            new Enrollment{StudentId=5,CourseId=3,Grade=Grade.F},
            new Enrollment{StudentId=8,CourseId=4,Grade=Grade.C},
            new Enrollment{StudentId=3,CourseId=5},
            new Enrollment{StudentId=4,CourseId=6,Grade=Grade.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollment.Add(e);
            }
            context.SaveChanges();
        }
    }
}