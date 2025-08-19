// Controllers/StudentsController.cs
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
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public StudentsController(AppDbContext db) => _db = db;

        [HttpGet]
        [HttpGet]
        public async Task<IEnumerable<Student>> Get() =>
            await _db.Students
                .OrderByDescending(s => s.StudentId)
                .ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Student>> Post(Student s)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _db.Students.Add(s);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = s.StudentId }, s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            var s = await _db.Students
                .Include(x => x.StudentCourses).ThenInclude(sc => sc.Course)
                .FirstOrDefaultAsync(x => x.StudentId == id);
            return s is null ? NotFound() : s;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var s = await _db.Students.FindAsync(id);
            if (s is null) return NotFound();
            _db.Students.Remove(s);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
