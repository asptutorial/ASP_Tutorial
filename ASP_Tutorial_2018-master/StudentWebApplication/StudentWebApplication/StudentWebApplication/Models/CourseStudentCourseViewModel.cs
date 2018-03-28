using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebApplication.Models
{
    public class CourseStudentCourseViewModel
    {
        public IEnumerable<StudentCourse> studentCourse { get; set; }
        public Cours course { get; set; }
    }
}