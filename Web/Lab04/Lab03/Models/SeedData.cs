using Microsoft.EntityFrameworkCore;
using MvcMovieFinal.Data;

namespace MvcMovieFinal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
              serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
            {
                // Nếu đã có phim, thì dừng lại
                if (context.Movie.Any())
                {
                    return;
                }

                // Kiểm tra Category để tránh lỗi khi tạo phim (dữ liệu mẫu)
                if (!context.Category.Any())
                {
                    var comedy = new Category { Name = "Romantic Comedy" };
                    var action = new Category { Name = "Action" };
                    var western = new Category { Name = "Western" };
                    var horror = new Category { Name = "Horror" };

                    context.Category.AddRange(comedy, action, western, horror);
                    context.SaveChanges();
                }

                // Lấy lại các Category để đảm bảo có Id hợp lệ
                var categories = context.Category.ToDictionary(c => c.Name);

                context.Movie.AddRange(
                  new Movie
                  {
                      Title = "When Harry Met Sally",
                      ReleaseDate = DateTime.Parse("1989-2-12"),
                      CategoryId = categories["Romantic Comedy"].Id,
                      Price = 7.99M,
                      Rating = "G"

                  },
                  new Movie
                  {
                      Title = "Ghostbusters ",
                      ReleaseDate = DateTime.Parse("1984-3-13"),
                      CategoryId = categories["Romantic Comedy"].Id,
                      Price = 8.99M,
                      Rating = "G"

                  },
                  new Movie
                  {
                      Title = "Rio Bravo",
                      ReleaseDate = DateTime.Parse("1959-4-15"),
                      CategoryId = categories["Western"].Id,
                      Price = 3.99M,
                      Rating = "G"

                  }
                );
                context.SaveChanges();
            }
        }
    }
}