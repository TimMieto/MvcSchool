using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcSchool.Models
{
    public class Student
    {
        //默认情况下，EF 将属性名为 ID 或者 类名ID 的属性作为主键。        
        [Required]
        [RegularExpression(@"^\d{9}")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "学生番号")]
        public int StudentId { get; set; }

        // user ID from AspNetUser table.
        public string OwnerID { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]+$")]
        [Display(Name = "姓")]
        public string StuFamilyName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]+$")]
        [Display(Name = "名")]
        public string StuGivenName { get; set; }

        [Display(Name = "性别")]
        public string StuGender { get; set; }

        [Display(Name = "生年月日")]
        [DataType(DataType.Date)]
        public DateTime StuBirth { get; set; }

        [Display(Name = "专业")]
        public string MajorName { get; set; }
        public Major Major { get; set; }

        [Display(Name = "学分")]
        public double StuCredit { get; set; }

        [Display(Name = "入学日期")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }


        //Enrollments的外键
        public ICollection<Enrollment> Enrollments { get; set; }

        public ContactStatus Status { get; set; }
    }
    public enum ContactStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
