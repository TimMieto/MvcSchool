using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcSchool.Models
{
    public enum coursedate
    {
        monday, tuesday, wednesday, thursday, friday
    }
    public class Course
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression(@"^\d{5}")]
        [Display(Name = "课程号")]
        public int CourseId { get; set; }

        [Display(Name = "课程名")]
        public string CourseName { get; set; }

        [Display(Name ="学分")]
        public double CourseCredit { get; set; }

        [Display(Name = "课程类别")]
        public string CourseLevel { get; set; }

        [Display(Name = "授课时间")]
        public coursedate? CourseDate { get; set; }

        [Display(Name = "授课时段")]
        public int CourseTime { get; set; }

        public string MajorName { get; set; }
        public string TeacherName { get; set; }
        public Major Major { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
