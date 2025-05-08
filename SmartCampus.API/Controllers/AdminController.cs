using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCampus.API.Data;
using SmartCampus.API.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCampus.API.Controllers
{
    [Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("create-announcement")]
        public async Task<IActionResult> CreateAnnouncement(Announcement announcement)
        {
            announcement.Date = DateTime.Now;
            _context.Announcements.Add(announcement);
            await _context.SaveChangesAsync();
            return Ok(announcement);
        }

        [HttpGet("dashboard-analytics")]
        public async Task<IActionResult> GetAnalytics()
        {
            var bookingsCount = await _context.Bookings.CountAsync();
            var issuesCount = await _context.Issues.CountAsync();
            var usersCount = await _context.Users.CountAsync();

            return Ok(new
            {
                bookingsCount,
                issuesCount,
                usersCount
            });
        }

        [HttpPut("update-service/{id}")]
        public async Task<IActionResult> UpdateService(int id, Service updatedService)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return NotFound();

            service.Name = updatedService.Name;
            service.Description = updatedService.Description;
            service.Location = updatedService.Location;
            service.Capacity = updatedService.Capacity;
            service.Availability = updatedService.Availability;

            await _context.SaveChangesAsync();
            return Ok(service);
        }

        [HttpGet("all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users.Include(u => u.Role).ToListAsync();
            return Ok(users);
        }
    }
}
