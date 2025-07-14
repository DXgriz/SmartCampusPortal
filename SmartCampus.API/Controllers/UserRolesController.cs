using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCampus.API.Data;
using SmartCampus.API.Models;

namespace SmartCampus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetUserRoles()
        {
            var roles = await _context.Roles.ToListAsync(); // Fetch roles from the correct DbSet
            return Ok(roles); // Return the roles as an ActionResult
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRole>> GetUserRole(int id)
        {
            var role = await _context.UserRoles.FindAsync(id);
            if (role == null) return NotFound();

            // Map IdentityUserRole<int> to UserRole
            var userRole = new UserRole
            {
                //UserId = role.UserId,
                RoleId = role.RoleId,
                RoleName = "DefaultRoleName" // Provide a default value for the required RoleName property
            };

            return userRole;
        }

        [HttpPost]
        public async Task<ActionResult<UserRole>> PostUserRole(UserRole role)
        {
            // Map UserRole to IdentityUserRole<int>
            var identityUserRole = new IdentityUserRole<int>
            {
                UserId = 0, // Replace with the actual UserId
                RoleId = role.RoleId
            };

            _context.UserRoles.Add(identityUserRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserRole), new { id = role.RoleId }, role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRole(int id, UserRole role)
        {
            if (id != role.RoleId) return BadRequest();
            _context.Entry(role).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRole(int id)
        {
            var role = await _context.UserRoles.FindAsync(id);
            if (role == null) return NotFound();
            _context.UserRoles.Remove(role);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
