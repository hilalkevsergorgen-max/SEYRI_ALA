using System.ComponentModel.DataAnnotations;

namespace SEYRİ_ALA.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        // Harita koordinatları (Leaflet için kritik)
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // AI Puanlama Kriterleri (0-10)
        public int HistoryScore { get; set; }
        public int NatureScore { get; set; }
        public int FoodScore { get; set; }
    }
}