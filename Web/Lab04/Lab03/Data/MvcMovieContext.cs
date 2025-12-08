using Microsoft.EntityFrameworkCore;
using MvcMovieFinal.Models;

namespace MvcMovieFinal.Data
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