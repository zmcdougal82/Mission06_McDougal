using Microsoft.EntityFrameworkCore;

namespace Mission06_McDougal.Models // Ensure this matches your project namespace
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; } // Ensure Movie.cs exists
    }
}