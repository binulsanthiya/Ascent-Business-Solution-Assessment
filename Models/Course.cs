// Models/Course.cs
using System.ComponentModel.DataAnnotations;

namespace StudentRegiter.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required, StringLength(20)] public string Code { get; set; } = "";
        [Required, StringLength(200)] public string Title { get; set; } = "";
        public int Credits { get; set; } = 0;

        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
