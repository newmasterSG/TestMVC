using Microsoft.EntityFrameworkCore;
using TestMVC.Data;

namespace TestMVC.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TestMVCContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TestMVCContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }
                context.Movie.AddRange(
                   new Movie
                   {
                       Title = "When Harry Met Sally",
                       ReleaseDate = DateTime.Parse("1989-1-11"),
                       Genre = "Romantic Comedy",
                       Rating = "R",
                       Price = 7.99M
                   },
                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Rating = "A",
                        Price = 8.99M
                    },
                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Rating = "C",
                        Price = 9.99M
                    },
                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Rating = "A",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
