using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcSchool.Models
{
    public class Major
    {
        [Required]
        [RegularExpression(@"^\d{2}")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MajorId { get; set; }

        [Display(Name = "专业")]
        public string MajorName { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
