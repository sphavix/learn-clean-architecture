using Microsoft.Extensions.Logging;
using Movies.Core.Entities;

namespace Movies.Infrastructure.Data
{
    public class MovieContextSeed
    {
        public static async Task SeedAsync(MovieContext movieContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                await movieContext.Database.EnsureCreatedAsync();

                if (!movieContext.Movies.Any())
                {
                    movieContext.Movies.AddRange(GetMovies());
                    await movieContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<MovieContextSeed>();
                    log.LogError($"Exception occured while connecting: {ex.Message}");
                    await SeedAsync(movieContext, loggerFactory, retryForAvailability);
                }
            }
        }

        private static IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie {Title = "Avatar", DirectorName = "James Cameron", ReleaseYear = "2009"},
                new Movie {Title = "Titanic", DirectorName = "James Cameron", ReleaseYear = "1997"},
                new Movie {Title = "Die Another Day", DirectorName = "Lee Tamahori", ReleaseYear = "2002"},
                new Movie
                {
                    Title = "Godzilla",
                    DirectorName = "Gareth Edwards",
                    ReleaseYear = "2014"
                }
            };
        }
    }
}