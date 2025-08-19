// Models/StudentCourse.cs
using StudentRegiter.Models;

namespace StudentRegiter.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student Student { get; set; } = default!;

        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;
    }
}
