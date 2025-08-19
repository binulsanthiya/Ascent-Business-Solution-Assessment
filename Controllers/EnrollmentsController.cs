// Controllers/EnrollmentsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegiter.Data;
using StudentRegiter.Models;
using StudentRegiter.Data;
using StudentRegiter.Models;

namespace StudentRegiter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public EnrollmentsController(AppDbContext db) => _db = db;

        // Get selected course IDs for a student
        [HttpGet("{studentId}")]
        public async Task<ActionResult<IEnumerable<int>>> Get(int studentId)
        {
            var exists = await _db.Students.AnyAsync(s => s.StudentId == studentId);
            if (!exists) return NotFound();

            var ids = await _db.StudentCourses
                .Where(sc => sc.StudentId == studentId)
                .Select(sc => sc.CourseId)
                .ToListAsync();

            return ids;
        }

        // Replace enrollments for a student
        public record SaveRequest(int StudentId, List<int> CourseIds);

        [HttpPost]
        public async Task<IActionResult> Save(SaveRequest req)
        {
            var student = await _db.Students
                .Include(s => s.StudentCourses)
                .FirstOrDefaultAsync(s => s.StudentId == req.StudentId);

            if (student is null) return NotFound("Student not found");

            student.StudentCourses.Clear();
            foreach (var cid in req.CourseIds.Distinct())
                student.StudentCourses.Add(new StudentCourse { StudentId = req.StudentId, CourseId = cid });

            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
