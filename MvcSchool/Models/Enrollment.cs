using System.ComponentModel.DataAnnotations;

namespace MvcSchool.Models

{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {

        public int EnrollmentId { get; set; }

        [Display(Name = "课程号")]
        public int CourseId { get; set; }

        [Display(Name = "学生番号")]
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }

        //外键
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
