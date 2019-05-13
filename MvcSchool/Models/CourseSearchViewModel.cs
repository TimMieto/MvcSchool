using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcSchool.Models
{
    public class CourseSearchViewModel
    {
        public List<Course> Courses;

        public string SearchName { get; set; }

        public SelectList Levels;
        public string SearchLevel { get; set; }

        public SelectList Dates;
        public string SearchDate { get; set; }

        public SelectList Times;
        public int SearchTime { get; set; }

    }
}
