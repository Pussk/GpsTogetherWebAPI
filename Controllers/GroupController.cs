using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GpsTogetherWebAPI.Models;
using GpsTogetherWebAPI.Data;

namespace GpsTogetherWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var code = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            var group = new TravelGroup { Code = code, Members = new List<User>() };
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return Ok(group);
        }

        [HttpPost("join/{code}")]
        public async Task<IActionResult> Join(string code, [FromBody] int userId)
        {
            var group = await _context.Groups.Include(g => g.Members).FirstOrDefaultAsync(g => g.Code == code);
            if (group == null) return NotFound("Group not found");

            var user = await _context.Users.FindAsync(userId);
            if (user == null) return NotFound("User not found");

            group.Members.Add(user);
            await _context.SaveChangesAsync();
            return Ok(group);
        }
    }
}
