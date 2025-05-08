using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCampus.API.Data;
using SmartCampus.API.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCampus.API.Controllers
{
    [Authorize(Roles = "Student")]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("timetable/{studentId}")]
        public async Task<IActionResult> GetTimetable(int studentId)
        {
            var timetable = await _context.Timetables
                .Where(t => t.StudentIds.Contains(studentId))
                .ToListAsync();

            return Ok(timetable);
        }

        [HttpPost("book-service")]
        public async Task<IActionResult> BookService(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return Ok(booking);
        }

        [HttpPost("report-issue")]
        public async Task<IActionResult> ReportIssue(Issue issue)
        {
            issue.Status = "reported";
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();
            return Ok(issue);
        }

        [HttpGet("notifications/{userId}")]
        public async Task<IActionResult> GetNotifications(int userId)
        {
            var notifications = await _context.Notifications
                .Where(n => n.UserId == userId)
                .ToListAsync();
            return Ok(notifications);
        }
    }