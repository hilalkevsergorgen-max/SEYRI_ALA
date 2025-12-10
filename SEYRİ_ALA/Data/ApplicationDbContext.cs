using Microsoft.EntityFrameworkCore;
using SEYRİ_ALA.Models;

namespace SEYRİ_ALA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<TravelRoute> Routes => Set<TravelRoute>();
        public DbSet<Comment> Comments => Set<Comment>();
       public DbSet<Favorite> Favorites => Set<Favorite>();
    }
}
