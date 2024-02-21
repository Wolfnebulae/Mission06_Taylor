using Microsoft.EntityFrameworkCore;

namespace DateMe.Models
{
    public class MovieApplicationContext : DbContext
    {
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base (options) { }

        public DbSet<Application> Movies { get; set; }
        public DbSet<MovieCategory> Categories { get; set; }
    }
}