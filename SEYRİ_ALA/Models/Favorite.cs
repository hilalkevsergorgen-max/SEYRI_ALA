
// Favorite.cs
namespace SEYRİ_ALA.Models
{
    public class Favorite
    {
        public int Id { get; set; }

        public int RouteId { get; set; }
        public TravelRoute Route { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
