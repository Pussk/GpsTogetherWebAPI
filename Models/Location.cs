namespace GpsTogetherWebAPI.Models
{
    public class Location
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
