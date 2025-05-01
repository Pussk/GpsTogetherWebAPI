namespace GpsTogetherWebAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public ICollection<Location>? Locations { get; set; }
    }
}
