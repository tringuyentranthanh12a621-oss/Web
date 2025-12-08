using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Lab03.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {

                // ===== SEED CATEGORY =====
                if (!context.Category.Any())
                {
                    context.Category.AddRange(
                        new Category { Name = "Action", Description = "Action movies" },
                        new Category { Name = "Comedy", Description = "Comedy movies" },
                        new Category { Name = "Romantic", Description = "Romantic movies" },
                        new Category { Name = "Horror", Description = "Horror movies" }
                    );

                    context.SaveChanges();
                }

                // ===== SEED MOVIE =====
                if (!context.Movie.Any())
                {
                    context.Movie.AddRange(
                        new Movie
                        {
                            Title = "When Harry Met Sally",
                            ReleaseDate = DateTime.Parse("1989-2-12"),
                            Genre = "Romantic Comedy",
                            Price = 7.99M,
                            CategoryId = context.Category.First(c => c.Name == "Romantic").Id
                        },
                        new Movie
                        {
                            Title = "Ghostbusters",
                            ReleaseDate = DateTime.Parse("1984-3-13"),
                            Genre = "Comedy",
                            Price = 8.99M,
                            CategoryId = context.Category.First(c => c.Name == "Comedy").Id
                        },
                        new Movie
                        {
                            Title = "Ghostbusters 2",
                            ReleaseDate = DateTime.Parse("1986-2-23"),
                            Genre = "Comedy",
                            Price = 9.99M,
                            CategoryId = context.Category.First(c => c.Name == "Comedy").Id
                        },
                        new Movie
                        {
                            Title = "Rio Bravo",
                            ReleaseDate = DateTime.Parse("1959-4-15"),
                            Genre = "Western",
                            Price = 3.99M,
                            CategoryId = context.Category.First(c => c.Name == "Action").Id
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
