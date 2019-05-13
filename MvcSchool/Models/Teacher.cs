using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcSchool.Models
{
    public class Teacher
    {
        [Required]
        [RegularExpression(@"^\d{9}")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "教师番号")]
        public int TeacherId { get; set; }

        [Display(Name = "姓名")]
        public string TeacherName { get; set; }

        [Display(Name = "专业")]
        public string MajorName { get; set; }
        public Major Major { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
