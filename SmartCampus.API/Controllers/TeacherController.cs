using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCampus.API.Data;
using SmartCampus.API.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCampus.API.Controllers
{
    [Authorize(Roles = "Teacher")]
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("timetable/{lecturerId}")]
        public async Task<IActionResult> GetMyTimetable(int lecturerId)
        {
            var timetable = await _context.Timetables
                .Where(t => t.LecturerId == lecturerId)
                .ToListAsync();

            return Ok(timetable);
        }

        [HttpGet("assigned-issues/{lecturerId}")]
        public async Task<IActionResult> GetAssignedIssues(int lecturerId)
        {
            var issues = await _context.Issues
                .Where(i => i.AssignedTo == lecturerId)
                .ToListAsync();

            return Ok(issues);
        }
    }
}
