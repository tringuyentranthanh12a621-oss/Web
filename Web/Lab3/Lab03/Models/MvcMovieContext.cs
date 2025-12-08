using Microsoft.EntityFrameworkCore;


namespace Lab03.Models
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
    }
}
