// Comment.cs
using System;

namespace SEYRİ_ALA.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int RouteId { get; set; }
        public TravelRoute Route { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public string Text { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsApproved { get; set; } = true;
    }
}
