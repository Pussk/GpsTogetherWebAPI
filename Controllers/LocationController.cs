using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GpsTogetherWebAPI.Models;
using GpsTogetherWebAPI.Data;

namespace GpsTogetherWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LocationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Share(Location location)
        {
            location.Timestamp = DateTime.UtcNow;
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return Ok(location);
        }

        [HttpGet("group/{groupId}")]
        public async Task<IActionResult> GetGroupLocations(int groupId)
        {
            var group = await _context.Groups.Include(g => g.Members).FirstOrDefaultAsync(g => g.Id == groupId);
            if (group == null) return NotFound("Group not found");

            var memberIds = group.Members.Select(u => u.Id).ToList();
            var locations = await _context.Locations
                .Where(l => memberIds.Contains(l.UserId))
                .OrderByDescending(l => l.Timestamp)
                .ToListAsync();

            return Ok(locations);
        }
    }
}
