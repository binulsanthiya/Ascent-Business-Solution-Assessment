// Controllers/CoursesController.cs
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
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _db;
        public CoursesController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<IEnumerable<Course>> Get() =>
            await _db.Courses.OrderBy(c => c.Code).ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Course>> Post(Course c)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _db.Courses.Add(c);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = c.CourseId }, c);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetById(int id)
        {
            var c = await _db.Courses.FindAsync(id);
            return c is null ? NotFound() : c;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var c = await _db.Courses.FindAsync(id);
            if (c is null) return NotFound();
            _db.Courses.Remove(c);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
