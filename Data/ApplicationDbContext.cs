using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using GpsTogetherWebAPI.Models;

namespace GpsTogetherWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TravelGroup> Groups { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
}

