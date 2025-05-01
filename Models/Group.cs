namespace GpsTogetherWebAPI.Models
{
    public class TravelGroup
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public ICollection<User>? Members { get; set; }
    }
}
