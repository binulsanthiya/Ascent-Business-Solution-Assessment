// Models/Student.cs
using System.ComponentModel.DataAnnotations;

namespace StudentRegiter.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required, StringLength(100)] public string FirstName { get; set; } = "";
        [Required, StringLength(100)] public string LastName { get; set; } = "";
        [Required, EmailAddress, StringLength(255)] public string Email { get; set; } = "";
        [Phone, StringLength(20)] public string? Phone { get; set; }

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
