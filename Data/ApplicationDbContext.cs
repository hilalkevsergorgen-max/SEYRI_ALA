using Microsoft.EntityFrameworkCore;
using SEYRİ_ALA.Models;

namespace SEYRİ_ALA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<City> Cities { get; set; }
        public DbSet<TravelRoute> Routes => Set<TravelRoute>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Favorite> Favorites => Set<Favorite>();

        // BURADAN BAŞLIYOR - Parantez içinde olduğuna emin ol!
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Ankara", Latitude = 39.9334, Longitude = 32.8597, Description = "Türkiye'nin kalbi, Cumhuriyet'in başkenti ve Anıtkabir'in evi.", HistoryScore = 10, NatureScore = 6, FoodScore = 8 },
                new City { Id = 2, Name = "İstanbul", Latitude = 41.0082, Longitude = 28.9784, Description = "İki kıtanın buluştuğu, tarihin kalbi İstanbul.", HistoryScore = 10, NatureScore = 5, FoodScore = 10 },
                new City { Id = 3, Name = "Kapadokya", Latitude = 38.6431, Longitude = 34.8289, Description = "Peri bacaları ve sıcak hava balonlarıyla masalsı bir yolculuk.", HistoryScore = 9, NatureScore = 10, FoodScore = 7 },
                new City { Id = 4, Name = "Antalya", Latitude = 36.8841, Longitude = 30.7056, Description = "Masmavi deniz ve antik kentlerin buluşma noktası.", HistoryScore = 8, NatureScore = 9, FoodScore = 8 },
                new City { Id = 5, Name = "Trabzon", Latitude = 41.0027, Longitude = 39.7168, Description = "Sümela Manastırı ve Uzungöl ile doğanın yeşil tonları.", HistoryScore = 8, NatureScore = 10, FoodScore = 9 }
            );
        }
    }
}